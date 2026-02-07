using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.APIs.DomainService
{
    public interface IPdfRenderer
    {
        Task<byte[]> HtmlToPdfAsync(string html, PdfRenderOptions? options = null);
    }


    public sealed class PdfRenderOptions
    {
        public string PaperFormat { get; set; } = "A4"; 
        public string? MarginTop { get; set; } = "15mm";
        public string? MarginRight { get; set; } = "12mm";
        public string? MarginBottom { get; set; } = "15mm";
        public string? MarginLeft { get; set; } = "12mm";
        public bool PrintBackground { get; set; } = true;
    }
}
