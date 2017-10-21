using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace Jasarsoft.Columbia.Library
{
    public class ProcessKiller
    {
        private readonly string samp;
        private readonly string gtasa;
        private readonly string sampnm;
        private readonly string hostnm;
        
        public ProcessKiller()
        {
            this.samp = "gtasamp";
            this.gtasa = "gtasa";
            this.sampnm = "columbia";
            this.hostnm = "host-cs";
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
        }

        public void Samp()
        {
            this.Killer(this.samp);
        }

        public void GtaSa()
        {
            this.Killer(this.gtasa);
        }

        public void SampNm()
        {
            this.Killer(this.sampnm);
        }

        public void HostNm()
        {
            this.Killer(this.hostnm);
        }
    }
}
