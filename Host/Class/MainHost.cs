using System;
using System.IO;
using System.Windows.Forms;

namespace Jasarsoft.Columbia.Host
{
    static class MainHost
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StringCipher cipher = new StringCipher();
            string filename = "5rtZ18wWFTYO/vKvHJRZadRMQ8wumQfrPKfx6VniCZ5m+J1cH7fsfWlIi+hII2N6nmaepvnc8f2DGt31FcOflOtG8Gtj1t3v9rh8mDs7SA2L7WcR7EdH2ZW4V3jlUrLK"; ////Syncfusion.Shared.Base.dll

            if (!File.Exists(cipher.Decrypt(filename))) 
            {
                MessageTitle title = new MessageTitle();
                string message = "Columbia State Host aplkacija je neovlašteno i izolovano pokrenuta.\n" +
                                 "Aplikacija ne može biti nastaljvena te se iz sigurnostih razloga gasi.";
                MessageBox.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hash = "JlPgBQEZ9//KCcODzs9BP/frWJ3CQYhCizP505rupUQmXUvxaHJS2oRueP9Af78j0A+A4uK0m4h0qAsMVtGv2l5vjBAr1AavGuYekiNm4oydBa8afH4wy/G4GOakoz/enFUMEStUw6ivfHY8sG/t5bbRQfurqIlc99Td2Kl8UPk="; //8643C7CF3B6412682F487CB55859CB4D
            if(HashFile.GetMD5(cipher.Decrypt(filename)) != cipher.Decrypt(hash))
            {
                MessageTitle title = new MessageTitle();
                string message = "Columbia State Host aplikacijska biblioteka je neopoznata i strana.\n" +
                                 "Aplikacija ne može biti nastaljvena te se iz sigurnostih razloga gasi.";
                MessageBox.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
