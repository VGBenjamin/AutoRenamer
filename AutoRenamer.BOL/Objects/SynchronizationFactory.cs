using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Objects.EventArgs;

namespace AutoRenamer.BOL.Objects
{
    public class SynchronizationFactory
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region events
        #region event FolderLoading
        public delegate void FolderLoadingEventHandler(object sender, FolderLoadingEventArgs e);
        public event FolderLoadingEventHandler OnFolderLoading;
        #endregion

        #region event FolderLoading
        public delegate void FolderLoadedEventHandler(object sender, FolderLoadedEventArgs e);
        public event FolderLoadedEventHandler OnFolderLoaded;
        #endregion

        #region event FileLoaded
        public delegate void FileLoadedEventHandler(object sender, FileLoadedEventArgs e);
        public event FileLoadedEventHandler OnFileLoaded;
        #endregion
        #endregion

        public Synchronization GetSynchronizationFromFileAndDisk(string xmlFilePath)
        {
            EnsureTreatedFilesExist(xmlFilePath);

            //Get from saved file
            var currentSynchronization = Synchronization.DeserializeFromXml(xmlFilePath);
            currentSynchronization.EnableFolderWatching();
            //Get from the file list
            return LoadUnTreatedFiles(currentSynchronization);
        }

        private void EnsureTreatedFilesExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                log.Debug($"The file does not exist yet => create it in '{filePath}'");
                var synch = new Synchronization();
                synch.SerializeToXml(filePath);
            }
        }

        private Synchronization LoadUnTreatedFiles(Synchronization currentSynchronization)
        {
            int folderTreated = 0;
            foreach (FolderToWatch folderPath in AutoRenamerConfig.Instance.FoldersToWatch)
            {
                folderTreated++;
                if (!Directory.Exists(folderPath.Source))
                {
                    log.Error($"The watched source directory '{folderPath.Source}' does not exist");
                    continue;
                }

                if (!Directory.Exists(folderPath.Source))
                {
                    log.Error($"The destination directory '{folderPath.Destination}' does not exist");
                    continue;
                }

                log.Debug($"Listing the files from '{folderPath.Source}'");
                var files = Directory.GetFiles(folderPath.Source);
                OnFolderLoading?.Invoke(this, new FolderLoadingEventArgs(folderPath.Source, AutoRenamerConfig.Instance.FoldersToWatch.Count, folderTreated, files.Length));

                foreach (var file in files)
                {
                    var entry = currentSynchronization.StatusList.FirstOrDefault(status => status.SourceFile == file);

                    if (entry == null)
                    {
                        currentSynchronization.StatusList.Add(new StatusDetail()
                        {
                            SourceFile = file,
                            Status = StatusEnum.NotSynched,
                            DestinationFolder = folderPath.Destination,
                            ReChecked = true
                        });
                    }
                    else
                    {
                        entry.ReChecked = true;
                    }
                    OnFileLoaded?.Invoke(this, new FileLoadedEventArgs(file));
                }
                OnFolderLoaded?.Invoke(this, new FolderLoadedEventArgs(folderPath.Source, AutoRenamerConfig.Instance.FoldersToWatch.Count, folderTreated));
            }

            //Mark all the files who haven't been recheck as SourceFileStillExist = false because we didn't have found it
            foreach (var statusDetail in currentSynchronization.StatusList)
            {
                statusDetail.SourceFileStillExist = statusDetail.ReChecked;
            }

            return currentSynchronization;
        }
    }
}
