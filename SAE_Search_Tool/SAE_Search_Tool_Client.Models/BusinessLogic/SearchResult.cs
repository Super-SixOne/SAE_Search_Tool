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
    public class JsonCreation
    {
        //list
        //_List creation

        List<Data> _DriveList = new List<Data>();
        public void InitializeTestData()
        {
            _DriveList.Add(new Data()
            {
                Drive = "C:",
                SubFolders = @"DataSubfolder\Kacke\Dumm"
            });
            string json = JsonConvert.SerializeObject(_DriveList);
            File.WriteAllText(@"E:\Search Tool\SAE_Search_Tool\Developement Testing\DriveConfig.json", json);
        }

    }
    public class Data
    {
        public string Drive { get; set; }
        public string SubFolders { get; set; }
    }

    public class DataFromDB
    {
        public long IdData { get; set; }

        private string _Path;
        public string Path
        {
            get
            {
                return _Path;
            }

            set
            {
                _Path = value;
            }
        }
        public string Text { get; set; }
    }
        
}
