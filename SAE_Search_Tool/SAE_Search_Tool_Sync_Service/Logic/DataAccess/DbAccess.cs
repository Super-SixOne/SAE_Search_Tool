using SAE_Search_Tool_Sync_Service.Logic.Models;
using System;
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
        public static void InsertData(IList<FileReaderResult> data)
        {
            
        }

        public static void DeleteData(IList<FileReaderResult> data)
        {

        }

        public static void UpdateDatabaseEntries(IList<FileReaderResult> data)
        {
            
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
