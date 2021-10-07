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
        public static void InsertData(FileReaderResult data)
        {
            // Check if there is a matching path in the DB already.
            data.Path
        }

        /// <summary>
        /// Compares two lists of <see cref="FileReaderResult"/> objects and deletes all entries from the database that are only present in the second list.
        /// </summary>
        /// <param name="fileReaderResults">The reference list of all <see cref="FileReaderResult"/> objects that should be present in the database.</param>
        /// <param name="searchResults">The list of all <see cref="FileReaderResult"/> objects present in the database.</param>
        public static void DeleteData(IList<FileReaderResult> fileReaderResults, IList<FileReaderResult> searchResults)
        {

        }

        /// <summary>
        /// Updates the database entries by calling <see cref="InsertData(IList{FileReaderResult})"/> and <see cref="DeleteData(IList{FileReaderResult}, IList{FileReaderResult})"/> subsequently.
        /// </summary>
        /// <param name="fileReaderResults">The reference list to compare the database entries against.</param>
        public static void UpdateDatabaseEntries(IList<FileReaderResult> fileReaderResults)
        {
            InsertData(fileReaderResults);
            DeleteData(fileReaderResults, GetAllData());
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
