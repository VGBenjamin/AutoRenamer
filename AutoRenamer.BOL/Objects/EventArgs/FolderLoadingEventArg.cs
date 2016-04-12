namespace AutoRenamer.BOL.Objects.EventArgs
{
    public class FolderLoadingEventArgs : System.EventArgs
    {
        public string FolderPath { get; set; }
        public int TotalNumberOfFolders { get; set; }
        public int CurrentFolderNumber { get; set; }
        public int NumberOfFiles { get; set; }

        public FolderLoadingEventArgs(string folderPath, int totalNumberOfFolders, int currentFolderNumber, int numberOfFiles) :base()
        {
            FolderPath = folderPath;
            TotalNumberOfFolders = totalNumberOfFolders;
            CurrentFolderNumber = currentFolderNumber;
            NumberOfFiles = numberOfFiles;
        }
    }
}
