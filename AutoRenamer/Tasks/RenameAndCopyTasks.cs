using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Objects;
using AutoRenamer.BOL.Objects.TasksQueue;
using AutoRenamer.BOL.Utils;
using AutoRenamer.MessageBoxes;

namespace AutoRenamer.Tasks
{
    public class RenameAndCopyTasks : BaseTask
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly StatusDetail _statusDetail;

        public RenameAndCopyTasks(Guid taskBatchId, StatusDetail statusDetail) 
            : base( taskBatchId, Path.GetFileName(statusDetail.SourceFile), statusDetail.SourceFile)
        {
            _statusDetail = statusDetail;
        }

        public override ITask Execute()
        {
            IncrementProgress(1);

            log.Info($"Calling filebot for the file: {_statusDetail.SourceFile}");
            var arguments = AutoRenamerConfig.Instance.FilebotExpression.Value.Replace("%FILENAME%", _statusDetail.SourceFile);
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

            IncrementProgress(10);

            log.Debug(output);
            var regex = new Regex(@"\[TEST\] Rename \[.+?\] to \[(.+?)\]");
            var match = regex.Match(output);

            if (match.Success && match.Groups.Count >= 2)
            {
                var newName = match.Groups[1].Value;
                log.Info($"Detected new name: {newName}.");

                var targetPath = Path.Combine(_statusDetail.DestinationFolder,
                    newName.StartsWith("\\") ? newName.Substring(1) : newName);
                CopyFile(_statusDetail, targetPath, TaskBatchId);
            }
            else
            {
                var msg = $"Cannot detect the tv show for the file: {_statusDetail.SourceFile}";
                log.Error(msg);
                _statusDetail.Reason = msg;
                _statusDetail.Status = StatusEnum.Error;
            }

            IncrementProgress(100);

            //Copy and rename
            return base.Execute();
        }



        public void Synch(StatusDetail statusDetail, Guid batchId)
        {
            
        }

        private void CopyFile(StatusDetail statusDetail, string targetPath, Guid batchId)
        {
            bool copy = false;
            var status = statusDetail.Status;
            bool updated = true;

            if (File.Exists(targetPath))
            {
                var decision =
                    DecisionManager.Instance.GetDecision<FileExistDialogDecision>(batchId);

                var choice = FileExistDialog.FileExistActionEnum.None;

                if (decision != null &&
                       ((FileExistDialog.FileExistActionEnum)decision.Choice & FileExistDialog.FileExistActionEnum.All) == FileExistDialog.FileExistActionEnum.All)
                {
                    choice = (FileExistDialog.FileExistActionEnum)decision.Choice;
                }
                else
                {
                    choice = GetDecisionFromMessageBox(statusDetail, targetPath);
                    DecisionManager.Instance.SaveDecision(new Decision(batchId, (int)choice));
                }


                if ((choice & FileExistDialog.FileExistActionEnum.Override) ==
                    FileExistDialog.FileExistActionEnum.Override)
                {
                    copy = true;
                    statusDetail.Status = StatusEnum.Synched;
                }
                else if((choice & FileExistDialog.FileExistActionEnum.SkipButSynched) ==
                  FileExistDialog.FileExistActionEnum.SkipButSynched)
                {
                }
                else if (choice == FileExistDialog.FileExistActionEnum.None)
                {
                    return;
                }
                else
                {
                    updated = false;
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
                var fileCopier = new CustomFileCopier(statusDetail.SourceFile, targetPath, this);
                fileCopier.OnProgressChanged += (double persentage, ref bool cancel) =>
                {
                    IncrementProgress(10 + (int)((persentage/100)*90)); //10% for the name the rest for the copy
                };
                fileCopier.Copy();
                log.Info("File copied");
            }

            if (updated)
            {
                statusDetail.DestinationFile = targetPath;
                statusDetail.SynchDate = DateTime.Now;
                statusDetail.Status = StatusEnum.Synched;
            }
        }

        private FileExistDialog.FileExistActionEnum GetDecisionFromMessageBox(StatusDetail statusDetail, string targetPath)
        {
            using (var msgBox = new FileExistDialog(statusDetail.SourceFile, targetPath))
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
