using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Jasarsoft.Columbia.Host
{
    static class MainHost
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            StringCipher cipher = new StringCipher();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string filename = "5rtZ18wWFTYO/vKvHJRZadRMQ8wumQfrPKfx6VniCZ5m+J1cH7fsfWlIi+hII2N6nmaepvnc8f2DGt31FcOflOtG8Gtj1t3v9rh8mDs7SA2L7WcR7EdH2ZW4V3jlUrLK"; ////Syncfusion.Shared.Base.dll

            if (!File.Exists(cipher.Decrypt(filename))) 
            {
                MessageTitle title = new MessageTitle();
                string message = "Columbia State Host aplikacija je neovlašteno i izolovano pokrenuta.\n" +
                                 "Učitavanje ne može biti nastavljeno te se iz sigurnostih razloga gasi.";
                MessageBox.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
#if TRACE
            Trace.TraceInformation("MainHost.Main(); File exist: {0}", cipher.Decrypt(filename));
#endif

            string hash = "JlPgBQEZ9//KCcODzs9BP/frWJ3CQYhCizP505rupUQmXUvxaHJS2oRueP9Af78j0A+A4uK0m4h0qAsMVtGv2l5vjBAr1AavGuYekiNm4oydBa8afH4wy/G4GOakoz/enFUMEStUw6ivfHY8sG/t5bbRQfurqIlc99Td2Kl8UPk="; //8643C7CF3B6412682F487CB55859CB4D
            if(HashFile.GetMD5(cipher.Decrypt(filename)) != cipher.Decrypt(hash))
            {
                MessageTitle title = new MessageTitle();
                string message = "Columbia State Host aplikacijska biblioteka je neopoznata i strana.\n" +
                                 "Učitavanje ne može biti nastavljeno te se iz sigurnostih razloga zaustavlja.";
                MessageBox.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
#if TRACE
            Trace.TraceInformation("MainHost.Main(); Hash equals; Value: {0}; Base: {1}", HashFile.GetMD5(cipher.Decrypt(filename)), cipher.Decrypt(hash));
#endif

            if (args.Length == 0)
            {
#if TRACE
                Trace.TraceInformation("MainHost.Main(); args.Lenght = 0;"); 
#endif
                Application.Run(new MainForm());                
            }
            else
            {
#if TRACE
                Trace.TraceInformation("MainHost.Main(); args.Lenght = {0};", args.Length);
#endif
                Application.Run(new MainForm(args[0]));
            }
        }
    }
}
