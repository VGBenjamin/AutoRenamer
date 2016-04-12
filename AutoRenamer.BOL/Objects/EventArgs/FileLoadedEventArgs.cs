namespace AutoRenamer.BOL.Objects.EventArgs
{
    public class FileLoadedEventArgs : System.EventArgs
    {
        public string FilePath { get; set; }

        public FileLoadedEventArgs(string filePath) :base()
        {
            FilePath = filePath;
        }

    }
}
