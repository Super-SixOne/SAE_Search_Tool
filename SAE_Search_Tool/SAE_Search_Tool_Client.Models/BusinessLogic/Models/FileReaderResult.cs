namespace SAE_Search_Tool_Client.Models.BusinessLogic.Models
{
    public class FileReaderResult
    {
        public FileReaderResult(string path, string content)
        {
            this.Path = path;
            this.Content = content;
            this.SHA512 = GetHash();
        }

        public FileReaderResult(string path, string content, string sha512) : this(path, content)
        {
            this.SHA512 = sha512;
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

