using SAE_Search_Tool_Sync_Service.Logic;
using SAE_Search_Tool_Client.Models.DataAccess;
using SAE_Search_Tool_Client.Models.BusinessLogic.Models;
using SAE_Search_Tool_Client.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;

namespace SAE_Search_Tool_Sync_Service
{
    public static class FileSync
    {
        public static void Run()
        {
            while (true)
            {
                IList<string> paths = JsonParser.GetSearchPaths();

                if(paths is null)
                {
                    Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["downtime"]));
                    continue;
                }

                IList<FileReaderResult> resultsNew = new List<FileReaderResult>();
                IList<FileReaderResult> resultsOld = DbAccess.GetResults();

                // Fill results to get current state of files
                foreach (string path in paths) 
                {
                    if (File.Exists(path)) 
                    {
                        FileReader fr = new FileReader();
                        resultsNew.Add(new FileReaderResult(path, fr.GetContent(path)));
                    }
                }

                IList<FileReaderResult> inserts = new List<FileReaderResult>();
                IList<FileReaderResult> updates = new List<FileReaderResult>();
                IList<FileReaderResult> deletes = new List<FileReaderResult>();

                foreach (FileReaderResult result in resultsNew)
                {
                    // 1. Check if the path of the result already exists in the DB entries and assign to inserts if not.
                    if(!resultsOld.Any(r => r.Path == result.Path))
                    {
                        inserts.Add(result);
                        continue;
                    }

                    // 2. Check if the content of the already existing path has changed by comparing the hash values and assign to updates if hash differs.
                    if(resultsOld.Where(r => r.Path == result.Path).First().SHA512 != result.SHA512)
                    {
                        updates.Add(result);
                    }
                }

                // 3. Delete all DB entries which are only present there but not in the config file.
                foreach(FileReaderResult result in resultsOld)
                {
                    if (!paths.Contains(result.Path))
                    {
                        deletes.Add(result);
                    }
                }

                // Wait defined amount of milliseconds before syncing again.
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["downtime"]));
            }
        }
    }
}