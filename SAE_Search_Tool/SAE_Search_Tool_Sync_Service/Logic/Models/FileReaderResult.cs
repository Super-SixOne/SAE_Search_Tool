namespace SAE_Search_Tool_Sync_Service.Logic.Models
{
    /// <summary>
    /// Represents an instance of a result created by a <see cref="FileReader"/> instance.
    /// </summary>
    class FileReaderResult
    {
        string Path { get; set; }
        string Content { get; set; }
    }
}
