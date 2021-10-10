using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SAE_Search_Tool_Client.Models.BusinessLogic
{
    public static class JsonParser
    {
       
        public static void WriteSearchPaths(IList<string> fileInput)
        {

            string jsonName = "JsonConfig.json";
            string json = JsonConvert.SerializeObject(fileInput);
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

        public static IList<string> GetSearchPaths()
        {
            string json = string.Empty;

            if (!File.Exists("C:\\ProgramData\\JsonConfig.json"))
            {
                File.Create("C:\\ProgramData\\JsonConfig.json");
            }

            using (StreamReader reader = new StreamReader("C:\\ProgramData\\JsonConfig.json"))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<string>>(json);
        }

    }
}
