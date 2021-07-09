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
    class DBAcess
    {
        static void Main()
        {
            string connectionString =
                "Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=true";

            // @Text = Placeholder.
            string queryString =
                "SELECT * from db.Database "
                    + "where to_tsvector(name) @@ to_tsquery('> @Text');   "
                    + "ORDER BY ;";

            // Specify the parameter value.
            string paramValue = "kommt von Overfläche";

            DataTable dt = new DataTable("DataFromDB");
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("Path", typeof(string));
            dt.Columns.Add("Text", typeof(string));

            List<DataRow> test = (dt.AsEnumerable()).ToList();

            ObservableCollection<DataRow> test2 = new ObservableCollection<DataRow>(test);

            //foreach (var item in (dt.AsEnumerable))
            //{

            //}

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Text", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    ///SqlDataReader reader = command.ExecuteReader();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(dt);

                    List<DBAcess> DBList = new List<DBAcess>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        /// aus Tabelle eine Liste machen (falls nötig)

                    }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // Msg.Box.Show(ex.Message)
                }
                
            }
        }
    }
}
