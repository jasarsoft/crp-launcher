#define LAUNCHER_INFO

using System;
using MySql.Data.MySqlClient;

namespace Jasarsoft.Columbia
{
    public class LauncherBase
    {
        private string hashLauncher;
        private string hashUpdate;

        private MySqlCommand sqlCommand;
        private MySqlConnection sqlConnection;

#if LAUNCHER_INFO
        private string titleLauncher;
        private string typeLauncher;
        private string dateLauncher;
        private string licenseLauncher;
        private string copyrightLauncher;
        private string developerLauncher;
        private string descriptionLauncher;

        private struct LauncherColumn
        {
            public const string Launcher = "launcher";
            public const string Update = "update";
            public const string Title = "title";
            public const string Type = "type";
            public const string Date = "date";
            public const string License = "license";
            public const string Copyright = "copyright";
            public const string Developer = "developer";
            public const string Description = "description";
        }
#endif


        //properties
        public string HashLauncher
        {
            get { return this.hashLauncher; }
        }

        public string HashUpdate
        {
            get { return this.hashUpdate; }
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
                this.sqlConnection = new MySqlConnection(query);
                sqlConnection.Open();

                query = "SELECT * FROM `launcher` WHERE `id`=1 LIMIT 1";
                sqlCommand= new MySqlCommand(query, sqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();

                reader.Read();
                
                this.hashLauncher = reader[LauncherColumn.Launcher].ToString();
                this.hashUpdate = reader[LauncherColumn.Update].ToString();
#if LAUNCHER_INFO
                this.titleLauncher = reader[LauncherColumn.Title].ToString();
                this.typeLauncher = reader[LauncherColumn.Type].ToString();
                this.dateLauncher = reader[LauncherColumn.Date].ToString();
                this.licenseLauncher = reader[LauncherColumn.License].ToString();
                this.copyrightLauncher = reader[LauncherColumn.Copyright].ToString();
                this.developerLauncher = reader[LauncherColumn.Developer].ToString();
                this.descriptionLauncher = reader[LauncherColumn.Description].ToString();
#endif
                reader.Close();
                sqlConnection.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                /*string message = "Došlo je do greške pri pokušaju čitanja launcher podataka iz baze.\n" +
                                 "Greška: " + ex.Message;
                throw new Exception(message);*/
            }
        }
    }
}
