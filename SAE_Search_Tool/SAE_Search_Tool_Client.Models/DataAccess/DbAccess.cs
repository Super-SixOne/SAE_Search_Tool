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
        public static string ConnectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=schumi1997;";
        public static string TableName = "SearchTable";

        public static void InsertData(IList<FileReaderResult> data)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                StringBuilder commandString = new StringBuilder($"INSERT INTO public.\"{DbAccess.TableName}\" (path, content, hash) VALUES (");

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        commandString.Append($"\'@p{i}{j}\'");
                        if (j + 1 < 3)
                        {
                            commandString.Append(",");
                        }
                    }

                    commandString.Append(")");
                    if (i + 1 < data.Count)
                    {
                        commandString.Append(",(");
                    }
                }

                using (NpgsqlCommand command = new NpgsqlCommand(commandString.ToString(), connection))
                {
                    int i = 0;
                    foreach (FileReaderResult result in data)
                    {
                        command.Parameters.AddWithValue($"p{i}{0}", result.Path);
                        command.Parameters.AddWithValue($"p{i}{1}", result.Content);
                        command.Parameters.AddWithValue($"p{i}{2}", result.SHA512);
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

                for (int i = 0; i < data.Count; i++)
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

        public static IList<FileReaderResult> GetResults(string searchString)
        {
            IList<FileReaderResult> results = new List<FileReaderResult>();

            using (NpgsqlConnection connection = new NpgsqlConnection(DbAccess.ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {DbAccess.TableName} WHERE to_tsvector(content) @@ to_tsquery({searchString});", connection))
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
