using System;
using System.IO;
using System.Collections.Generic;

namespace Jasarsoft.Columbia.Library
{
    public class DataFile
    {
        private List<string> allFiles;
        private List<int> missedFiles;
        private List<string> unknownFiles;

        public DataFile()
        {
            //this.allFiles = new List<string>();
            //this.missedFiles = new List<int>();
            //this.unknownFiles = new List<string>();
        }

        public List<string> AllFiles
        {
            get
            {
                this.allFiles = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));
                return this.allFiles;
            }
        }

        public List<int> MissedFiles
        {
            get { return this.missedFiles; }
        }

        public List<string> UnknownFiles
        {
            get { return this.unknownFiles; }
        }


        public bool CheckUnknown(string[] inputFiles, string[] skipFiles)
        {
            bool unknown;
            List<string> files = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));

            foreach (string file in files)
            {
                unknown = true;
                for (int i = 0; i < inputFiles.Length; i++)
                {
                    if (file == inputFiles[i])
                    {
                        unknown = false;
                        break;
                    }
                }

                if (unknown)
                {
                    foreach (string skip in skipFiles)
                    {
                        if (file == skip)
                        {
                            unknown = false;
                            break;
                        }
                    }
                }

                if (unknown) return true;
            }

            return false;
        }

        public bool CheckMissed(string[] inputFiles)
        {
            bool missed;

            List<string> files = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));

            for (int i = 0; i < inputFiles.Length; i++)
            {
                missed = true;
                foreach (string temp in files)
                {
                    if (temp == inputFiles[i])
                    {
                        missed = false;
                        break;
                    }
                }

                if (missed) return true;
            }

            return false;
        }


        public void ReadUnknown(string[] inputFiles, string[] skipFiles)
        {
            bool unknownFile;

            this.unknownFiles = new List<string>();
            this.allFiles = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));

            foreach (string fileName in this.allFiles)
            {
                unknownFile = true;
                for (int i = 0; i < inputFiles.Length; i++)
                {
                    if (fileName == inputFiles[i])
                    {
                        unknownFile = false;
                        break;
                    }     
                }

                if (unknownFile)
                {
                    foreach(string skipFile in skipFiles)
                    {
                        if (fileName == skipFile)
                        {
                            unknownFile = false;
                            break;
                        }
                    }
                }

                if (unknownFile) this.unknownFiles.Add(fileName);
            }
        }

        public void ReadMissed(string[] inputFiles)
        {
            bool missedFile;
            
            this.missedFiles = new List<int>();
            this.allFiles = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));

            for (int i = 0; i < inputFiles.Length; i++)
            {
                missedFile = true;
                foreach (string tempFile in allFiles)
                {
                    if (tempFile == inputFiles[i])
                    {
                        missedFile = false;
                        break;
                    }
                }

                if (missedFile) this.missedFiles.Add(i);
            }
        }
    }
}
