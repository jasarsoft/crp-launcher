using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace Jasarsoft.Columbia.Library
{
    public class DataBase
    {
        private MySqlConnection mysql;

        private int lenght;

        private List<bool> valid;
        private List<string> name;
        private List<long> size;
        private List<string> hash;
        private List<string> link;


        public DataBase()
        {
            BaseConst cb = new BaseConst();
            PrivateData pd = new PrivateData();

            string query = String.Format("{0}={1};{2}={3};{4}={5};{6}={7};", 
                                        cb.Server, pd.Server,
                                        cb.Username, pd.Username,
                                        cb.Password, pd.Password,
                                        cb.Database, pd.Database);

            
            mysql = new MySqlConnection(query);
        }

        //public List<string>[] Data
        //{
        //    get { return data; }
        //}

        public int Lenght
        {
            get { return lenght; }
        }


        public List<bool> Valid
        {
            get { return this.valid; }
        }

        public List<string> Name
        {
            get { return this.name; }
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

        public string ErrorOpen
        {
            get
            {
                return String.Format("Pristupiti trenutno bazi podataka nije moguće.\nProvjerite vašu konekciju ili kontaktirajte administratora.");
            }
        }

        public string ErrorClose
        {
            get
            {
                return String.Format("Zatvoriti trenutno bazu podataka nije moguće.\nProvjerite vašu konekciju ili kontaktirajte administratora.");
            }
        }

        public bool OpenBase()
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
            //catch (MySqlException ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //catch (Exception)
            //{
            //    throw new Exception("Konekcija na bazu nije izvrsena.");
            //}

            //return false;
        }

        public bool CloseBase()
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

            //return false;
        }

        public bool Select()
        {
            string query = "SELECT * FROM `files`";
            BaseColumn column = new BaseColumn();

            this.valid = new List<bool>();
            this.hash = new List<string>();
            this.name = new List<string>();
            this.size = new List<long>();
            this.link = new List<string>();

            MySqlCommand sqlcmd = new MySqlCommand(query, mysql);
            MySqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader[column.Valid].ToString() == "0")
                    this.valid.Add(false);
                else
                    this.valid.Add(true);
                //this.valid.Add(Int32.Parse(reader[column.Valid].ToString()));
                //this.valid.Add(Boolean.Parse(reader[column.Valid].ToString().Replace("0", "false").Replace("1", "true")));
                this.name.Add(reader[column.Name].ToString());
                this.size.Add(Int64.Parse(reader[column.Size].ToString()));
                this.hash.Add(reader[column.Hash].ToString());
                this.link.Add(/*"https://drive.google.com/uc?export=download&id=" + */reader[column.Link].ToString());

                //data[0].Add(reader[column.Check].ToString());
                //data[1].Add(reader[column.Hash].ToString());
                //data[2].Add(reader[column.Name].ToString());
                //data[3].Add(reader[column.Path].ToString()/*.Replace(@"\", @"\\")*/);
                //data[4].Add(reader[column.Link].ToString());
            }

            reader.Close();
            return true;
        }

        //public void ReadServer()
        //{
        //    string query = "SELECT * FROM server";

        //    MySqlCommand sqlcmd = new MySqlCommand(query, mysql);
        //    MySqlDataReader reader = sqlcmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        Ser
        //    }
        //}

        public int Count()
        {
            //int count = -1;
            this.lenght = -1;
            string query = "SELECT Count(*) FROM files";

            MySqlCommand command = new MySqlCommand(query, mysql);
            //count = int.Parse(command.ExecuteScalar() + "");
            this.lenght = int.Parse(command.ExecuteScalar() + "");

            //return count;
            return this.lenght;
        }
    }
}
