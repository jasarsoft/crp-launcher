using System;
using MySql.Data.MySqlClient;


namespace Jasarsoft.Columbia
{
    public class MySqlLauncher
    {
        private string hash;

        private MySqlConnection mysql;


        //default constructor
        public MySqlLauncher()
        {
            this.hash = "";            
        }


        //properties
        public string Hash
        {
            get { return this.hash; }
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
                    this.hash = reader["hash"].ToString();
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
