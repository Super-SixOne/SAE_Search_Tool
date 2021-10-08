using SAE_Search_Tool_Sync_Service.Logic.Models;
using Npgsql;
using System.Collections.Generic;
using System.Text;

namespace SAE_Search_Tool_Sync_Service.Logic.DataAccess
{
    /// <summary>
    /// Responsible for handling database connection and communication.
    /// </summary>
    public static class DbAccess
    {
        public static string ConnectionString = "Server=10.194.9.131;Port=5432;Database=myDataBase;User Id=postgres;Password=Vahpeiwoqu1Haex4cem6;";
        public static string TableName = "table_name";

        public static void InsertData(IList<FileReaderResult> data)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder($"INSERT INTO {DbAccess.TableName} (path, content, hash) VALUES (");

                for(int i = 0; i < data.Count; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        commandString.Append($"@p{i}{j}");
                        if (j + 1 < 3)
                        {
                            commandString.Append(",");
                        }
                    }

                    commandString.Append(")");
                    if(i + 1 < data.Count)
                    {
                        commandString.Append(",");
                    }
                }

                commandString.Append(")");

                using(NpgsqlCommand command = new NpgsqlCommand(commandString.ToString(), connection))
                {
                    int i = 0;
                    foreach(FileReaderResult result in data)
                    {
                        command.Parameters.AddWithValue($"p{i}{0}", result.Path);
                        command.Parameters.AddWithValue($"p{i}{1}", result.Path);
                        command.Parameters.AddWithValue($"p{i}{2}", result.Path);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteData(IList<FileReaderResult> data)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder($"DELETE FROM {DbAccess.TableName} WHERE hash IN (");

                for(int i = 0; i < data.Count; i++)
                {
                    commandString.Append($"@p{i}");
                    if (i + 1 < data.Count)
                    {
                        commandString.Append(",");
                    }
                }

                commandString.Append(")");

                using (NpgsqlCommand command = new NpgsqlCommand(commandString.ToString(), connection))
                {
                    int i = 0;
                    foreach (FileReaderResult result in data)
                    {
                        command.Parameters.AddWithValue($"p{i}", result.SHA512);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateDatabaseEntries(IList<FileReaderResult> data)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder($"UPDATE {DbAccess.TableName} SET hash = ");

                foreach (FileReaderResult result in data)
                {
                    commandString.Append($"@p0, content = @p1 WHERE path = @p2");

                    using (NpgsqlCommand command = new NpgsqlCommand(commandString.ToString(), connection))
                    {
                        command.Parameters.AddWithValue("p0", result.SHA512);
                        command.Parameters.AddWithValue("p1", result.Content);
                        command.Parameters.AddWithValue("p2", result.Path);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Gets all data in the database as <see cref="FileReaderResult"/> objects.
        /// </summary>
        /// <returns>A list of <see cref="FileReaderResult"/> objects.</returns>
        public static IList<FileReaderResult> GetResults()
        {
            //TODO: Logic Select *
            return new List<FileReaderResult>();
        }

        public static IList<FileReaderResult> GetResults(string searchPattern)
        {
            //TODO: Logic
            return new List<FileReaderResult>();
        }
    }
}
