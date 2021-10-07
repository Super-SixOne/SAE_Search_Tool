using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAE_Search_Tool_Sync_Service.Logic.Models
{
    /// <summary>
    /// Represents the pattern that should be used to figure the locations in which to extract the file contents.
    /// </summary>
    public class SearchPattern
    {
        [JsonProperty("paths")]
        public List<string> Paths { get; set; }
    }
}
