using System;
using System.IO;
using Microsoft.Win32;

namespace Jasarsoft.Columbia.Update
{
    public class UpdateRegistry
    {
        private string updateValue;
        private string versionValue;
        private readonly string subKey;

        private struct Value
        {
            public const string UPDATE_NAME = "update";
            public const string VERSION_NAME = "version";
        }


        //default constructor
        public UpdateRegistry()
        {
            this.updateValue = String.Empty;
            this.versionValue = String.Empty;
            this.subKey = @"Software\CSRP"; //this.subKey = @"Software\SAMP"; //original
        }

        public string UpdateValue
        {
            get { return this.updateValue; }
            set { this.updateValue = value; }
        }

        public string VersionValue
        {
            get { return this.versionValue; }
            set { this.versionValue = value; }
        }


        public bool Check()
        {
            try
            {
                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(subKey))
                {
                    if (rk != null)
                    {
                        object value;

                        value = rk.GetValue(Value.UPDATE_NAME, null);
                        if (value == null) return false;

                        value = rk.GetValue(Value.VERSION_NAME, null);
                        if (value == null) return false;

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Valid()
        {
            if (!this.Check()) return false;

            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(subKey))
            {
                if (rk != null)
                {
                    string path, name;

                    try { path = Convert.ToString(rk.GetValue(Value.UPDATE_NAME, null)); }
                    catch { return false; }
                    
                    try { name = Convert.ToString(rk.GetValue(Value.VERSION_NAME, null)); }
                    catch { return false; }

                    return true;
                }

                return false;
            }
        }

        public bool Create()
        {
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(subKey))
            {
                if (rk != null)
                {
                    rk.SetValue(Value.UPDATE_NAME, this.updateValue, RegistryValueKind.String);
                    rk.SetValue(Value.VERSION_NAME, this.versionValue, RegistryValueKind.String);

                    return true;
                }
            }

            return false;
        }

        public bool Read()
        {
            if (!this.Check()) return false;

            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(subKey))
            {
                if (rk != null)
                {
                    this.updateValue = Convert.ToString(rk.GetValue(Value.UPDATE_NAME, null));
                    this.versionValue = Convert.ToString(rk.GetValue(Value.VERSION_NAME, null));
                    return true;
                }
            }

            return false;
        }

        public bool Write()
        {
            if (!this.Check()) return false;

            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(subKey, true))
            {
                if (rk != null)
                {
                    rk.SetValue(Value.UPDATE_NAME, this.updateValue, RegistryValueKind.String);
                    rk.SetValue(Value.VERSION_NAME, this.versionValue, RegistryValueKind.String);

                    return true;
                }
            }

            return false;
        }

        public void Default()
        {
            this.updateValue = "1";
            this.VersionValue = "1.0.0.0";
        }
    }
}
