using System;
using System.IO;
using System.Security.Cryptography;


namespace Jasarsoft.Columbia.Host
{
    internal static class HashFile
    {
        public static string GetMD5(string fileName)
        {
            if (fileName == null || !File.Exists(fileName)) return null;

            using (MD5 hash = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", String.Empty);
                } 
            }
        }
    }
}
