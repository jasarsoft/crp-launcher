using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Jasarsoft.Columbia.Library
{
    public class BaseFile
    {
        private List<bool> valid;
        private List<string> name;
        private List<string> path;
        private List<long> size;
        private List<string> hash;
        private List<string> link;

        private MySqlConnection mysql;

        public BaseFile()
        {
            this.valid = new List<bool>();
            this.name = new List<string>();
            this.size = new List<long>();
            this.hash = new List<string>();
            this.link = new List<string>();
        }

        public List<bool> Valid
        {
            get { return this.valid; }
        }

        public List<string> Name
        {
            get { return this.name; }
        }

        public List<string> Path
        {
            get { return this.path; }
        }

        public List<long> Size
        {
            get { return this.size; }
        }

        public List<string> Hash
        {
            get { return this.hash; }
        }

        public List<string> Link
        {
            get { return this.link; }
        }

        public bool Connect()
        {
            ConstBase cb = new ConstBase();
            PrivateData pd = new PrivateData();

            string query = String.Format("{0}={1};{2}={3};{4}={5};{6}={7};",
                                        cb.Server, pd.Server,
                                        cb.Username, pd.Username,
                                        cb.Password, pd.Password,
                                        cb.Database, pd.Database);

            try
            {
                mysql = new MySqlConnection(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            //mysql = new MySqlConnection(query);

            //if (mysql == null)
            //    return false;
            //else
            //    return true;
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

        public bool Read()
        {
            BaseColumn column = new BaseColumn();
            
            this.valid = new List<bool>();
            this.name = new List<string>();
            this.path = new List<string>();
            this.hash = new List<string>();            
            this.size = new List<long>();
            this.link = new List<string>();

            if (!this.Connect()) return false;

            try
            {
                mysql.Open();
                string query = "SELECT * FROM files";
                MySqlCommand sqlcmd = new MySqlCommand(query, mysql);
                MySqlDataReader reader = sqlcmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[column.Valid].ToString() == "0")
                        this.valid.Add(false);
                    else
                        this.valid.Add(true);
                    //this.valid.Add(Boolean.Parse(reader[column.Valid].ToString()));
                    this.name.Add(reader[column.Name].ToString());
                    this.path.Add(reader[column.Path].ToString());
                    this.size.Add(Int64.Parse(reader[column.Size].ToString()));
                    this.hash.Add(reader[column.Hash].ToString());
                    this.link.Add(reader[column.Link].ToString());
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
