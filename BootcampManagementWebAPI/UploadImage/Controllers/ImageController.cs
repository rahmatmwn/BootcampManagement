using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UploadImage.Controllers
{
   
    [Route("api/Image")]
    public class ImageController : Controller
    {
        // GET: Image

        //public ActionResult Index()
        [HttpPost]
        public async Task Post(IImage file)
        {
            var uploads = Path.Combine(.WebRootPath, "uploads");
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }
    }
}