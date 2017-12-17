using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasarsoft.Columbia.Update
{
    internal class PrivateData
    {
        private StringCipher cipher;
        private readonly string mode;
        private readonly string link;
        private readonly string archive;
        
        public PrivateData()
        {
            cipher = new StringCipher();
            //mode = "silent14"
            mode = "wDucEZSVzzQx8wDCJLWrT9OIvvD8P7fXJWo3rBvePYDIat2RZ1CsErOsHCvvqyqfDm41p9b+Koad172kPs0UUIdRFtm0Vf2G9hRH1Z8M4sHcwH3WLFcrB5EKXcYmSkag";
            //link = "https://columbia-state.com/launcher-files.xml";
            link = "nbZmYr7jvT5PizpmGzI2HNN08YmDWP7DTjtTqSKh9y1lYwVPF3AS7wGdamKwjp5OePV7j+3AY0pMbUUE22hhUj3P155zB1++wip2K0GJO5ra+S1TbT+vaUZVgcmHrZbC6Ozfi07fQ6PY6nn6hQaaJyi9J3AaprEbOncdCy9YPc0=";
            //archive = ".zip";
            archive = "KNlp73VxSNGk0e8TWqdopHozwPhdgMd63f3pKVTikkNJRNN7xnGQ1q8BDC8Of+IKWUd3UoUhS6D4pmNwixK0ML8xq5TQ6s5vCAQNolQJIi1z4GoXlTLfOG/h7Irp3p2O";
        }

        public string Mode
        {
            get { return cipher.Decrypt(mode); }
        }

        public string Link
        {
            get { return cipher.Decrypt(link); }
        }

        public string Archive
        {
            get { return cipher.Decrypt(archive); }
        }
    }
}
