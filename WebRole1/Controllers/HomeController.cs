using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebRole1.Services;

namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFaceService _faceService;

        public HomeController()
        {
            // In a real app, use dependency injection
            _faceService = new MockFaceService();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Face Analysis";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Analyze(HttpPostedFileBase imageFile)
        {
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                // Convert to base64 for display
                byte[] fileData = new byte[imageFile.ContentLength];
                int bytesRead = 0;
                int totalBytesRead = 0;

                // Read file asynchronously to avoid blocking threads
                while ((bytesRead = await imageFile.InputStream.ReadAsync(fileData, totalBytesRead, imageFile.ContentLength - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                string base64Image = Convert.ToBase64String(fileData, 0, totalBytesRead);
                ViewBag.ImageData = String.Format("data:image/png;base64,{0}", base64Image);

                // Reset stream position for service
                imageFile.InputStream.Position = 0;
                var faces = await _faceService.DetectFacesAsync(imageFile.InputStream);

                return View("Result", faces);
            }

            return RedirectToAction("Index");
        }
    }
}
