using MagazineWebService.AuthFilterAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {

        [FilterAPI(Role = 5, Add = true)]
        [HttpPost()]
        public async Task<IActionResult> Upload([FromForm] Model.Post.File fileInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                IFormFile file = fileInput.file;

                string host = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
                Directory.CreateDirectory(Path.Combine(host));

                var pathImage = Path.Combine(host, file.FileName);
                using (var stream = new FileStream(pathImage, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                }
                string id = ChangeNameFile(pathImage, file);
                return Ok(new { stutes = true, path = Path.Combine("Image", id + file.FileName) });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    res = ex.Message
                });
            }
        }
        private string ChangeNameFile(string path, IFormFile fie)
        {
            try
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                var stringChars = new char[30];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                System.IO.File.Move(path, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image", finalString + fie.FileName));
                System.IO.File.Delete(path);
                return finalString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
