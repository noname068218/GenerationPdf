using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.DomainService
{
    /// <summary>
    /// DTO
    /// </summary>
    public class OutputOfferTemplateApi
    {
        public BaseApiFeedback Feedback { get; set; } = new();
        public bool Successfully { get; set; }
        public string? Html { get; set; }
        public byte[]? PdfBytes { get; set; }
    }
}
