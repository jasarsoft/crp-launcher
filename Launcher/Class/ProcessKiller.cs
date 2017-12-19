using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace Jasarsoft.Columbia
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


        private void Kill(object processName)
        {
#if TRACE
            Trace.TraceInformation("Ulaz u metodu Killer; ProcessKiller;");
#endif
            if (processName == null)
            {
                Trace.TraceError("Greška u argumentu processName; ProcessKiller.Kill();");
                throw new ArgumentNullException("ProcessKiller.Kill(); Argument 'processName' ne moze biti null.");
            }

            Process[] allProcess = Process.GetProcessesByName(Convert.ToString(processName));
            if (allProcess.Length > 0)
            {
                foreach (Process tempProcess in allProcess)
                {
                    do
                    {
                        tempProcess.Kill();
                        tempProcess.WaitForExit();
#if TRACE
                        Trace.TraceInformation("Process {0} je ubijen.", tempProcess.ProcessName);
#endif
                    } while (tempProcess.HasExited == false);
                }
            }
#if TRACE
            else
                Trace.TraceInformation("ProcessKiller.Kill(); Nema processa: {0}", processName);
#endif

            //dodatna provjera
            allProcess = Process.GetProcessesByName(Convert.ToString(processName));
            if (allProcess.Length > 0)
            {
                string message = "Zatvaranje procesa '" + processName + "' nije uspješno izvršeno.\n" +
                                 "Kontaktirajte administraciju na forumu o vašoj pogrešsci";
                throw new MethodAccessException(message);
            }
        }

        public void Samp()
        {
            Thread thread = new Thread(Kill);
            thread.Start(samp);
#if TRACE
            if (thread.IsAlive) Trace.TraceInformation("ProcessKiller.Samp(); Thread.Start(); OK");
#endif
        }

        public void SanAndreas()
        {
            Thread thread = new Thread(Kill);
            thread.Start(this.gta);
        }

        public void Columbia()
        {
            Thread thread = new Thread(Kill);
            thread.Start(this.columbia);
        }

        public void Host()
        {
            Thread thread = new Thread(Kill);
            thread.Start(this.host);
        }
    }
}
