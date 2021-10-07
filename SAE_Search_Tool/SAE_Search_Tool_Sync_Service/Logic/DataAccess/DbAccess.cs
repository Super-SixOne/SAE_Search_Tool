using SAE_Search_Tool_Sync_Service.Logic.Models;
using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Sync_Service.Logic.DataAccess
{
    /// <summary>
    /// Responsible for handling database connection and communication.
    /// </summary>
    public static class DbAccess
    {
        public static string ConnectionString = "Server=10.194.9.131;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;";

        public static void InsertData(IList<FileReaderResult> data)
        {
            using (var connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder("INSERT INTO table_name () VALUES");

                foreach(FileReaderResult result in data)
                {

                }

                // Execute non query
            }
        }

        public static void DeleteData(IList<FileReaderResult> data)
        {
            // Execute non query
        }

        public static void UpdateDatabaseEntries(IList<FileReaderResult> data)
        {
            // Execute non query
        }

        /// <summary>
        /// Gets all data in the database as <see cref="FileReaderResult"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="FileReaderResult"/> objects.</returns>
        public static IList<FileReaderResult> GetResults()
        {
            //TODO: Logic
            return new List<FileReaderResult>();
        }
    }
}
