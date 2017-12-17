using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jasarsoft.Columbia.Update
{
    internal class DataBase
    {
        private StringCipher cipher;
        private List<ColumbiaFile> dataFiles;

        public DataBase()
        {
            //string name, hash;
            cipher = new StringCipher();
            dataFiles = new List<ColumbiaFile>();

            //BouncyCastle.Crypto.dll
            //name = cipher.Decrypt("8nc7RTDq58HIozzLHdktbqFHmdXSw8qA3W/nX1aa5EqbLQGD2YuCqZv3HhLD+o9ZMQNn/XoMrdaM/ic3DSbzfACYJnQ3CgqE1qlELHTBAEpkGGIXRBwd/91bjk7smjFm");
            //hash = cipher.Decrypt("97iFoWn2WbIZeU23XjZ+fsee0D6YN/WcVinylzO43LYzNemYuwAX250QJuwxxOxy1Z3LIB94qSDgirsuW1tXCOsmfi0tAUDAdmxROuGNl3PooH+u/e6FIHeZg5x4I/11svVjdoHS+htNyepetYp6nLRtKfjKoRCgnFGffSBq3pk=");

            /*dataFiles.Add(new ColumbiaFile("BouncyCastle.Crypto.dll", "3CF6BF0E0A27F3665EDD6362D137E4CC"));
            dataFiles.Add(new ColumbiaFile("EnvDTE.dll", "F7C91E98686039D661951455870ACAE6"));
            dataFiles.Add(new ColumbiaFile("Google.Apis.Auth.dll", "02C1D92B6913A7478C994A6C458FCC00"));
            dataFiles.Add(new ColumbiaFile("Google.Apis.Auth.PlatformServices.dll", "515A45E0F99B37AB6BCD620EFA966ED0"));
            dataFiles.Add(new ColumbiaFile("Google.Apis.Core.dll", "3D76DC7AA5BDF41340FAA5ADE49D5EDC"));
            dataFiles.Add(new ColumbiaFile("Google.Apis.dll", "1A47DED67D40B34A054EB430E32FBC10"));
            dataFiles.Add(new ColumbiaFile("Google.Apis.Drive.v2.dll", "B08912488B10753629DEA69591690226"));
            dataFiles.Add(new ColumbiaFile("Google.Apis.PlatformServices.dll", "C27E270D925E602C6D8D1E7A3B15CB0A"));
            dataFiles.Add(new ColumbiaFile("log4net.dll", "F64B733EAE44C8C66217386D5A0F2BF0"));
            dataFiles.Add(new ColumbiaFile("MySql.Data.dll", "17B4BDDED1D6D8F5B02D6A60C8BADF27"));
            dataFiles.Add(new ColumbiaFile("MySql.Web.dll", "9430D3A9517A5D9D001E0CA2E9523FD1"));
            dataFiles.Add(new ColumbiaFile("Newtonsoft.Json.dll", "A6BE9EFDAA744E9947F4EE18DE5423BD"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.Grid.Base.dll", "F2574B1454536883D84E6062C0756340"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.Grid.Windows.dll", "DAAA64C6236CE9900D3237E5CAF52632"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.Grid.Windows.XmlSerializers.dll", "697458A33F353F99786E029AF5095F77"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.Shared.Base.dll", "8643C7CF3B6412682F487CB55859CB4D"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.Shared.Windows.dll", "5514062515D5DAC5D4A35D18CC405514"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.SpellChecker.Base.dll", "3A1F7C772044B044D3E36583E98C43CC"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.Tools.Base.dll", "31AC464B4D5DDC8754F32E37D18E61A2"));
            dataFiles.Add(new ColumbiaFile("Syncfusion.Tools.Windows.dll", "68432EC316541CC1EDF8BEA3BDD1F7F9"));
            dataFiles.Add(new ColumbiaFile("System.Net.Http.Extensions.dll", "7F86A47ACD4D810AD673AF81369F2F26"));
            dataFiles.Add(new ColumbiaFile("System.Net.Http.Primitives.dll", "B43FD28DFEC4D3B81D7FA0F10A2FB62C"));
            dataFiles.Add(new ColumbiaFile("Zlib.Portable.dll", "0068F1CF5939866A00E649CF169EFF20"));*/
        }

        public List<ColumbiaFile> Files
        {
            get { return this.dataFiles; }
        }
    }
}
