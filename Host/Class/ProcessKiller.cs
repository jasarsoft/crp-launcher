using System;
using System.Diagnostics;


namespace Jasarsoft.Columbia.Host
{
    public class ProcessKiller
    {
        private readonly string samp;
        private readonly string gtasa;
        private readonly string sampcs;
        private readonly string hostcs;
        
        public ProcessKiller()
        {
            this.samp = "gtasamp";
            this.gtasa = "gtasa";
            this.sampcs = "columbia";
            this.hostcs = "host-cs";
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

        public void GtaSa()
        {
            this.Killer(this.gtasa);
        }

        public void SampColumbia()
        {
            this.Killer(this.sampcs);
        }

        public void HostColumbia()
        {
            this.Killer(this.hostcs);
        }
    }
}
