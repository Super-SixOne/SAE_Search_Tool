using System;
using System.Security.Cryptography;
using System.Text;

namespace SAE_Search_Tool_Client.Models.BusinessLogic.Models
{
    public class FileReaderResult
    {
        public FileReaderResult(string path, string content)
        {
            this.Path = path;
            this.Content = content;
            this.SHA512 = GetSHA512Base64();
        }

        public FileReaderResult(string path, string content, string sha512) : this(path, content)
        {
            this.SHA512 = sha512;
        }

        public string Path { get; set; }
        public string Content { get; set; }
        public string SHA512 { get; set; }

        private string GetSHA512Base64()
        {
            string base64Hash;

            using(SHA512Managed shaM = new SHA512Managed())
            {
               base64Hash = Convert.ToBase64String(shaM.ComputeHash(Encoding.UTF8.GetBytes(this.Path + this.Content)));
            }

            return base64Hash;
        }
    }
}

