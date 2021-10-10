using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SAE_Search_Tool_Client.Models.BusinessLogic;
using Npgsql;
using System.Collections.Generic;
using System.Text;

namespace SAE_Search_Tool_Client.Models.DataAccess
{
    internal sealed class DBAccess
    {
        #region methods: public

        public static DBAccess GetInstance()
        {
            if (_db == null)
            {
                _db = new DBAccess();
            }
            return _db;
        }

        public void OpenSqlConnection()
        {
            SetSqlConnectionSettings();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(_queryString, connection);
                command.Parameters.AddWithValue("@Text", _paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    //List<DBAccess> DBList = new List<DBAccess>();
                    //for (int i = 0; i < _dataTable.Rows.Count; i++)
                    //{
                        /// aus Tabelle eine Liste machen (falls nötig)

                    //}
                }

                catch (Exception ex)
                {
                    // TODO Marc logging -> Logfile erstellen (Übung, falls wir noch genug Zeit haben) -> Passenden Namen für die Logdatei ausdenken
                    Console.WriteLine(ex.Message); // Msg.Box.Show(ex.Message)
                }
            }
        }

        #endregion methods: public


        #region ctor

        // Singleton
        private DBAccess()
        {

        }

        #endregion ctor


        #region methods: private

        // Temp Solution until we put connection string into settings file.
        private void SetSqlConnectionSettings()
        {
            if (Equals(_connectionString, string.Empty))
            {
                _connectionString =
                    "User ID = postgres; Password = schumi1997; Server = localhost; Port = 5432; Database = DB_searchtool; "
                    + "Integrated Security = true;";
            }

            if (Equals(_queryString, string.Empty))
            {
                _queryString =
                    "SELECT * from DB_searchtooldb. "
                        + "select * from public.\"SearchTable\"where to_tsvector(\"Text\") @@ to_tsquery('Lorem'); "
                        + "ORDER BY ;";
            }
        }

        #endregion methods: private


        #region members: private

        // Das ist die einzige globale Instanz
        private static DBAccess _db = null;

        // private, damit sie nicht von Außen verändert werden können
        private string _connectionString = string.Empty;
        private string _queryString = string.Empty;
        private string _paramValue = "Kommt von der Oberfläche";

        #endregion members: private

    }

}
