using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace RapidAPI.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes= stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType= new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipart= new MultipartFormDataContent();
            multipart.Add(byteArrayContent, "file", file.FileName);
            var httpclient = new HttpClient();
            await httpclient.PostAsync("http://localhost:38080/api/FileImage", multipart);
           
            return View();
        }

        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipart = new MultipartFormDataContent();
            multipart.Add(byteArrayContent, "file", file.FileName);
            var httpclient = new HttpClient();
            await httpclient.PostAsync("http://localhost:38080/api/FileProcess", multipart);

            return View();
        }
    }
}
