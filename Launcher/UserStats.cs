using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MySql.Data.MySqlClient;

namespace Jasarsoft.Columbia
{
    internal class UserStats
    {
        private string ipAddress;
        private string userName;
        private int appRun;
        private int appLogin;

        private MySqlCommand sqlCommand;
        private MySqlConnection sqlConnection;


        public string UserName
        {
            set { userName = value; }
        }

        public void IpAddress()
        {
            //Trace.TraceInformation("Ulaz u metodu IpAddress");
            StringCipher cipher = new StringCipher();
            string uri = "E8rWoSFcl8CMQmn8zuaPB8eS844i41V/gbj3+YUpk+/MGgXLa5/LV8C8MYAJGIollXBe1pBe40jiPyidrUNilaztNHTEnR6ece5ul6Suz5ivHHkj2JU1wiGRbqe7Cz4W"; //http://checkip.dyndns.org/
            
            try
            {
                //Trace.TraceInformation("Zahtjev za dobijanje ip addrese.");
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync(cipher.Decrypt(uri)).Result.Content.ReadAsStringAsync().Result;
                    //Trace.TraceInformation("Vrijednost: {0}", result);
                    ipAddress = result.Split(':')[1].Split('<')[0];
                    //Trace.TraceInformation("IP Adresa: {0}", ipAddress);
                }
            }
            catch (Exception)
            {
                //Trace.TraceError("Greška u zahtjevu dobijanja ip adrese.");
                ipAddress = "";
            }
        }



        public void Read()
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
                this.sqlConnection = new MySqlConnection(query);
                sqlConnection.Open();

                query = String.Format("SELECT * FROM `users_app` WHERE `address` = '{0}' AND `name` = '{1}'", ipAddress, userName);
                sqlCommand = new MySqlCommand(query, sqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if(reader.FieldCount > 0)
                {
                    reader.Read();
                    this.appRun = Convert.ToInt32(reader["run"].ToString());
                    this.appLogin = Convert.ToInt32(reader["login"].ToString());
                }
                else
                {
                    this.appRun = 0;
                    this.appLogin = 0;
                }

                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception)
            {
               
            }
        }


        //methods
        public void Send()
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
                this.sqlCommand = new MySqlCommand();
                this.sqlConnection = new MySqlConnection(query);

                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;

                if(appRun == 0)
                {
                    sqlCommand.CommandText = "INSERT INTO `users_app` VALUES(NULL, @address, @name, @date, @run, @login)";
                    sqlCommand.Prepare();

                    sqlCommand.Parameters.AddWithValue("@address", ipAddress);
                    sqlCommand.Parameters.AddWithValue("@name", userName);
                    sqlCommand.Parameters.AddWithValue("@date", Date());
                    sqlCommand.Parameters.AddWithValue("@run", ++appRun);
                    sqlCommand.Parameters.AddWithValue("@login", appLogin);
                }
                else
                {
                    sqlCommand.CommandText = String.Format("UPDATE `users_app` SET date='{0}', run='{1}' WHERE `address`='{2}' AND `name`='{3}'", Date(), ++appRun, ipAddress, userName);
                }

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                
            }
        }

        private string Date()
        {
            return String.Format("{0}.{1}.{2} {3}:{4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute);
        }
    }
}
