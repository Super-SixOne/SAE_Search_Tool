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
        }

        public string Path { get; }
        public string Content { get; }
        public string SHA512 { get; }
    }
}
