using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesseract;

namespace TesseractWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        [HttpPost]
        public Task<string> Recognize(string base64Image)
        {
            return new Task<string>(() =>
            {
                using (var engine = new TesseractEngine("C:\\Program Files\\Tesseract-OCR\\tessdata", "eng", EngineMode.Default))
                {

                    using (var image = Pix.LoadFromMemory(System.Convert.FromBase64String(base64Image)))
                    {
                        using (var page = engine.Process(image))
                        {
                            return page.GetText();
                        }
                    }
                }
            });

           
        }
    }
}
