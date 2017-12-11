using System;

namespace Jasarsoft.MySQLInserter
{
    public class PrivateData
    {
        StringCipher sc;

        private readonly string server;
        private readonly string username;
        private readonly string password;
        private readonly string database;


        //default constructor
        public PrivateData()
        {
            this.sc = new StringCipher();

            this.server = "3UfppWB0ucOjRetAb5OaOucmVygt+jxQiK5IB2lFWmSYuOTRvU/uRtClidM6gi8rrXkdXy6VIKVX/Gk4qDHFgFxkoUAM0B9+v9+erWnle0hRKA8iaVNeahRTsdnOekHh";
            this.username = "yNjRUvVuhMihO++/cNZjS7RuOIbiRKYUCjDRjPdqO6Y6f3/uF0qlp6qRmyBidvFOfTRz1iScixKj7Qh1j23Yl6bHQRaCru9IEHj0OEMP3H/NzDqXeclhZ8ud8FpWd0Mn";
            this.password = "dZAS6hS/E4twZDRaqwqIcw/ZgZkPlK30U96AkKrnt6xaio+cvPL79YEb0FvD95Pap+KEAMHQjiPBDasQ2GRTG3YXmhfUO0v6qKHnXcKG2zVWjo63LX1rEw75x3cLJnk3";
            this.database = "rm+fso8TpObqsDCpyejLqorsVZfoaEkUz+hiFAcb9oDEmqi9lyrh1113YuLcrToF9YsNfOO65he48EjU6iU4Bxgzx3Mnq9Gt/vN5n4BcX+iCR7myN6veua4/PTGBkWK7";
        }

        //property
        public string Server
        {
            get { return this.sc.Decrypt(this.server); }
        }

        public string Username
        {
            get { return this.sc.Decrypt(this.username); }
        }

        public string Password
        {
            get { return this.sc.Decrypt(this.password); }
        }

        public string Database
        {
            get { return this.sc.Decrypt(this.database); }
        }
    }
}
