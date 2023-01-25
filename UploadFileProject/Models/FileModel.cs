using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Microsoft.AspNetCore.Http;
namespace UploadFileProject.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }

       // public string EMAILID { get; set; }
    }

}



