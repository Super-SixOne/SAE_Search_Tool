using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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

            // TODO Marc -> EF Core? Abklären & dann austauschen, weil 1. Extrapunkte 2. praktisch & modern
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(_queryString, connection);
                command.Parameters.AddWithValue("@Text", _paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    ///SqlDataReader reader = command.ExecuteReader();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(_dataTable);

                    List<DBAccess> DBList = new List<DBAccess>();
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        /// aus Tabelle eine Liste machen (falls nötig)

                    }
                }

                catch (Exception ex)
                {
                    // TODO Marc logging -> Logfile erstellen (Übung, falls wir noch genug Zeit haben) -> Passenden Namen für die Logdatei ausdenken
                    Console.WriteLine(ex.Message); // Msg.Box.Show(ex.Message)
                }
            }
        }

        // TODO Marc -> Siehe Stellen, an denen _connectionString, _queryString und _paramValue bisher benutzt werden
        // und schau, ob man diese nochmal braucht (Tipp: -> Klicke auf eine Variable / Funktion und drück Shift + F12, dann siehst du alle Verweise)
        // wenn ja nach kommentiere die jeweilige Funktion wieder aus, ansonsten kannst du die löschen

        //public string GetConnectionString()
        //{
        //    return _connectionString;
        //}

        //public string GetQueryString()
        //{
        //    return _queryString;
        //}

        //public string GetParamValueString()
        //{
        //    return _paramValue;
        //}

        public DataTable GetDataTable()
        {
            return _dataTable;
        }

        // TODO Marc -> schreib die Funktion fertig und melde dich bei Fragen
        public static void SearchInputInDatabase()
        {
            DBAccess access = DBAccess.GetInstance();

            DataTable dataTable = access.GetDataTable();

            dataTable.Columns.Add("Id", typeof(Int32));
            dataTable.Columns.Add("Path", typeof(string));
            dataTable.Columns.Add("Text", typeof(string));

            // TODO Marc -> Kann man auf diese Listen vom Außen zugreifen? Überprüfen
            List<DataRow> dataTableAsList = (dataTable.AsEnumerable()).ToList();

            ObservableCollection<DataRow> dataTableAsCollection = new ObservableCollection<DataRow>(dataTableAsList);

            access.OpenSqlConnection();
        }

        #endregion methods: public


        #region ctor

        // Singleton
        private DBAccess()
        {

        }

        #endregion ctor


        #region methods: private

        private void SetSqlConnectionSettings()
        {
            if (Equals(_connectionString, string.Empty))
            {
                _connectionString =
                    "Data Source=(local);Initial Catalog=Northwind;"
                    + "Integrated Security=true";
            }

            if (Equals(_queryString, string.Empty))
            {
                _queryString =
                    "SELECT * from db.Database "
                        + "where to_tsvector(name) @@ to_tsquery('> @Text');   "
                        + "ORDER BY ;";
            }
        }

        #endregion methods: private


        #region members: private

        // Das ist die einzige globale Instanz
        private static DBAccess _db = null;
        private DataTable _dataTable = new DataTable("DataFromDB");

        // private, damit sie nicht von Außen verändert werden können
        private string _connectionString = string.Empty;
        private string _queryString = string.Empty;
        private string _paramValue = "Kommt von der Oberfläche";

        #endregion members: private

    }

}
