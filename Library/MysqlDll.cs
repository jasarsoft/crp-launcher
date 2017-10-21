using System;
using System.IO;

namespace Jasarsoft.Columbia.Library
{
    internal class MysqlDll
    {
        private struct DllName
        {
            public const string mysqlData = "MySql.Data.dll";
            public const string mysqlWeb = "MySql.Web.dll";
        }

        private struct HashValue
        {
            public const string mysqlData = "7D70B3192B64539739F5353A4BE3DA4C";
            public const string mysqlWeb = "10599DF5A694765ABEF103C5C4144887";
        }


        public bool Check()
        {
            if (!File.Exists(DllName.mysqlData)) return false;
            if (!File.Exists(DllName.mysqlWeb)) return false;

            return true;
        }

        public bool Valid()
        {
            if (!this.Check()) return false;

            HashFile hash = new HashFile();

            if (hash.GetMD5(DllName.mysqlData) != HashValue.mysqlData) return false;
            if (hash.GetMD5(DllName.mysqlWeb) != HashValue.mysqlWeb) return false;

            return true;
        }
    }
}
