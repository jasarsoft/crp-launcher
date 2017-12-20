using System;
using MySql.Data.MySqlClient;


namespace Jasarsoft.Columbia
{
    public class MySqlLauncher
    {
        private string hashLauncher;
        private string hashHost;
        private string hashUpdate;

        private MySqlConnection mysql;


        //default constructor
        public MySqlLauncher()
        {
            this.hashLauncher = "";
            this.hashHost = "";
            this.hashUpdate = "";          
        }


        //properties
        public string HashLauncher
        {
            get { return this.hashLauncher; }
        }

        public string HashHost
        {
            get { return this.hashHost; }
        }    

        public string HashUpdate
        {
            get { return this.hashUpdate; }
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
                
                query = "SELECT * FROM `launcher`";
                MySqlCommand sqlcmd = new MySqlCommand(query, mysql);
                MySqlDataReader reader = sqlcmd.ExecuteReader();

                while (reader.Read())
                {
                    this.hashLauncher = reader["hash_launcher"].ToString();
                    this.hashHost = reader["hash_host"].ToString();
                    this.hashUpdate = reader["hash_update"].ToString();
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
