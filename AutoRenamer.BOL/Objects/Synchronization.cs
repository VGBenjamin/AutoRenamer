using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoRenamer.BOL.Base;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Objects.EventArgs;

namespace AutoRenamer.BOL.Objects
{
    [Serializable]
    [XmlRoot("Synchronization")]
    public class Synchronization : XmlSerializable<Synchronization>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region event FolderLoading
        public event RenamedEventHandler OnFileRenamed;

        public event FileSystemEventHandler OnFileDeleted;
        public event FileSystemEventHandler OnFileAdded;
        #endregion

        [XmlArray]
        public BindingList<StatusDetail> StatusList { get; set; }

        public Synchronization()
        {
            StatusList = new BindingList<StatusDetail>();
        }

        public static new Synchronization DeserializeFromXml(string filePath)
        {
            var synchronization = XmlSerializable<Synchronization>.DeserializeFromXml(filePath);
            return synchronization;
        }


        public void Save()
        {
            log.Info($"Saving the info into '{AutoRenamerConfig.Instance.TreatedXMlPath}'");
            SerializeToXml(AutoRenamerConfig.Instance.TreatedXMlPath);
            log.Info($"Saved!");
        }

        public void EnableFolderWatching()
        {
            foreach (FolderToWatch folderPath in AutoRenamerConfig.Instance.FoldersToWatch)
            {
                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = folderPath.Source,
                    NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName
                };

                // Add event handlers.
                watcher.Created += OnWatcherFileChanged;
                watcher.Deleted += OnWatcherFileChanged;
                watcher.Renamed += OnWatcherRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
        }

        private void OnWatcherFileChanged(object source, FileSystemEventArgs e)
        {
            log.Info($"File: {e.FullPath} {e.ChangeType}");
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                var status = StatusList.FirstOrDefault(s => s.SourceFile == e.FullPath);
                if (status != null && status.Status == StatusEnum.NotSynched)
                {                    
                    StatusList.Remove(status);
                    OnFileDeleted?.Invoke(this, e);
                }                
            }
            else if (e.ChangeType == WatcherChangeTypes.Created)
            {                
                OnFileAdded?.Invoke(this, e);
            }
        }

        private void OnWatcherRenamed(object source, RenamedEventArgs e)
        {
            log.Info($"File: {e.OldFullPath} renamed to {e.FullPath}");

            var status = StatusList.FirstOrDefault(s => s.SourceFile == e.OldFullPath);
            if (status != null)
            {
                status.SourceFile = e.FullPath;
                OnFileRenamed?.Invoke(this, e);
            }
        }
    }
}
