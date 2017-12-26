using System;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Jasarsoft.Columbia
{
    internal class ColumbiaUpdate
    {
        private readonly string fileName;
        private readonly string pathName;


        public ColumbiaUpdate()
        {
            this.fileName = "update-cs.exe";
            this.pathName = string.Format("{0}\\Columbia State", Path.GetTempPath());
        }


        public string FileName
        {
            get { return this.fileName; }
        }

        public string PathName
        {
            get { return this.pathName; }
        }

        public string FullName
        {
            get
            {
                return String.Format("{0}\\{1}", this.pathName, this.fileName);
            }
        }


        public bool DownloadFile()
        {
            Network net = new Network();
            string link = "https://columbia-state.com/launcher/update-cs.exe";

            if(!net.Available())
            {
                throw new Exception("Vaša internet konekcija ne radi ili je trenutno prekinuta.");
            }

            if (!Directory.Exists(this.pathName))
            {
                Directory.CreateDirectory(this.pathName);
            }
                
            try
            {
                using (WebClient client = new WebClient())
                {
                    var url = new Uri(link);
                    client.DownloadFile(url, FullName);
                }
            }
            catch (Exception)
            {
                throw new Exception("Ažuriranje trenutno ne može biti dohvaćeno sa našeg poslužitelja.");
            }

            return File.Exists(FullName);
        }

        public bool RunFile()
        {
            if(File.Exists(FullName))
            {
                //Process process = new Process();
                //process.StartInfo.FileName = "update-cs.exe";
                //process.StartInfo.Arguments = "/VERYSILENT";
                //process.StartInfo.WorkingDirectory = temp;
                //process.StartInfo.UseShellExecute = true;

                Process.Start(FullName);
                return true;
            }

            return false;
        }
    }
}
