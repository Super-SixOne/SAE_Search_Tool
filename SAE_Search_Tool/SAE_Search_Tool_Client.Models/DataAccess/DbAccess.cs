using SAE_Search_Tool_Client.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SAE_Search_Tool_Client.Models.DataAccess
{
    /// <summary>
    /// Class that provides functionality to access a database.
    /// </summary>

    class DbAccess
    {
        public bool IsConnected { get; private set; }

            string con = "data source=local;database=Sample; Integrated security=true"; // data source=. = local server
            /// SqlDataReader rdr = cmd.ExecuteReader();
        void FindOneWordOnDb(object sender, EventArgs e)
        {


        }

        public List<DataFromDB> SingleWordSearch()
        {

            List<DataFromDB> ltemp = new List<DataFromDB>();
            try
            {
                using (SqlConnection connection = new SqlConnection(con))

                {
                    string sql = string.Format("select Id, Path, Text from TABLE " +
                        "where to_tsvector(Text) @@ to_tsquery('@Text'); ", SearchString.Text);
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@pricePoint", paramValue);

                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}",
                                reader[0], reader[1], reader[2]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                }
            }               
        }
    }
}


