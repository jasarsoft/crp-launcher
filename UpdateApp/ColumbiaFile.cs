using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jasarsoft.Columbia.Update
{
    internal class ColumbiaFile
    {
        //private fields
        private readonly string name;
        private readonly string hash;
        private readonly long size;

        /// <summary>
        /// Class default constructor
        /// </summary>
        public ColumbiaFile(string name, string hash, long size)
        {
            this.name = name;
            this.hash = hash;
            this.size = size;
        }

        /// <summary>
        /// Name of update file
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Hash value of upadate file
        /// </summary>
        public string Hash
        {
            get { return this.hash; }
        }

        /// <summary>
        /// Size value of file
        /// </summary>
        public long Size
        {
            get { return this.size; }
        }
    }
}
