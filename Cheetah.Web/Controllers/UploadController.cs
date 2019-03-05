using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cors;

namespace Cheetah.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] IFormFile file)
        {
            if (file != null)
            {
                var today = DateTime.Now.ToString("yyyyMMdd");
                var folder = Path.Combine(_hostingEnvironment.WebRootPath, today);
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                var filePath = Path.Combine(folder, Path.GetRandomFileName());
                var newFileName = string.Empty;
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        var sha = new SHA1Managed();
                        var hash = BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", "").ToLower();
                        newFileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + hash + Path.GetExtension(file.FileName);
                    }
                    var newfilePath = Path.Combine(folder, newFileName);
                    if (!System.IO.File.Exists(newfilePath))
                        System.IO.File.Move(filePath, newfilePath);
                }
                var url = new Uri($"{Request.Scheme}://{Request.Host}/{today}/{newFileName}");
                return Content(url.ToString());
            }
            return BadRequest("not found file in form");
        }
    }
}
