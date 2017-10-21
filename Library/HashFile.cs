using System;
using System.IO;
using System.Security.Cryptography;


namespace Jasarsoft.Columbia.Library
{
    internal class HashFile
    {
        private string hashMD5;
        private string hashSHA1;
        private string hashSHA256;
        private string hashSHA384;
        private string hashSHA512;

        public enum HashType
        {
            MD5,
            SHA1,
            SHA256,
            SHA384,
            SHA512
        };


        //default constructor
        public HashFile()
        {
            this.Initialize();
        }

        public HashFile(string fileName)
        {
            this.Initialize();
            this.hashMD5 = this.GetMD5(fileName);
        }

        public HashFile(string fileName, HashType type)
        {
            this.Initialize();

            switch (type)
            {
                case HashType.MD5:
                    this.hashMD5 = this.GetMD5(fileName);
                    break;
                case HashType.SHA1:
                    this.hashSHA1 = this.GetSHA1(fileName);
                    break;
                case HashType.SHA256:
                    this.hashSHA256 = this.GetSHA256(fileName);
                    break;
                case HashType.SHA384:
                    this.hashSHA384 = this.GetSHA384(fileName);
                    break;
                case HashType.SHA512:
                    this.hashSHA512 = this.GetSHA512(fileName);
                    break;
            }
        }


        //property
        public string HashMD5
        {
            get { return this.hashMD5; }
        }

        public string HashSHA1
        {
            get { return this.hashSHA1; }
        }

        public string HashSHA256
        {
            get { return this.hashSHA256; }
        }

        public string HashSHA512
        {
            get { return this.hashSHA512; }
        }


        //method
        private void Initialize()
        {
            hashMD5 = String.Empty;
            hashSHA1 = String.Empty;
            hashSHA256 = String.Empty;
            hashSHA384 = String.Empty;
            hashSHA512 = String.Empty;
        }

        public string GetMD5(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("The argument filename is not initialized.");
            else if (!File.Exists(fileName)) 
                throw new FileNotFoundException("The file does not exist." + Environment.NewLine + "Filename: " + fileName);

            using (MD5 hash = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", String.Empty);
                } 
            }
        }

        public string GetSHA1(string fileName)
        {
            using (var hash = System.Security.Cryptography.SHA1.Create())
            {
                using (var stream = System.IO.File.OpenRead(fileName))
                {
                    return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", String.Empty);
                }
            }
        }

        public string GetSHA256(string fileName)
        {
            using (var hash = System.Security.Cryptography.SHA256.Create())
            {
                using (var stream = System.IO.File.OpenRead(fileName))
                {
                    return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", String.Empty);
                }
            }
        }

        public string GetSHA384(string fileName)
        {
            using (var hash = System.Security.Cryptography.SHA384.Create())
            {
                using (var stream = System.IO.File.OpenRead(fileName))
                {
                    return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", String.Empty);
                }
            }
        }

        public string GetSHA512(string fileName)
        {
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                using (var stream = System.IO.File.OpenRead(fileName))
                {
                    return BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }
    }
}
