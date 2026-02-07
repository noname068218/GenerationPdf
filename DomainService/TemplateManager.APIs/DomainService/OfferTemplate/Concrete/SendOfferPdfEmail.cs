using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.APIs.DomainService
{
    public class SendOfferPdfEmail
    {
        public string EmailAddress { get; set; } = "";
        public string? Subject { get; set; }
        public TemplateManager.Common.ObjectModel.OfferContract Model { get; set; } = default!;
    }
}
