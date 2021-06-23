using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Client.Models.BusinessLogic
{
    /// <summary>
    /// Class that represents one search result of a query to the database.
    /// </summary>
    class SearchResult
    {
        #region Properties

        string Path { get; set; }
        string TextExcerpt { get; set; }

        #endregion
    }
}
