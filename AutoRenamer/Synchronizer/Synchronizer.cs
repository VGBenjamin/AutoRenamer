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

        public void Synch(StatusDetail statusDetail)
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

                var targetPath = Path.Combine(statusDetail.DestinationFile,
                    newName.StartsWith("\\") ? newName.Substring(1) : newName);
                CopyFile(statusDetail, targetPath);
            }
            else
            {
                log.Error($"Cannot detect the tv show for the file: {statusDetail.SourceFile}");
            }
        }

        private void CopyFile(StatusDetail statusDetail, string targetPath)
        {            
            bool copy = false;
            var status = statusDetail.Status;
            bool updated = true;
          
            if (File.Exists(targetPath))
            {
                using (var msgBox = new FileExistDialog()
                {
                    OriginalFilePath = statusDetail.SourceFile,
                    TargetFilePath = targetPath
                })
                {
                    switch (msgBox.ShowDialog())
                    {
                        case DialogResult.Yes: // Override
                            copy = true;
                            statusDetail.Status = StatusEnum.Synched;
                            break;
                        case DialogResult.Retry: // Skip but mark as synched
                            statusDetail.Status = StatusEnum.Synched;
                            break;
                        case DialogResult.No: //Skip and do not change the status
                        default:
                            updated = false;
                            break;
                    }
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
                statusDetail .Status= StatusEnum.Synched;
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
