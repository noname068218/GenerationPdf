using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    [DataContract(Name = "SendOfferPdfRequest")]
    public class SendOfferPdfRequest
    {
        [DataMember(IsRequired = true)]
        public OfferContract? Offer { get; set; }

        [DataMember(IsRequired = true)]
        public string? EmailAddress { get; set; }

        [DataMember(IsRequired = false)]
        public string? Subject { get; set; }

        [DataMember(IsRequired = false)]
        public string? BodyHtml { get; set; }

        [DataMember(IsRequired = false)]
        public List<string>? Cc { get; set; }

        [DataMember(IsRequired = false)]
        public List<string>? Bcc { get; set; }
    }
}