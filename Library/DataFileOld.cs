using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace Jasarsoft.Columbia.Library
{
    public class DataFileOld
    {
        List<string> files;

        public DataFileOld()
        {
            files = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));
        }

        public bool Check(string name)
        {
            //name = @".\" + name;

            foreach (string file in files)
            {
                if (name == file)
                {
                    if (File.Exists(name))
                        return true;
                }
            }

            return false;
        }

        public bool Valid(string hash, string name)
        {
            //name = @".\" + name;

            foreach (string file in files)
            {
                if (name == file)
                {
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(file))
                        {
                            if (hash == BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty))
                                return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
