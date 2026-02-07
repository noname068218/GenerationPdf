using System;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Output DTO for offer template generation operations.
    /// Contains generated HTML, PDF bytes, and operation feedback.
    /// </summary>
    [DataContract(Name = "OutputOfferTemplateApi")]
    public class OutputOfferTemplateApi
    {
        /// <summary>
        /// Feedback information about the operation result (success, error, etc.)
        /// </summary> 
        [DataMember(IsRequired = true)]
        public BaseApiFeedback Feedback { get; set; } = new();

        /// <summary>
        /// Generated PDF file as byte array
        /// </summary>
        [DataMember(IsRequired = false)]
        public byte[]? PdfBytes { get; set; }
    }
}