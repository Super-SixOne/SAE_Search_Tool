using SAE_Search_Tool_Sync_Service.Logic;
using System;
using System.Configuration;
using System.Threading;

namespace SAE_Search_Tool_Sync_Service
{
    public static class FileSync
    {
        public static void Run()
        {
            while (true)
            {
                JsonParser parser = new JsonParser();

                var res = parser.GetSearchPatterns();

                // Wait defined amount of milliseconds before syncing again.
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["downtime"]));
            }
        }
    }
}
