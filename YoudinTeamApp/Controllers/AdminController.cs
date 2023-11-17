using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace YoudinTeamApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProjectPortfolio()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile postedFile)
        {
            if(postedFile != null)
            {
                string uploads = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/img");
                if (postedFile.Length > 0)
                {
                    string filePath = Path.Combine(uploads, postedFile.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await postedFile.CopyToAsync(fileStream);
                    }
                }
                return Ok();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult UploadFile2(string content)
        {
            int b = 6;
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImageTrix(object obj)
        {
            //int b = 6;
            //var length = Request.ContentLength;
            //var bytes = new byte[(int)length];
            //var butes2 =  await Request.Body.ReadAsync(bytes, 0, (int)length);
            //var dsad =  Request.Body.ReadByte;
            //MemoryStream memoryStream = new MemoryStream();
            //memoryStream.to
            // bytes has byte content here. what do do next?

            //var fileName = Request.Headers["X-File-Name"];
            //var fileSize = Request.Headers["X-File-Size"];
            //var fileType = Request.Headers["X-File-Type"];
            //string saveToFileLoc = _webHostEnvironment.ContentRootPath + "wwwroot/img";
            //try
            //{
            //    var fileStream = new FileStream("C:\\Users\\andre\\source\\repos\\YoudinTeamApp\\YoudinTeamApp\\wwwroot\\img\\lelelelele2.png", FileMode.Create, FileAccess.ReadWrite);
            //    //fileStream.WriteByte(bytes3);
            //    //fileStream.Write(bytes, 0, (int)length);
            //    fileStream.Close();
            //}
            //catch(Exception ex)
            //{
            //    var p = ex.ToString() + ex.Message;
            //}         
            return Ok();
        }
        }
}
