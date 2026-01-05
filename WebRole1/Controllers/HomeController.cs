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

                // Read async to avoid blocking threads and reuse the buffer
                int bytesRead = 0;
                while (bytesRead < imageFile.ContentLength)
                {
                    int read = await imageFile.InputStream.ReadAsync(fileData, bytesRead, imageFile.ContentLength - bytesRead);
                    if (read == 0) break;
                    bytesRead += read;
                }

                // If for some reason we didn't read all bytes (unlikely with ContentLength check), resize
                if (bytesRead < fileData.Length)
                {
                    Array.Resize(ref fileData, bytesRead);
                }

                string base64Image = Convert.ToBase64String(fileData);
                ViewBag.ImageData = String.Format("data:image/png;base64,{0}", base64Image);

                // Pass the memory stream to avoid re-reading from the input stream
                // This is faster and safer than resetting the input stream position
                using (var memoryStream = new MemoryStream(fileData))
                {
                    var faces = await _faceService.DetectFacesAsync(memoryStream);
                    return View("Result", faces);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
