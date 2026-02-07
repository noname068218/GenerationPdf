using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TemplateManager.Common.ObjectModel;
using TemplateManager.APIs.Application;
using TemplateManager.Common;
using TemplateManager.Common.Arguments;

namespace TemplateManager.APIs.DomainService
{
    /// <summary>
    /// Servizio per la generazione di offerte commerciali.
    /// Carica i paragrafi dal database, compone il contratto e sostituisce i placeholder.
    /// </summary>
    public class OfferTemplateServiceApi : BaseServiceExtension, IOfferTemplateServiceApi
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OfferTemplateServiceApi"/>.
        /// </summary>
        public OfferTemplateServiceApi()
        {
        }

        /// <summary>
        /// Genera l'offerta commerciale caricando i paragrafi dal database e compilando il contratto.
        /// Sostituisce i placeholder con i valori del modello e compone tutte le sezioni dell'offerta.
        /// </summary>
        /// <param name="input">Istanza dell'entità <see cref="OfferContract"/> contenente i dati dell'offerta.</param>
        /// <returns>Istanza di <see cref="OutputOfferTemplateApi"/> con il risultato dell'operazione.</returns>
        public async Task<OutputOfferTemplateApi> GenerateAsync(OfferContract input)
        {
            var output = new OutputOfferTemplateApi { Feedback = new BaseApiFeedback() };

            try
            {
                input.AlphaCode = NormalizeAlphaCode(input.Locale, input.AlphaCode);
                var paragraphsApi = DomainServiceAPIs.GetTemplateParagraphServiceApi();

                // Carica e compone una sezione del template dal database.
                // Ordina i paragrafi per PositionIndex e li unisce in un unico HTML.
                async Task<(string? Title, string Html)?> LoadComposeSectionAsync(string sectionName)
                {
                    var criteria = new TemplateParagraphApiSearchCriteria
                    {
                        NameOfTemplate = sectionName,
                        AlphaCode = input.AlphaCode,
                        CodeTemplate = input.CodeTemplate
                    };

                    var result = await paragraphsApi.LoadListAsync(criteria);
                    if (result?.ListTemplateParagraph is null || result.ListTemplateParagraph.Count == 0)
                        return null;

                    var ordered = result.ListTemplateParagraph
                                         .OrderBy(p => p.PositionIndex ?? int.MaxValue)
                                         .ToList();

                    var title = ordered.FirstOrDefault()?.Title;
                    var htmlBuilder = new StringBuilder();

                    foreach (var para in ordered)
                    {
                        if (string.IsNullOrWhiteSpace(para.Paragraph) &&
                            string.IsNullOrWhiteSpace(para.Subtitle))
                            continue;

                        if (!string.IsNullOrWhiteSpace(para.Subtitle))
                        {
                            var subtitle = WebUtility.HtmlDecode(para.Subtitle);
                            htmlBuilder.Append($"<h3 class=\"subtitle\">{subtitle}</h3>");
                        }

                        if (!string.IsNullOrWhiteSpace(para.Paragraph))
                        {

                            var paragraphText = WebUtility.HtmlDecode(para.Paragraph.Trim());

                            if (!paragraphText.StartsWith("<p", StringComparison.OrdinalIgnoreCase) &&
                                !paragraphText.StartsWith("<div", StringComparison.OrdinalIgnoreCase) &&
                                !paragraphText.StartsWith("<ul", StringComparison.OrdinalIgnoreCase) &&
                                !paragraphText.StartsWith("<ol", StringComparison.OrdinalIgnoreCase))
                            {
                                htmlBuilder.Append($"<p>{paragraphText}</p>");
                            }
                            else
                            {
                                htmlBuilder.Append(paragraphText);
                            }
                        }
                    }

                    var html = htmlBuilder.ToString();
                    html = ReplacePlaceholders(html, input);

                    return (title, html);
                }

                var offerContract = await LoadComposeSectionAsync("OfferContract");

                var def = await LoadComposeSectionAsync("DefinitionOfOffer");
                if (def.HasValue)
                {
                    input.DefinitionOfOffer ??= new DefinitionOfOffer();
                    input.DefinitionOfOffer.Title = def.Value.Title;
                    input.DefinitionOfOffer.Definition = def.Value.Html;
                    input.DefinitionOfOffer.Application ??= input.Application;

                    if (offerContract.HasValue && !string.IsNullOrWhiteSpace(offerContract.Value.Html))
                    {
                        input.DefinitionOfOffer.Subtitle = offerContract.Value.Html;
                    }
                }
                else if (offerContract.HasValue)
                {
                    input.DefinitionOfOffer ??= new DefinitionOfOffer();
                    input.DefinitionOfOffer.Subtitle = offerContract.Value.Html;
                    input.DefinitionOfOffer.Application ??= input.Application;
                }

                var cond = await LoadComposeSectionAsync("ConditionForTermination")
                           ?? await LoadComposeSectionAsync("ConditionTermination");
                if (cond.HasValue)
                {
                    input.ConditionForTermination ??= new ConditionForTermination();
                    input.ConditionForTermination.Title = cond.Value.Title;
                    input.ConditionForTermination.Definition = cond.Value.Html;
                }

                var maint = await LoadComposeSectionAsync("AssistanceAndMaintenance");
                if (maint.HasValue)
                {
                    input.AssistanceAndMaintenance ??= new AssistanceAndMaintenance();
                    input.AssistanceAndMaintenance.Title = maint.Value.Title;
                    input.AssistanceAndMaintenance.Definition = maint.Value.Html;
                }

                var delivery = await LoadComposeSectionAsync("Delivery");
                if (delivery.HasValue)
                {
                    input.Delivery ??= new Delivery();
                    input.Delivery.Title = delivery.Value.Title;
                    input.Delivery.Definition = delivery.Value.Html;
                }

                var install = await LoadComposeSectionAsync("InstallationAndInstruction");
                if (install.HasValue)
                {
                    input.InstallationAndInstruction ??= new InstallationAndInstruction();
                    input.InstallationAndInstruction.Title = install.Value.Title;
                    input.InstallationAndInstruction.Definition = install.Value.Html;
                }

                var payment = await LoadComposeSectionAsync("PaymentConditions");
                if (payment.HasValue)
                {
                    input.PaymentConditions ??= new PaymentConditions();
                    input.PaymentConditions.Title = payment.Value.Title;
                    input.PaymentConditions.Definition = payment.Value.Html;
                }

                var attach = await LoadComposeSectionAsync("AttachmentsConditions");
                if (attach.HasValue)
                {
                    input.AttachmentsConditions ??= new AttachmentsConditions();
                    input.AttachmentsConditions.Title = attach.Value.Title;
                    input.AttachmentsConditions.Definition = attach.Value.Html;
                    input.AttachmentsConditions.AlphaCode = input.AlphaCode;
                }

                var offerCond = await LoadComposeSectionAsync("OfferConditions");
                if (offerCond.HasValue)
                {
                    input.OfferConditions ??= new OfferConditions();
                    input.OfferConditions.Title = offerCond.Value.Title;
                    input.OfferConditions.Definition = offerCond.Value.Html;
                    input.OfferConditions.NameClient ??= input.Customer;
                }

                var signatures = await LoadComposeSectionAsync("OfferAcceptanceSignatures");
                if (signatures.HasValue)
                {
                    input.OfferAcceptanceSignatures ??= new OfferAcceptanceSignatures();
                    input.OfferAcceptanceSignatures.Title = signatures.Value.Title;
                    input.OfferAcceptanceSignatures.Definition = signatures.Value.Html;
                    input.OfferAcceptanceSignatures.CompanyName ??= input.CompanyName;
                }



                output.Successfully = true;
                output.Html = null;
                output.PdfBytes = null;
                output.Feedback.StatusCode = StatusCodesApi.Success;
                return output;
            }
            catch (Exception)
            {
                output.Feedback.StatusCode = StatusCodesApi.Error;
                output.Feedback.EVLogApi.MessageErrore = "Errore durante la generazione di HTML/PDF dell'Offerta.";
                return output;
            }
        }

