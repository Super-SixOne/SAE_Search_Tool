using Visualis.Extractor;

namespace SAE_Search_Tool_Sync_Service.Logic
{
    public class FileReader
    {
        public string GetContent(string path)
        {
            TextExtractorD extractor = new TextExtractorD();
            return extractor.Extract(path);
        }
    }
}
