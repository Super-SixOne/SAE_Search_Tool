using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SAE_Search_Tool_Client.Models.BusinessLogic
{
    /// <summary>
    /// Class that represents one search result of a query to the database.
    /// </summary>
    class SearchResult
    {
        #region Properties

        public string Path { get; set; }
        public string TextExcerpt { get; set; }

        #endregion
    }



}
