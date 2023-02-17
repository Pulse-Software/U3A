using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace U3A.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public partial class UploadController : ControllerBase
    {
        protected string ContentRootPath { get; set; }

        [HttpPost("[action]")]
        public ActionResult UploadFile(IFormFile myFile) {
            try {
                var path = GetOrCreateUploadFolder();
                using (var fileStream = System.IO.File.Create(Path.Combine(path, myFile.FileName))) {
                    myFile.CopyTo(fileStream);
                }
            }
            catch {
                Response.StatusCode = 400;
            }
            return new EmptyResult();
        }

        public UploadController(IWebHostEnvironment hostingEnvironment) {
            ContentRootPath = hostingEnvironment.ContentRootPath;
        }

        public string GetOrCreateUploadFolder() {
            var path = Path.Combine(ContentRootPath, "uploads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}
