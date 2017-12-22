using System;
using MySql.Data.MySqlClient;


namespace Jasarsoft.Columbia
{
    public class ServerBase
    {
        private bool locked;
        private bool working;
        private string address;
        private string password;
        private string teamspeak;
        private string website;
        private string forum;
        private string facebook;
        private string youtube;
        private string email;

        private MySqlCommand sqlCommand;
        private MySqlConnection sqlConnection;
        

        private struct ServerColumn
        {
            public const string Lock = "lock";
            public const string Work = "work";
            public const string Address = "address";
            public const string Password = "password";
            public const string Teamspeak = "teamspeak";
            public const string Website = "website";
            public const string Forum = "forum";
            public const string Facebook = "facebook";
            public const string Youtube = "youtube";
            public const string Email = "email";
        }

        //properties
        public bool Locked
        {
            get { return this.locked; }
        }

        public bool Working
        {
            get { return this.working; }
        }

        public string Address
        {
            get { return this.address; }
        }

        public string Password
        {
            get { return this.password; }
        }

        public string Teamspeak
        {
            get { return this.teamspeak; }
        }

        public string Website
        {
            get { return this.website; }
        }

        public string Forum
        {
            get { return this.forum; }
        }

        public string Facebook
        {
            get { return this.facebook; }
        }

        public string YouTube
        {
            get { return this.youtube; }
        }

        public string Email
        {
            get { return this.email; }
        }


        //methods
        public bool Read()
        {
            BaseConst cb = new BaseConst();
            PrivateData pd = new PrivateData();

            string query = String.Format("{0}={1};{2}={3};{4}={5};{6}={7};",
                                        cb.Server, pd.Server,
                                        cb.Username, pd.Username,
                                        cb.Password, pd.Password,
                                        cb.Database, pd.Database);

            try
            {
                sqlConnection = new MySqlConnection(query);
                sqlConnection.Open();
                
                query = "SELECT * FROM `server` WHERE `id`=1 LIMIT 1";
                sqlCommand = new MySqlCommand(query, sqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();

                reader.Read();

                this.locked = Boolean.Parse(reader[ServerColumn.Lock].ToString());
                this.working = Boolean.Parse(reader[ServerColumn.Work].ToString());
                this.address = reader[ServerColumn.Address].ToString();
                this.password = reader[ServerColumn.Password].ToString();
                this.teamspeak = reader[ServerColumn.Teamspeak].ToString();
                this.website = reader[ServerColumn.Website].ToString();
                this.forum = reader[ServerColumn.Forum].ToString();
                this.facebook = reader[ServerColumn.Facebook].ToString();
                this.youtube = reader[ServerColumn.Youtube].ToString();
                this.email = reader[ServerColumn.Email].ToString();
                
                reader.Close();
                sqlConnection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
