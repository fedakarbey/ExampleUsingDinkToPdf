using DinkToPdf;
using DinkToPdf.Contracts;
using ExampleUsingDinkToPdf.Api.Model;
using ExampleUsingDinkToPdf.Api.PdfService;
using System;
using System.IO;

namespace PdfGeneratorApi.PdfService
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService()
        {
            // Ensure the DLL is in the correct path
            var wkhtmltoxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libwkhtmltox.dll");
            if (!File.Exists(wkhtmltoxPath))
            {
                throw new FileNotFoundException("The libwkhtmltox.dll file was not found.", wkhtmltoxPath);
            }

            _converter = new SynchronizedConverter(new PdfTools());
        }

        public byte[] GeneratePdf(PdfRequest request)
        {
            // Template dosyasını yükleyelim
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", $"{request.TemplateName}.html");
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template '{request.TemplateName}' not found.", templatePath);
            }

            string htmlContent = File.ReadAllText(templatePath);

            // Template içeriğini kullanıcı verisi ile dolduralım
            htmlContent = htmlContent.Replace("{{ReportTitle}}", request.ReportTitle);
            htmlContent = htmlContent.Replace("{{ReportDate}}", request.ReportDate);

            // Müşteri bilgilerini ekleyelim
            string customerInfoHtml = string.Empty;
            foreach (var customer in request.CustomerInfo)
            {
                customerInfoHtml += $"<tr><td>{customer.CustomerName}</td><td>{customer.Amount:C}</td><td>{customer.Status}</td></tr>";
            }
            htmlContent = htmlContent.Replace("{{CustomerInfo}}", customerInfoHtml);

            // CSS dosyasının tam yolunu belirtelim
            string cssFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "Style", "template-style.css");


            // PDF dönüşüm ayarları
            var document = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings
                    {
                        Top = 5,
                        Bottom = 3,
                        Left = 2,
                        Right = 2
                    }
                },
                Objects = {
            new ObjectSettings
            {
                HtmlContent = htmlContent,
                WebSettings = { 
                    DefaultEncoding = "utf-8",
                    UserStyleSheet = cssFilePath
                },
            }
        }
            };

            return _converter.Convert(document);
        }
    }
}
