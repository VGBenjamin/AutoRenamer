using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRenamer.BOL.Objects.TasksQueue;

namespace AutoRenamer.BOL.Utils
{
    public delegate void ProgressChangeDelegate(double Persentage, ref bool Cancel);
    public delegate void Completedelegate();

    public class CustomFileCopier
    {
        private readonly ITask _task;

        public CustomFileCopier(string Source, string Dest, ITask task)
        {
            _task = task;
            this.SourceFilePath = Source;
            this.DestFilePath = Dest;

            OnProgressChanged += delegate { };
            OnComplete += delegate { };
        }

        public void Copy()
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
            bool cancelFlag = false;

            using (FileStream source = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read))
            {
                File.Delete(DestFilePath); //Override
                long fileLength = source.Length;
                using (FileStream dest = new FileStream(DestFilePath, FileMode.CreateNew, FileAccess.Write))
                {
                    long totalBytes = 0;
                    int currentBlockSize = 0;

                    while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytes += currentBlockSize;
                        double persentage = (double)totalBytes * 100.0 / fileLength;

                        dest.Write(buffer, 0, currentBlockSize);

                        CheckPause();

                        cancelFlag = false;
                        OnProgressChanged?.Invoke(persentage, ref cancelFlag);

                        if (cancelFlag == true)
                        {
                            // Delete dest file here
                            break;
                        }
                    }
                }
            }

            OnComplete();
        }

        private void CheckPause()
        {
            while (_task.Paused)
            {
                Thread.Sleep(500);
            }
        }

        public string SourceFilePath { get; set; }
        public string DestFilePath { get; set; }

        public event ProgressChangeDelegate OnProgressChanged;
        public event Completedelegate OnComplete;
    }
}
