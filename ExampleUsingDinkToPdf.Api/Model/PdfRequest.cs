namespace ExampleUsingDinkToPdf.Api.Model
{
    public class PdfRequest
    {
        // Kullanıcı tarafından seçilecek template adı
        public string TemplateName { get; set; }

        // Raporun başlığı
        public string ReportTitle { get; set; }

        // Rapor tarihi
        public string ReportDate { get; set; }

        // Raporun içeriği
        public List<CustomerInfo> CustomerInfo { get; set; }
    }
}
