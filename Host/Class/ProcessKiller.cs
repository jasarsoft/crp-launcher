using System;
using System.Diagnostics;


namespace Jasarsoft.Columbia.Host
{
    public class ProcessKiller
    {
        private readonly string gta;
        private readonly string samp;
        private readonly string host;
        private readonly string columbia;
        

        public ProcessKiller()
        {
            this.gta = "gtasa";
            this.samp = "gtasamp";
            this.host = "host-cs";
            this.columbia = "columbia";
        }


        private void Killer(string processName)
        {
            Process[] allProcess = Process.GetProcessesByName(processName);
            if (allProcess.Length > 0)
            {
                foreach (Process tempProcess in allProcess)
                {
                    do
                    {
                        tempProcess.Kill();
                        tempProcess.WaitForExit();
                    } while (tempProcess.HasExited == false);
                }
            }

            //provjera
            allProcess = Process.GetProcessesByName(processName);
            if (allProcess.Length > 0)
            {
                string msg = "Zatvaranje procesa '" + processName + "' nije uspješno izvršeno.\n";
                msg += "Kontaktirajte administraciju na forumu o vašoj pogrešsci";
                throw new MethodAccessException(msg);
            }
            
        }

        public void Samp()
        {
            this.Killer(this.samp);
        }

        public void SanAndreas()
        {
            this.Killer(this.gta);
        }

        public void Columbia()
        {
            this.Killer(this.columbia);
        }

        public void Host()
        {
            this.Killer(this.host);
        }
    }
}
