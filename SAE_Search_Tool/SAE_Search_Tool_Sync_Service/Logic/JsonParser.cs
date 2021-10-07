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
    public static class JsonParser 
    {
        /// <summary>
        /// Parses a json file and deserializes the <see cref="SearchPattern"/> objects.
        /// </summary>
        /// <returns>Returns a list of <see cref="SearchPattern"/> objects.</returns>
        public static IList<string> GetSearchPaths() 
        {
            string json = string.Empty;

            using (StreamReader reader = new StreamReader(ConfigurationManager.AppSettings["configPath"]))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<string>>(json);
        }
    }
}
