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
                // Optimization: Use ReadAsync to avoid blocking threads and manually handle reading
                // to prevent BinaryReader from closing the stream (which is needed later).
                // Convert to base64 for display
                byte[] fileData = new byte[imageFile.ContentLength];
                int bytesRead = 0;
                while (bytesRead < imageFile.ContentLength)
                {
                    int n = await imageFile.InputStream.ReadAsync(fileData, bytesRead, imageFile.ContentLength - bytesRead);
                    if (n == 0) break;
                    bytesRead += n;
                }
                string base64Image = Convert.ToBase64String(fileData, 0, bytesRead);
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
