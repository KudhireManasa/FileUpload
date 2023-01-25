//using Microsoft.AspNetCore.Mvc;
//using System.Data.SqlClient;
//using System.Diagnostics;
//using UploadFileProject.Models;

//namespace UploadFileProject.Controllers
//{
//    static string constr =
//    public IActionResult Index()
//    {
//        return View(PopulateFiles());
//    }

//    [HttpPost]
//    public IActionResult Index(List<IFormFile> postedFiles)
//    {
//        foreach (IFormFile postedFilein postedFiles)
//        {
//            string fileName = Path.GetFileName(postedFile.FileName);
//            string type = postedFile.ContentType;
//            byte[] bytes = null;
//            using (MemoryStream ms = new MemoryStream())
//            {
//                postedFile.CopyTo(ms);
//                bytes = ms.ToArray();
//            }
//            using (SqlConnection con = new SqlConnection(constr))
//            {
//                using (SqlCommand cmd = new SqlCommand())
//                {
//                    cmd.CommandText = "INSERT INTO tblFiles(Name, ContentType, Data) VALUES (@Name, @ContentType, @Data)";
//                    cmd.Parameters.AddWithValue("@Name", fileName);
//                    cmd.Parameters.AddWithValue("@ContentType", type);
//                    cmd.Parameters.AddWithValue("@Data", bytes);
//                    cmd.Connection = con;
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }
//            }
//        }

//        return View(PopulateFiles());
//    }

//    public FileResult DownloadFile(int fileId)
//    {
//        FileModel model = PopulateFiles().Find(x => x.Id == Convert.ToInt32(fileId));
//        string fileName = model.Name;
//        string contentType = model.ContentType;
//        byte[] bytes = model.Data;
//        return File(bytes, contentType, fileName);
//    }

//    private static List<FileModel> PopulateFiles()
//    {
//        List<FileModel> files = new List<FileModel>();
//        using (SqlConnection con = new SqlConnection(constr))
//        {
//            string query = "SELECT * FROM tblFiles";
//            using (SqlCommand cmd = new SqlCommand(query))
//            {
//                cmd.Connection = con;
//                con.Open();
//                using (SqlDataReader sdr = cmd.ExecuteReader())
//                {
//                    while (sdr.Read())
//                    {
//                        files.Add(new FileModel
//                        {
//                            Id = Convert.ToInt32(sdr["Id"]),
//                            Name = sdr["Name"].ToString(),
//                            ContentType = sdr["ContentType"].ToString(),
//                            Data = (byte[])sdr["Data"]
//                        });
//                    }
//                }
//                con.Close();
//            }
//        }

//        return files;
//    }
//}