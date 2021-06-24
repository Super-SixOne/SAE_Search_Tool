using SAE_Search_Tool_Sync_Service.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Sync_Service
{
    public static class FileSync
    {
        public static void Run()
        {
            JsonParser parser = new JsonParser();

            var res = parser.GetSearchPatterns();
        }
    }
}
