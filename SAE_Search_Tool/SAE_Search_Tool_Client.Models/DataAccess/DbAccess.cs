using System.Collections.Generic;
using System.Text;
using SAE_Search_Tool_Client.Models.BusinessLogic.Models;
using Npgsql;

namespace SAE_Search_Tool_Client.Models.DataAccess
{
    /// <summary>
    /// Responsible for handling database connection and communication.
    /// </summary>
    public static class DbAccess
    {
        public static string ConnectionString = "Server=localhost;Port=5432;Database=DB_Searchtool;User Id=postgres;Password=;";
        public static string TableName = "SearchTable";

        /// <summary>
        /// Inserts a set of <see cref="FileReaderResult"/> objects into the database.
        /// </summary>
        /// <param name="data">The data to insert into the database.</param>
        public static void InsertData(IList<FileReaderResult> data)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder($"INSERT INTO public.\"{DbAccess.TableName}\" (path, content, hash) VALUES (");

                foreach (FileReaderResult result in data)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        commandString.Append($"\'{result.Path}\',\'{result.Content}\',\'{result.SHA512})\'");


                        if (i + 1 < data.Count)
                        {
                            commandString.Append(",(");
                        }
                    }
                }

                using (NpgsqlCommand command = new NpgsqlCommand(commandString.ToString(), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a set of <see cref="FileReaderResult"/> objects in the database.
        /// </summary>
        /// <param name="data">The data to delete in the database.</param>
        public static void DeleteData(IList<FileReaderResult> data)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder($"DELETE FROM {DbAccess.TableName} WHERE path IN (");

                int i = 0;
                foreach(FileReaderResult result in data)
                {
                    commandString.Append($"\'{result.Path}\'");
                    if (i + 1 < data.Count)
                    {
                        commandString.Append(",");
                    }

                    i++;
                }

                commandString.Append(")");

                using (NpgsqlCommand command = new NpgsqlCommand(commandString.ToString(), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates a set of <see cref="FileReaderResult"/> objects in the database.
        /// </summary>
        /// <param name="data">The data to update in the database.</param>
        public static void UpdateDatabaseEntries(IList<FileReaderResult> data)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder($"UPDATE {DbAccess.TableName} SET content = ");

                foreach (FileReaderResult result in data)
                {
                    commandString.Append($"\'{result.Content}\', hash = \'{result.SHA512}\' WHERE path = \'{result.Path}\'");

                    using (NpgsqlCommand command = new NpgsqlCommand(commandString.ToString(), connection))
                    {
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
            IList<FileReaderResult> results = new List<FileReaderResult>();

            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {DbAccess.TableName}", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new FileReaderResult(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Gets a set of <see cref="FileReaderResult"/> objects from the database based on a given search string.
        /// </summary>
        /// <param name="searchString">The text for which to search for.</param>
        /// <returns>A list of <see cref="FileReaderResult"/> objects.</returns>
        public static IList<FileReaderResult> GetResults(string searchString)
        {
            IList<FileReaderResult> results = new List<FileReaderResult>();

            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {DbAccess.TableName} WHERE to_tsvector(content) @@ to_tsquery(\'{searchString}\');", connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new FileReaderResult(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
            }

            return results;
        }
    }
}
