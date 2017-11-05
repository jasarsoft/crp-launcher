using System;
using MySql.Data.MySqlClient;


namespace Jasarsoft.Columbia.Library
{
    public class Server
    {
        private bool locked;
        private bool working;
        private string address;
        private string password;
        private string teamspeak;
        private string website;
        private string forum;
        private string youtube;
        private string facebook;
        
        
        private MySqlConnection mysql;


        //default constructor
        public Server()
        {
            this.address = "37.187.78.206:7721";
            this.password = "";
            this.teamspeak = "149.202.88.8:9916";
            this.website = "";
            this.forum = "http://novamahala.createaforum.com/";
            this.youtube = "https://www.youtube.com/channel/UCGw89-iuCv891SeFfN0qAzw";
            this.facebook = "https://facebook.com/NovaMahalaONEandONLY";  
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

        public string YouTube
        {
            get { return this.youtube; }
        }

        public string Facebook
        {
            get { return this.facebook; }
        }

        

        public bool Open()
        {
            try
            {
                mysql.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                mysql.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
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
                mysql = new MySqlConnection(query);
                mysql.Open();
                
                query = "SELECT * FROM `server`";
                MySqlCommand sqlcmd = new MySqlCommand(query, mysql);
                MySqlDataReader reader = sqlcmd.ExecuteReader();

                while (reader.Read())
                {
                    this.locked = Boolean.Parse(reader["lock"].ToString());
                    this.working = Boolean.Parse(reader["work"].ToString());
                    this.address = reader["address"].ToString();
                    this.password = reader["password"].ToString();
                    this.teamspeak = reader["teamspeak"].ToString();
                    this.website = reader["website"].ToString();
                    this.forum = reader["forum"].ToString();
                    this.youtube = reader["youtube"].ToString();
                    this.facebook = reader["facebook"].ToString();
                }

                reader.Close();
                mysql.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
