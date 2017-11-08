using System.IO;


namespace Jasarsoft.Columbia
{
    internal class Library
    {
        private readonly string[] name;
        private readonly string[] hash;


        public Library()
        {
            name = new string[] 
            {
                //application
                @".\columbia.exe",
                @".\host-cs.exe",
                @".\columbia.exe.config",
                
                //MySql Library
                @".\MySql.Data.dll",
                @".\MySql.Web.dll",
                
                //Syncfusion Library
                @".\Syncfusion.Grid.Base.dll",
                @".\Syncfusion.Grid.Windows.dll",
                @".\Syncfusion.Grid.Windows.XmlSerializers.dll",
                @".\Syncfusion.Shared.Base.dll",
                @".\Syncfusion.Shared.Windows.dll",
                @".\Syncfusion.SpellChecker.Base.dll",
                @".\Syncfusion.Tools.Base.dll",
                @".\Syncfusion.Tools.Windows.dll",
                
                //Google Drive Api Library
                @".\Google.Apis.dll",
                @".\Google.Apis.Auth.dll",
                @".\Google.Apis.Auth.PlatformServices.dll",
                @".\Google.Apis.Core.dll",
                @".\Google.Apis.Drive.v2.dll",
                @".\Google.Apis.PlatformServices.dll",
                
                //BouncyCastle Library
                @".\BouncyCastle.Crypto.dll",
                
                //Log4New Library
                @".\log4net.dll",
                
                //Newtonsoft Library
                @".\Newtonsoft.Json.dll",
                
                //Dino Chiesa Library
                @".\Zlib.Portable.dll",
                
                //Microsoft Library
                @".\stdole.dll",
                @".\EnvDTE.dll",
                @".\Microsoft.Threading.Tasks.dll",
                @".\Microsoft.Threading.Tasks.Extensions.dll",
                @".\Microsoft.Threading.Tasks.Extensions.Desktop.dll",
                @".\Microsoft.Vsa.dll",
                @".\System.Data.dll",
                @".\System.Deployment.dll",
                @".\System.Design.dll",
                @".\System.dll",
                @".\System.Drawing.Design.dll",
                @".\System.Drawing.dll",
                @".\System.IO.dll",
                @".\System.Net.dll",
                @".\System.Net.Http.dll",
                @".\System.Net.Http.Extensions.dll",
                @".\System.Net.Http.Primitives.dll",
                @".\System.Net.Http.WebRequest.dll",
                @".\System.Runtime.dll",
                @".\System.Runtime.Serialization.Formatters.Soap.dll",
                @".\System.Threading.Tasks.dll",
                @".\System.Windows.Forms.dll",
                @".\System.Xml.dll",

#if DEBUG
                //application
                @".\columbia.application",
                @".\columbia.exe.manifest",
                @".\columbia.pdb",
                @".\columbia.xml",
                @".\columbia.vshost.application",
                @".\columbia.vshost.exe",
                @".\columbia.vshost.exe.config",
                @".\columbia.vshost.exe.manifest",
                @".\app.publish\columbia.exe",
                @".\host-cs.pdb",
                @".\host-cs.xml",
                                
                //MySql Library
                @".\MySql.Data.pdb",
                @".\MySql.Data.xml",
                @".\MySql.Web.pdb",
                @".\MySql.Web.xml",
                
                //Syncfusion Library
                @".\Syncfusion.Shared.Base.pdb",
                @".\Syncfusion.Shared.Base.xml",
                @".\Syncfusion.Grid.Windows.pdb",
                @".\Syncfusion.Grid.Windows.xml",
                @".\Syncfusion.Shared.Base.pdb",
                @".\Syncfusion.Shared.Base.xml",
                @".\Syncfusion.Shared.Windows.pdb",
                @".\Syncfusion.Shared.Windows.xml",
                @".\Syncfusion.SpellChecker.Base.pdb",
                @".\Syncfusion.SpellChecker.Base.xml",
                @".\Syncfusion.Tools.Base.pdb",
                @".\Syncfusion.Tools.Base.xml",
                @".\Syncfusion.Tools.Windows.pdb",
                @".\Syncfusion.Tools.Windows.xml",
                
                //Google Drive Api Library
                @".\Google.Apis.pdb",
                @".\Google.Apis.xml",
                @".\Google.Apis.Auth.pdb",
                @".\Google.Apis.Auth.xml",
                @".\Google.Apis.Auth.PlatformServices.pdb",
                @".\Google.Apis.Auth.PlatformServices.xml",
                @".\Google.Apis.Core.pdb",
                @".\Google.Apis.Core.xml",
                @".\Google.Apis.Drive.v2.pdb",
                @".\Google.Apis.Drive.v2.xml",
                @".\Google.Apis.PlatformServices.pdb",
                @".\Google.Apis.PlatformServices.xml",
                
                //BouncyCastle Library
                @".\BouncyCastle.Crypto.pdb",
                @".\BouncyCastle.Crypto.xml",
                
                //Log4New Library
                @".\log4net.pdb",
                @".\log4net.xml",
                
                //Newtonsoft Library
                @".\Newtonsoft.Json.pdb",
                @".\Newtonsoft.Json.xml",
                
                //Dino Chiesa Library
                @".\Zlib.Portable.pdb",
                @".\Zlib.Portable.xml",
                
                //Microsoft Library
                @".\stdole.pdb",
                @".\stdole.xml",
                @".\EnvDTE.pdb",
                @".\EnvDTE.xml",
                @".\Microsoft.Threading.Tasks.pdb",
                @".\Microsoft.Threading.Tasks.xml",
                @".\Microsoft.Threading.Tasks.Extensions.pdb",
                @".\Microsoft.Threading.Tasks.Extensions.xml",
                @".\Microsoft.Threading.Tasks.Extensions.Desktop.pdb",
                @".\Microsoft.Threading.Tasks.Extensions.Desktop.xml",
                @".\System.Data.pdb",
                @".\System.Data.xml",
                @".\System.Deployment.pdb",
                @".\System.Deployment.xml",
                @".\System.Design.pdb",
                @".\System.Design.xml",
                @".\System.pdb",
                @".\System.xml",
                @".\System.Drawing.Design.pdb",
                @".\System.Drawing.Design.xml",
                @".\System.Drawing.pdb",
                @".\System.Drawing.xml",
                @".\System.IO.pdb",
                @".\System.IO.xml",
                @".\System.Net.pdb",
                @".\System.Net.xml",
                @".\System.Net.Http.pdb",
                @".\System.Net.Http.xml",
                @".\System.Net.Http.Extensions.pdb",
                @".\System.Net.Http.Extensions.xml",
                @".\System.Net.Http.Primitives.pdb",
                @".\System.Net.Http.Primitives.xml",
                @".\System.Net.Http.WebRequest.pdb",
                @".\System.Net.Http.WebRequest.xml",
                @".\System.Runtime.pdb",
                @".\System.Runtime.xml",
                @".\System.Runtime.Serialization.Formatters.Soap.pdb",
                @".\System.Runtime.Serialization.Formatters.Soap.xml",
                @".\System.Threading.Tasks.pdb",
                @".\System.Threading.Tasks.xml",
                @".\System.Windows.Forms.pdb",
                @".\System.Windows.Forms.xml",
                @".\System.Xml.pdb",
                @".\System.Xml.xml",
#endif
            };

            hash = new string[]
            {
                //application
                "", //@".\columbia.exe",
                "47E1F9B671A35DCD6077C2B4DF2D4992", //@".\host-cs.exe",
                "94CA33F20B4130229C5419FC9F67E871", //@".\columbia.exe.config",
                                
                //MySql Library
                "17B4BDDED1D6D8F5B02D6A60C8BADF27", //@".\MySql.Data.dll",
                "9430D3A9517A5D9D001E0CA2E9523FD1", //@".\MySql.Web.dll",
                
                //Syncfusion Library
                "7445A8343619D11DAB4F42746BD254C7", //@".\Syncfusion.Grid.Base.dll",
                "32BD976EE884469C50F882C845924489", //@".\Syncfusion.Grid.Windows.dll",
                "EC538051A1C3EFDBF45140AA031EEA62", //@".\Syncfusion.Grid.Windows.XmlSerializers.dll",
                "8EDDBBF5761F2B5937E782F921115723", //@".\Syncfusion.Shared.Base.dll",
                "8E803716F4ED96541D9E8B249CBCD4C8", //@".\Syncfusion.Shared.Windows.dll",
                "4A0800999DAD19353462FB95A099FA61", //@".\Syncfusion.SpellChecker.Base.dll",
                "DA2E46952F16A8A369669FED557F383F", //@".\Syncfusion.Tools.Base.dll",
                "78BE0DD72ED2581368DADE4CB78261F3", //@".\Syncfusion.Tools.Windows.dll",
                
                //Google Drive Api Library
                "24536D108D707474C717EB6C96B54926", //@".\Google.Apis.dll",
                "D3DE0F000088713370A09D82343A23C4", //@".\Google.Apis.Auth.dll",
                "9E5C27F6F05BFB27BC0EEEB5853782A0", //@".\Google.Apis.Auth.PlatformServices.dll",
                "5EF7A3AECE5F249C87662F716114CE51", //@".\Google.Apis.Core.dll",
                "FA0EA7B74E630575A2CB0CFD5C2223CF", //@".\Google.Apis.Drive.v2.dll",
                "11807CE5ACD729C96F72AD1828F437AB", //@".\Google.Apis.PlatformServices.dll",
                
                //BouncyCastle Library
                "D2174BE3B3B7F1DF738795E924ACD952", //@".\BouncyCastle.Crypto.dll",
                
                //Log4New Library
                "31E73AF0734F4328879C1D96CDC4658C", //@".\log4net.dll",
                
                //Newtonsoft Library
                "ABD9C387AABA000866F8CCB82313635F", //@".\Newtonsoft.Json.dll",
                
                //Dino Chiesa Library
                "0068F1CF5939866A00E649CF169EFF20", //@".\Zlib.Portable.dll",
                
                //Microsoft Library
                "28B577084E20032953ADC31F27B1A81D", //@".\stdole.dll",
                "F4B84B1EB2711575D6AB68576A1C9027", //@".\EnvDTE.dll",
                "D01819BFE03222DFA9E35A36555B6B6C", //@".\Microsoft.Threading.Tasks.dll",
                "6AA2393FF1FDE1A61D0CF51730428F74", //@".\Microsoft.Threading.Tasks.Extensions.dll",
                "E548A93D16964E52868C47CEF1C98F2E", //@".\Microsoft.Threading.Tasks.Extensions.Desktop.dll",
                "4B66453C0EF2C4191BFBB707220AFE49", //@".\Microsoft.Vsa.dll",
                "37679FCF495388EE6503CC213C7AAD96", //@".\System.Data.dll",
                "D9A0A3618E00AF5A0F0172871D408ACC", //@".\System.Deployment.dll",
                "3ECF91D24B93EA19083288BC86A4C3EA", //@".\System.Design.dll",
                "FD6BD8930699F8852B32BD86E6CE04A9", //@".\System.dll",
                "5C1F14A9B5D1473CACD9B6707B772730", //@".\System.Drawing.Design.dll",
                "36FAB23D648D9F7D772F312CBD783DBA", //@".\System.Drawing.dll",
                "D552DE7D39179B914DB7CC2DBDD005C2", //@".\System.IO.dll",
                "82C421F669774FC14A96691D0FB561CD", //@".\System.Net.dll",
                "3002E884C5C15A15B68EAEF3C62FF254", //@".\System.Net.Http.dll",
                "7F86A47ACD4D810AD673AF81369F2F26", //@".\System.Net.Http.Extensions.dll",
                "018841345CFBF45EDA4CD1ADB74FD68B", //@".\System.Net.Http.Primitives.dll",
                "1925E1654510EE0914FF3360C6C94765", //@".\System.Net.Http.WebRequest.dll",
                "8E4E0EA396B5452BED54E6888CB07CA1", //@".\System.Runtime.dll",
                "DCEDE06F6364869AE39220195ED7AF63", //@".\System.Runtime.Serialization.Formatters.Soap.dll",
                "85F6F590B5C4B8C7253E9C403C9BE607", //@".\System.Threading.Tasks.dll",
                "7D65996C70CF024823A16A2C62BE370A", //@".\System.Windows.Forms.dll",
                "CAB6CACF2236E74B3845789C5FD1E6BD", //@".\System.Xml.dll",
            };
        }

        public string[] Name
        {
            get { return this.name; }
        }

        public string[] Hash
        {
            get { return this.hash; }
        }

        public bool Check()
        {
            foreach (string name in this.name)
            {
                if (!File.Exists(name))
                {
                    //System.Windows.Forms.MessageBox.Show(name);
                    return false;
                }
                    
            }

            return true;
        }

        public bool Valid()
        {
            if (!this.Check()) return false;

            for (int i = 1; i < name.Length; i++ )
            {
                if (HashFile.GetMD5(this.name[i]) != this.hash[i])
                {
                    System.Windows.Forms.MessageBox.Show(name[i]);
                    return false;
                }
                    
            }

            return true;   
        }
    }
}
