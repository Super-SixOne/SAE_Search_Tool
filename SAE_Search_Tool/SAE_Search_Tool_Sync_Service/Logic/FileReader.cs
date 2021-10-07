using SAE_Search_Tool_Sync_Service.Logic.Models;
using Visualis.Extractor;

namespace SAE_Search_Tool_Sync_Service.Logic
{
    /// <summary>
    /// Responsible for reading files and creating <see cref="FileReaderResult"/> objects.
    /// </summary>
    public class FileReader
    {
        public string GetContent(string path)
        {
            TextExtractorD extractor = new TextExtractorD();
            return extractor.Extract(path);
        }
    }
}
