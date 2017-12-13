using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasarsoft.Columbia
{
    internal class CheckFile
    {
        private int number;
        private string file;
        private long size;
        private string stats;

        public CheckFile(int number, string file, long size, string stats)
        {
            this.number = number;
            this.file = file;
            this.size = size;
            this.stats = stats;
        }

        public int Number
        {
            get { return this.number; }
        }

        public string File
        {
            get { return this.file; }
        }

        public long Size
        {
            get { return this.size; }
        }

        public string Stats
        {
            get { return this.stats; }
        }
    }
}
