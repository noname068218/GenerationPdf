using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    public class OfferAcceptanceSignatures
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna o imposta la property PresentationInfo dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>PresentationInfo</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? PresentationInfo { get; set; }

        /// <summary>
        /// Ritorna o imposta la property OrderIndex dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>OrderIndex</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? PositionIndex { get; set; } = 6;

        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Title { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SoftwareName dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>SoftwareName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Definition { get; set; }


        /// <summary>
        /// Ritorna o imposta la property SignatureDataUrl dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>SignatureDataUrl</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? SignatureDataUrl { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SignatureSrc dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>SignatureSrc</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? SignatureSrc { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SignatureAlt dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>SignatureAlt</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? SignatureAlt { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SignatureWidth dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>SignatureWidth</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? SignatureWidth { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SignatureHeight dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>SignatureHeight</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? SignatureHeight { get; set; }

        /// <summary>
        /// Ritorna o imposta la property CompanyName dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>CompanyName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? CompanyName { get; set; }

        /// <summary>
        /// Ritorna o imposta la property CompanyName dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>CompanyName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? NameOfComrecial { get; set; }

        /// <summary>
        /// Ritorna o imposta la property ClieantName dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>ClieantName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? ClieantName { get; set; }

        /// <summary>
        /// Ritorna o imposta la property ClieantName dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>ClieantName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? ClieantCompany { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SignatureDate dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>SignatureDate</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public DateTime? SignatureDate { get; set; }

        /// <summary>
        /// Ritorna o imposta la property ClientSignatureDate  dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>ClientSignatureDate </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public DateTime? ClientSignatureDate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property CompanySignatureDate   dell'entità (<see cref=OfferAcceptanceSignatures/>)
        /// </summary>
        /// <value>
        /// della property <c>CompanySignatureDate  </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public DateTime? CompanySignatureDate { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
