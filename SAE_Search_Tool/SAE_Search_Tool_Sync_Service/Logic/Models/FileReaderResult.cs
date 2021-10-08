namespace SAE_Search_Tool_Sync_Service.Logic.Models
{
    /// <summary>
    /// Represents an instance of a result created by a <see cref="FileReader"/> instance.
    /// </summary>
    public class FileReaderResult
    {
        public FileReaderResult(string path, string content)
        {
            this.Path = path;
            this.Content = content;
            this.SHA512 = GetHash();
        }

        public string Path { get; set; }
        public string Content { get; set; }
        public string SHA512 { get; set; }

        private string GetHash()
        {
            // TODO: Logic for hash
            return "hashValue";
        }
    }
}
