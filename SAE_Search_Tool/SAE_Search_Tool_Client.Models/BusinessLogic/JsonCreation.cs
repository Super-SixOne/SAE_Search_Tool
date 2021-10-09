using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SAE_Search_Tool_Client.Models.BusinessLogic
{
    public static class JsonCreation
    {
       
        public static void UpdateJson(ObservableCollection<string> FileInput)
        {

            string jsonName = "JsonConfig.Json";
            string json = JsonConvert.SerializeObject(FileInput);
            string CurrentDirectory = "C:\\ProgramData\\";
            try
            {
                File.WriteAllText(CurrentDirectory + jsonName, json);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
