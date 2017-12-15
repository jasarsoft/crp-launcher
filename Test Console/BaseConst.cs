using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Console
{
    public class BaseConst
    {
        private readonly string server;
        private readonly string username;
        private readonly string password;
        private readonly string database;


        //default constructor
        public BaseConst()
        {
            this.server = "SERVER";
            this.username = "USERNAME";
            this.password = "PASSWORD";
            this.database = "DATABASE";
        }


        //properties
        public string Server
        {
            get { return this.server; }
        }

        public string Username
        {
            get { return this.username; }
        }

        public string Password
        {
            get { return this.password; }
        }

        public string Database
        {
            get { return this.database; }
        }
    }
}