        /// <summary>
        /// Normalizza il codice lingua in formato standard (IT o EN).
        /// Gestisce vari formati di input come "IT-IT", "EN-US", "it", "en", etc.
        /// </summary>
        /// <param name="locale">Codice locale da normalizzare.</param>
        /// <param name="alpha">Codice alpha alternativo da normalizzare.</param>
        /// <returns>Codice lingua normalizzato ("IT" o "EN"). Default: "IT".</returns>
        private static string NormalizeAlphaCode(string? locale, string? alpha)
        {
            if (!string.IsNullOrWhiteSpace(alpha))
            {
                var a = alpha.Trim().ToUpperInvariant();
                if (a.Length > 2)
                {
                    if (a.StartsWith("IT")) return "IT";
                    if (a.StartsWith("EN")) return "EN";
                }
                return a.Length == 2 ? a : a switch { "IT-IT" => "IT", "EN-US" => "EN", _ => a };
            }
            if (string.IsNullOrWhiteSpace(locale)) return "IT";
            var l = locale.Trim().ToUpperInvariant();
            if (l.StartsWith("IT")) return "IT";
            if (l.StartsWith("EN")) return "EN";
            return "IT";
        }

        /// <summary>
        /// Sostituisce i placeholder nell'HTML con i valori dal modello.
        /// Supporta i segnaposto: {{NameClient}}, {{Year}}, {{CompanyName}}, {{Date}}, 
        /// {{TechnicalHourlyRate}}, {{RegulatoryHourlyRate}}, {{DeliveryDays}}, 
        /// {{BeforeDoubleTimeOffer}}, {{AfterDoubleTimeOffer}}, {{DoubleTimeOffer}}.
        /// {{DoubleTimeOffer}} può essere usato più volte: la prima occorrenza → prima parte, la seconda → seconda parte.
        /// </summary>
        /// <param name="html">Contenuto HTML con placeholder da sostituire.</param>
        /// <param name="model">Istanza della classe <see cref="OfferContract"/> con i valori da utilizzare.</param>
        /// <returns>HTML con i placeholder sostituiti dai valori reali.</returns>
        private static string ReplacePlaceholders(string html, OfferContract model)
        {
            // Controllo per HTML di input vuoto
            if (string.IsNullOrEmpty(html)) return string.Empty;
            var result = html;

            // Estrazione dell'anno: prima da AssetOfOfferCosts, se assente da DateOffer, altrimenti stringa vuota
            var year = model.AssetOfOfferCosts?.Year?.ToString() ?? model.DateOffer?.Year.ToString() ?? string.Empty;

            // Formattazione della data in formato dd/MM/yyyy (es. "15/01/2025")
            var dateStr = model.DateOffer?.ToString("dd/MM/yyyy") ?? string.Empty;

            // Installazione e istruzioni - tariffe orarie fisse
            var technicalRate = "€ 96 + IVA";
            var regulatoryRate = "€ 115 + IVA";

            // Consegna - estrazione giorni di consegna dal modello, altrimenti valore di default
            var deliveryDays = model.Delivery?.DeliveryDays ?? "Ca. 10 gg. R.O.";

            //// Condizioni di pagamento - parsing della stringa per separare la parte prima e dopo "/"
            //// Se la stringa contiene "/" vengono estratte due parti, ognuna formattata con il tag <strong>
            //// Se non c'è "/" viene usato lo stesso valore per entrambe le parti
            //var (beforeDoubleTimeOffer, afterDoubleTimeOffer) = ParsePayment.ParsePaymentConditions(
            //    model.PaymentConditions?.DoubleTimeOffer);


            //Condizioni di pagamento
            var doubleDateTime = model.PaymentConditions.DoubleTimeOffer ?? "";

            var singalDateTime = model.PaymentConditions.SingleTimeOffer ?? "";

            var footerDateTime = model.PaymentConditions.FooterDate ?? "";
            //



            var map = new Dictionary<string, string?>
            {
                { "{{NameClient}}", model.OfferConditions?.NameClient ?? model.Customer },
                { "{{Year}}", year },
                { "{{CompanyName}}", model.CompanyName },
                { "{{Date}}", dateStr },
                { "{{TechnicalHourlyRate}}", technicalRate },
                { "{{RegulatoryHourlyRate}}", regulatoryRate },
                { "{{DeliveryDays}}", deliveryDays },
                { "{{DoubleTimeOffer}}", doubleDateTime },
                { "{{SingleTimeOffer}}", singalDateTime },
                { "{{FooterDate}}", footerDateTime }
            };
            foreach (var kv in map)
            {
                result = result.Replace(kv.Key, kv.Value ?? string.Empty, StringComparison.OrdinalIgnoreCase);
            }
            //result = ParsePayment.ReplaceDoubleTimeOfferSequentially(result, beforeDoubleTimeOffer, afterDoubleTimeOffer);

            return result;
        }

    }
}
