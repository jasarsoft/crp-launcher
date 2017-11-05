using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace Jasarsoft.Columbia.Library
{
    public class MySql
    {
        private string query;
        private MySqlConnection mysql;


        public MySql()
        {

        }


        public bool Connect()
        {
            BaseConst cb = new BaseConst();
            PrivateData pd = new PrivateData();

            query = String.Format("{0}={1};{2}={3};{4}={5};{6}={7};",
                                        cb.Server, pd.Server,
                                        cb.Username, pd.Username,
                                        cb.Password, pd.Password,
                                        cb.Database, pd.Database);

            this.mysql = new MySqlConnection(query);
            
            if (this.mysql != null)
                return true;
            else
                return false;
        }

        public bool Open()
        {
            try
            {
                this.mysql.Open();
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
                this.mysql.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public List<string> Read(string tableName, string columnName)
        {
            List<string> list = new List<string>();
            string query = String.Format("SELECT * FROM '{0}'", tableName);

            MySqlCommand sqlcmd = new MySqlCommand(query, mysql);
            MySqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(reader[columnName].ToString());
            }
            reader.Close();

            return list;
        }
    }
}
