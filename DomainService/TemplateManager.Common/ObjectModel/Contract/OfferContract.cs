using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common.ObjectModel.Contract;

namespace TemplateManager.Common.ObjectModel
{
    public class OfferContract
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
        /// Ritorna o imposta la property Id dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Id</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? CodeOffer { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Id dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Id</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Application { get; set; }

        /// <summary>
        /// Template code used to select static texts from DB (TemplateParagraph.CodeTemplate)
        /// </summary>
        [DataMember(IsRequired = false)]
        public Int32? CodeTemplate { get; set; }



        /// <summary>
        /// Ritorna o imposta la property CompanyName dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>CompanyName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? CompanyName { get; set; }


        /// <summary>
        /// Ritorna o imposta la property CompanyName dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>CompanyName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public List<string>? EmailAddress { get; set; }


        /// <summary>
        /// Ritorna o imposta la property CompanyName dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>CompanyName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public List<string>? Cc { get; set; }


        /// <summary>
        /// Ritorna o imposta la property CompanyName dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>CompanyName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public List<string>? Bcc { get; set; }



        /// <summary>
        /// Ritorna o imposta la property VATNumber dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>VATNumber</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? VATNumber { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Customer dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Customer</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Customer { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Email dell'entità (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Email</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? EmailCustomer { get; set; }

        /// <summary>
        /// Data di invio dell'offerta (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Email</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public DateTime? DateOffer { get; set; }



        /// <summary>
        /// Lenguage AlphaCode (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? AlphaCode { get; set; }

        /// <summary>
        /// Input locale (e.g. "it-IT", "en-US"). Used to derive AlphaCode when not provided.
        /// </summary>
        [DataMember(IsRequired = false)]
        public String? Locale { get; set; }

        /// <summary>
        /// E' la descrizione dei produtti con la lista dei moduli acquistati (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Email</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public DefinitionOfOffer? DefinitionOfOffer { get; set; }

        /// <summary>
        /// 2	Modalità di cessione del software (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Email</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public ConditionForTermination? ConditionForTermination { get; set; }

        /// <summary>
        /// 3	Assistenza e Manutenzione (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>Email</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public AssistanceAndMaintenance? AssistanceAndMaintenance { get; set; }

        /// <summary>
        /// 4	Costi (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>AssetOfOfferCosts</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public AssetOfOfferCosts? AssetOfOfferCosts { get; set; }

        /// <summary>
        /// 5	Consegna (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>AssetOfOfferCosts</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Delivery? Delivery { get; set; }

        /// <summary>
        /// 6	Installazione ed istruzione (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>AssetOfOfferCosts</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public InstallationAndInstruction? InstallationAndInstruction { get; set; }

        /// <summary>
        ///Condizioni di pagamento (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>PaymentConditions</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public PaymentConditions? PaymentConditions { get; set; }

        /// <summary>
        /// 8 Allegati (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>AttachmentsConditions</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public AttachmentsConditions? AttachmentsConditions { get; set; }


        /// <summary>
        /// 9 Condizioni d’offerta (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>OfferConditions</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public OfferConditions? OfferConditions { get; set; }


        /// <summary>
        /// 10 Firme di offerta e accettazione (<see cref=OfferContract/>)
        /// </summary>
        /// <value>
        /// della property <c>OfferAcceptanceSignatures</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public OfferAcceptanceSignatures? OfferAcceptanceSignatures { get; set; }


        #endregion

        #endregion

        #endregion

    }
}
