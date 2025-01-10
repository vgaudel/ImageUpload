using ImageUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImageUpload.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() //route GET pour ajouter un User avec une image
        {
            FileService fileService = new FileService();

            return View(fileService.GetUsers());
        }

        [HttpPost]
        public void SaveFile(FileUpload fileObj) //route POST pour récupérer un User avec une image
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

        public IActionResult AllUsers() // Route GET pour afficher l'ensemble des Users ajoutés
        {
            FileService fileService = new FileService();

            return View(fileService.GetUsers());
        }
    }
}
