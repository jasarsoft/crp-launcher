using System;
using System.IO;
using System.Security.Cryptography;

namespace Jasarsoft.Columbia.Library
{
    public abstract class Data1
    {
        protected bool Check(string path, string[] data)
        {
            //if (path == "") throw new ArgumentException("Argument 'path' is empty.");
            //if (path == null) throw new ArgumentNullException("Argument 'path' is not initialized.");
            //if (!Directory.Exists(path)) throw new DirectoryNotFoundException(String.Format("Directory does not exist: {0}", path));

            if (!Directory.Exists(path)) return false;

            bool result = false;
            string[] files = Directory.GetFiles(path);

            //prolaz kroz cijelu kolekciju fajlova
            foreach (string file in files)
            {
                //traznje fajla u podacima
                foreach (string name in data)
                    if (name == file)
                    {
                        result = true;
                        break;
                    }
                
                //provjera da li je nadjen fajl
                if (result == false) return false;
            }

            return result;
        }

        protected bool Valid(string path, string[,] data)
        {
            if (!Directory.Exists(path)) return false;

            bool result = false;
            int len = data.Length / data.Rank;
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                for (int i = 0; i < len; i++)
                    if (data[i, 1] == file)
                        using (var md5 = MD5.Create())
                            using (var stream = File.OpenRead(file))
                                if (data[i, 0] == BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty))
                                {
                                    result = true;
                                    break;
                                }

                if (result == false)
                    return false;
            }

            return result;
        }
    }
}
