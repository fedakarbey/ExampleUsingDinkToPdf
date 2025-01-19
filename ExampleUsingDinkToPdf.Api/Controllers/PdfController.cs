using ExampleUsingDinkToPdf.Api.Model;
using ExampleUsingDinkToPdf.Api.PdfService;
using Microsoft.AspNetCore.Mvc;

namespace ExampleUsingDinkToPdf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpPost("generate")]
        public IActionResult GeneratePdf([FromBody] PdfRequest request)
        {
            // TemplateName ve CustomerInfo'nın varlığı kontrol ediliyor
            if (string.IsNullOrEmpty(request.TemplateName) || string.IsNullOrEmpty(request.ReportTitle) || request.CustomerInfo == null || !request.CustomerInfo.Any())
            {
                return BadRequest("Geçerli bir şablon adı, başlık ve müşteri bilgileri gereklidir.");
            }

            // PDF oluşturuluyor
            var pdfBytes = _pdfService.GeneratePdf(request);

            // PDF dosyasını döndür
            return File(pdfBytes, "application/pdf", "generated_report.pdf");
        }
    }
}
