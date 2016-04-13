using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Objects;
using AutoRenamer.MessageBoxes;

namespace AutoRenamer.Synchronizer
{
    public class Synchronizer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Guid LastBatchId { get; set; } = Guid.Empty;
        public FileExistDialog.FileExistActionEnum LastDecision { get; set; }

        public void Synch(StatusDetail statusDetail, Guid batchId)
        {
            log.Info($"Calling filebot for the file: {statusDetail.SourceFile}");
            var arguments = AutoRenamerConfig.Instance.FilebotExpression.Value.Replace("%FILENAME%", statusDetail.SourceFile);
            log.Debug($"Filebot arguments: {arguments}");

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "filebot",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            log.Debug(output);
            var regex = new Regex(@"\[TEST\] Rename \[.+?\] to \[(.+?)\]");
            var match = regex.Match(output);

            if (match.Success && match.Groups.Count >= 2)
            {
                var newName = match.Groups[1].Value;
                log.Info($"Detected new name: {newName}.");

                var targetPath = Path.Combine(statusDetail.DestinationFolder,
                    newName.StartsWith("\\") ? newName.Substring(1) : newName);
                CopyFile(statusDetail, targetPath, batchId);
            }
            else
            {
                var msg = $"Cannot detect the tv show for the file: {statusDetail.SourceFile}";
                log.Error(msg);
                statusDetail.Reason = msg;
                statusDetail.Status = StatusEnum.Error;                
            }
        }

        private void CopyFile(StatusDetail statusDetail, string targetPath, Guid batchId)
        {            
            bool copy = false;
            var status = statusDetail.Status;
            bool updated = true;
            FileExistDialog.FileExistActionEnum decision = FileExistDialog.FileExistActionEnum.None;

            if (File.Exists(targetPath))
            {
                if (LastBatchId == batchId && 
                       (LastDecision == FileExistDialog.FileExistActionEnum.OverrideAll ||
                        LastDecision == FileExistDialog.FileExistActionEnum.SkipAndLetStatusAll ||
                        LastDecision == FileExistDialog.FileExistActionEnum.SkipButSynchedAll))
                {
                    decision = LastDecision;
                }
                else
                {
                    decision = GetDecisionFromMessageBox(statusDetail, targetPath);
                }

                switch (decision)
                {
                    case FileExistDialog.FileExistActionEnum.Override: // Override
                    case FileExistDialog.FileExistActionEnum.OverrideAll: // Override
                        copy = true;
                        statusDetail.Status = StatusEnum.Synched;
                        break;
                    case FileExistDialog.FileExistActionEnum.SkipButSynched: // Skip but mark as synched
                    case FileExistDialog.FileExistActionEnum.SkipButSynchedAll: // Skip but mark as synched
                        statusDetail.Status = StatusEnum.Synched;
                        break;
                    case FileExistDialog.FileExistActionEnum.None:
                        return;
                    default:
                        updated = false;
                        break;
                }

                log.Debug($"Conflict with the target file: '{targetPath}' - Source : '{statusDetail.SourceFile}' - Copy: {copy} - New status: {status}");
            }
            else //No conflicts
            {
                copy = true;
            }

            if (copy)
            {
                string directory = Path.GetDirectoryName(targetPath);
                CreateDirectory(new DirectoryInfo(directory));

                log.Info($"Copying from: '{statusDetail.SourceFile}' to '{targetPath}'");
                File.Copy(statusDetail.SourceFile, targetPath, true);
                log.Info("File copied");
            }

            if (updated)
            {
                statusDetail.DestinationFile = targetPath;
                statusDetail.SynchDate = DateTime.Now;
                statusDetail.Status= StatusEnum.Synched;
            }
        }

        private FileExistDialog.FileExistActionEnum GetDecisionFromMessageBox(StatusDetail statusDetail, string targetPath)
        {
            using (var msgBox = new FileExistDialog()
            {
                OriginalFilePath = statusDetail.SourceFile,
                TargetFilePath = targetPath
            })
            {
                msgBox.ShowDialog();
                return msgBox.SelectedAction;
            }
        }

        private void CreateDirectory(DirectoryInfo directory)
        {
            if (directory?.Parent == null)
                return;

            if (!directory.Parent.Exists)
                CreateDirectory(directory.Parent);
            directory.Create();

            log.Debug($"Directory: {directory.FullName} created.");
        }
    }
}
