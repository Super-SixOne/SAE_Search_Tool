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
                var res = JsonParser.GetSearchPatterns();

                // loop through the list and get the file contents.
                // First check if the file can be opened and the path exists
                // We will receive a dictionary of file paths and content


                // Wait defined amount of milliseconds before syncing again.
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["downtime"]));
            }
        }
    }
}
