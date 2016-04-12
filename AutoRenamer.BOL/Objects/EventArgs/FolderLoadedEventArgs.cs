namespace AutoRenamer.BOL.Objects.EventArgs
{
    public class FolderLoadedEventArgs : System.EventArgs
    {
        public string FolderPath { get; set; }
        public int TotalNumberOfFolders { get; set; }
        public int CurrentFolderNumber { get; set; }

        public FolderLoadedEventArgs(string folderPath, int totalNumberOfFolders, int currentFolderNumber) :base()
        {
            FolderPath = folderPath;
            TotalNumberOfFolders = totalNumberOfFolders;
            CurrentFolderNumber = currentFolderNumber;
        }
    }
}
