using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Client.Models.BusinessLogic
{
    public class JsonCreation
    {
        //list
        //_List creation

        List<Data> _DriveList = new List<Data>();

        public string CurrentDirectory { get; set; }

        public void InitializeTestData()
        {
            _DriveList.Add(new Data()
            {
                Drive = "C:",
                SubFolders = @"DataSubfolder\Kacke\Dumm"
            });
            string jsonName = "JsonConfig.Json";
            string json = JsonConvert.SerializeObject(_DriveList);
            CurrentDirectory = Directory.GetCurrentDirectory();
            File.WriteAllText(CurrentDirectory + jsonName, json);
        }

    }
    public class Data
    {
        public string Drive { get; set; }
        public string SubFolders { get; set; }
    }
}
