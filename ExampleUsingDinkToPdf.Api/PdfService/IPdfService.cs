using ExampleUsingDinkToPdf.Api.Model;

namespace ExampleUsingDinkToPdf.Api.PdfService
{
    public interface IPdfService
    {
        // PDF oluşturulması için template adı ve veri parametreleri alacak
        byte[] GeneratePdf(PdfRequest request);
    }
}
