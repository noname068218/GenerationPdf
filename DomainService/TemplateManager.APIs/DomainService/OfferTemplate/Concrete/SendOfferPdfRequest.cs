using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.DomainService
{
    public sealed class SendOfferPdfRequest
    {
        public OfferContract Offer { get; set; } = default!; 
        public string EmailAddress { get; set; } = "";     
        public string? Subject { get; set; }                 
        public string? BodyHtml { get; set; }               
        public List<string>? Cc { get; set; }                
        public List<string>? Bcc { get; set; }

        public string? AlphaCode { get; set; }   // "en", "it-IT", ...
    }
}
