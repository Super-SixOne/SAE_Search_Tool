using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Sync_Service.Logic.Models
{
    /// <summary>
    /// Represents the pattern that should be used to figure the locations in which to extract the file contents.
    /// </summary>
    class SearchPattern
    {
        string Directory { get; set; }
        List<string> Subfolders { get; set; }
    }
}
