//using Microsoft.AspNetCore.Hosting.Server;
//using Microsoft.AspNetCore.Mvc;
//using UploadFileProject.Models;
//using System.Data;
//using System.IO;
//using System.Collections.Generic;
//using System.Web;
//using System.Linq;




//namespace UploadFileProject.Controllers
//{
//    public class Home1Controller : Controller
//    {
//        public IActionResult Upload()
//        {
//            List<ObjFile> ObjFiles = new List<ObjFile>();
//            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Files")))
//            {
//                FileInfo fi = new FileInfo(strfile);
//                ObjFile obj = new ObjFile();
//                obj.Filename = fi.Name;
//                obj.size = fi.Length;
//                obj.type = GetFileTypeByExtension(fi.Extension);
//                ObjFiles.Add(obj);
//            }

//            return View(ObjFiles);
//        }

//        public FileResult Download(string fileName)
//        {
//            string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
//            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);



//            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
//        }

//        private string GetFileTypeByExtension(string fileExtension)
//        {
//            switch (fileExtension.ToLower())
//            {
//                case ".docx":
//                case ".doc":
//                    return "Microsoft Word Document";
//                case ".xlsx":
//                case ".xls":
//                    return "Microsoft Excel Document";
//                case ".txt":
//                    return "Text Document";
//                case ".jpg":
//                case ".png":
//                    return "Image";
//                default:
//                    return "Unknown";
//            }
//        }
//        [HttpPost]
//        public ActionResult Index(ObjFile doc)
//        {
//            foreach (var file in doc.Files)
//            {

//                if (file.ContentLength > 0)
//                {
//                    var fileName = Path.GetFileName(file.FileName);
//                    var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
//                    file.SaveAs(filePath);
//                }
//            }
//            TempData["Message"] = "files uploaded successfully";
//            return RedirectToAction("Index");
//        }

//    }
//}



