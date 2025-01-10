using ImageUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImageUpload.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            FileService fileService = new FileService();

            return View(fileService.GetUsers());
        }

        [HttpPost]
        public void SaveFile(FileUpload fileObj)
        {
            FileService fileService = new FileService();

            User user = JsonConvert.DeserializeObject<User>(fileObj.User);

            if (fileObj.file.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    user.PhotoData = fileBytes;

                    user = fileService.AddUser(user);
                }
            }
        }

        public IActionResult AllUsers()
        {
            FileService fileService = new FileService();

            return View(fileService.GetUsers());
        }
    }
}
