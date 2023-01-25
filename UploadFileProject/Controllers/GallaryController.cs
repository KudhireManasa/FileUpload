using Microsoft.AspNetCore.Mvc;

namespace UploadFileProject.Controllers
{
    public class GallaryController : Controller
    {

        private readonly string wwwrootDirectory =
            Path.Combine(Directory.GetCurrentDirectory(), "Filles");
        [HttpGet]
        public IActionResult Index()
        {
            /*List<string> images = Path.GetFiles(wwwrootDirectory, "*.png")
                .Select(Path.GetFileName)
                .ToList();*/
            return View();
        }
            [HttpPost]
            public async Task<IActionResult> IndexAsync(IFormFile myFile)

            {
                if (myFile != null)
                {
                    var path = Path.Combine(
                        wwwrootDirectory,
                        DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName));
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await myFile.CopyToAsync(stream);
                    }
                }
                return View();
            }

        }
    }

