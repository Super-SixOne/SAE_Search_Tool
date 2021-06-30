using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
    public class JsonCreation
    {
        //list
        //_List creation
        
       public List<data> _DriveList = new List<data>();
       _Dr
        
        _DriveList.Add(new data()
        {
            Drive = "C:",
            SubFolders = @"DataSubfolder\Kacke\Dumm"
        });
           

          


        string json = JsonConvert.SerializeObject(_list.toArray());

    }
    public class data
    {
     public string Drive { get; set; }
     public string SubFolders { get; set; }
    }
}
