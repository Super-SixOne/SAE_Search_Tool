using System.Collections.Generic;
using SAE_Search_Tool_Sync_Service.Logic.Models;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;

namespace SAE_Search_Tool_Sync_Service.Logic
{
    /// <summary>
    /// Responsible for reading the config file and creating <see cref="SearchPattern"/> objects.
    /// </summary>
    class JsonParser
    {
        public IList<SearchPattern> GetSearchPatterns()
        {
            string json = string.Empty;

            using (StreamReader reader = new StreamReader(ConfigurationManager.AppSettings["configPath"]))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<SearchPattern>>(json);
        }
    }
}
