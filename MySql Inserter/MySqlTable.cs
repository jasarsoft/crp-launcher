using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Jasarsoft.MySQLInserter
{
    internal class MySqlTable
    {        
        private MySqlCommand sqlCommand;
        private MySqlConnection sqlConnection;


        public MySqlTable(MySqlConnection sqlConnection)
        {
            if (sqlConnection == null) throw new ArgumentNullException("Argument sqlConnection je null.");
            this.sqlConnection = sqlConnection;
        }

        public void Create(string table, string[] columns)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = String.Format("CREATE TABLE {0}({1})", table, columns);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Console.WriteLine("INFO: Tabela '{0}' je kreirana.", table);
            }
            /*catch (MySqlException sqlExcetion)
            {
                Console.WriteLine("ERROR: Greska u metodi MySqlTable.Create sa upitom;\nMessage: {0}", sqlExcetion.Message);
            }*/
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Greska u metodi MySqlTable.Create;\nMessage: {0}", ex.Message);
            }
        }

        public void Rename(string tableOld, string tableNew)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = String.Format("RENAME TABLE {0} TO {1}", tableOld, tableNew);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Console.WriteLine("INFO: Tabela '{0}' je preimenovana u '{1}'.", tableOld, tableNew);
            }
            /*catch (MySqlException sqlExcetion)
            {
                Console.WriteLine("ERROR: Greska u metodi MySqlTable.Rename sa upitom;\nMessage: {0}", sqlExcetion.Message);
            }*/
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Greska u metodi MySqlTable.Rename;\nMessage: {0}", ex.Message);
            }
        }

        public void Insert(string table, string path, Google.Apis.Drive.v2.Data.File googleFile)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO {0}(name, size, hash, link) VALUES(@name, @size, @hash, @link)";
                sqlCommand.Parameters.AddWithValue("@name", path + googleFile.Title);
                sqlCommand.Parameters.AddWithValue("@size", googleFile.FileSize);
                sqlCommand.Parameters.AddWithValue("@hash", googleFile.Md5Checksum);
                sqlCommand.Parameters.AddWithValue("@link", googleFile.Id);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Greska u metodi MySqlTable.Insert;\nMessage: {0}", ex.Message);
            }
        }

        public void Drop(MySqlConnection sqlConnection, MySqlCommand sqlCommand, string table)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = String.Format("DROP TABLE IF EXISTS {0}", table);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Console.WriteLine("INFO: Tabela '{0}' je obrisana.", table);
            }
            /*catch (MySqlException sqlExcetion)
            {
                Console.WriteLine("ERROR: Greska u metodi Drop sa upitom;\nMessage: {0}", sqlExcetion.Message);
            }*/
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Greska u metodi Table.Drop;\nMessage: {0}", ex.Message);
            }

        }

        
    }
}
