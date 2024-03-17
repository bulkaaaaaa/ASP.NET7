using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationn7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
       // [Route("File/DownloadFile")]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
       // [Route("File/DownloadFile")]
        public async Task<IActionResult> DownloadFile(string firstName, string lastName, string fileName)
        {
           
            var fileContent = $"Ім'я: {firstName}\nПрізвище: {lastName}";

            // шлях для збереження файлу (знаходиться у корені додатку)
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{fileName}.txt");

            await System.IO.File.WriteAllTextAsync(filePath, fileContent, Encoding.UTF8);

            return PhysicalFile(filePath, "text/plain", $"{fileName}.txt");
        }
    }
}
