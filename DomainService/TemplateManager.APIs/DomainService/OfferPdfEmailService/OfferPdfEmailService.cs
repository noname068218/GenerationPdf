// ============================================
// Service per generazione PDF e invio Email
// ============================================
using EmailNotification.Common.ObjectModel;
using TemplateManager.Common.ObjectModel;
using TMOM = TemplateManager.Common.ObjectModel;
using TM = TemplateManager.Common;
using TemplateManager.APIs.Business.EmailNotification;

namespace TemplateManager.APIs.DomainService
{
    /// <summary>
    /// Service per generare PDF da offerta con QuestPDF e inviare email con allegato.
    /// Integra TemplateManager con EmailNotification API.
    /// Sistema LEGACY (Razor+Puppeteer) rimosso - ora usa solo QuestPDF per performance.
    /// </summary>
    public sealed class OfferPdfEmailService : IOfferPdfEmailService
    {
        #region FIELDS

        private readonly IOfferTemplateServiceApi _offerTemplateApi;
        private readonly IQuestPdfRenderer _questPdfRenderer;
        private readonly BuildersEmailNotification _buildersEmail = new();

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Costruttore con dependency injection - Solo QuestPDF (veloce e moderno).
        /// </summary>
        public OfferPdfEmailService(
            IOfferTemplateServiceApi offerTemplateApi,
            IQuestPdfRenderer questPdfRenderer)
        {
            _offerTemplateApi = offerTemplateApi;
            _questPdfRenderer = questPdfRenderer;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Metodo principale per generare PDF da offerta e inviarlo via email.
        /// Esegue l'intero flusso: carica testi DB → genera PDF → invia email con allegato.
        /// </summary>
        /// <param name="input">Richiesta con dati offerta e destinatario email</param>
        /// <param name="ct">Cancellation token per operazioni async</param>
        /// <returns>Output con feedback operazione (successo/errore)</returns>
        public async Task<OutputRequestLicenseManager> SendAsync(SendOfferPdfRequest input, CancellationToken ct = default)
        {
            // Inizializza output con feedback di default
            var output = new OutputRequestLicenseManager { Feedback = new TMOM.BaseApiFeedback() };

            try
            {
                // === VALIDAZIONE INPUT ===
                // Verifica che offerta e email siano presenti
                if (input?.Offer == null || string.IsNullOrWhiteSpace(input.EmailAddress))
                {
                    output.Feedback.StatusCode = TM.StatusCodesApi.Error;
                    output.Feedback.EVLogApi.MessageErrore = "Offer o EmailAddress non forniti.";
                    return output;
                }

                // === STEP 1: CARICA DATI DA DB ===
                // Carica testi statici da DB (TemplateParagraph) e compone offerta completa
                var composed = await _offerTemplateApi.GenerateAsync(input.Offer);
                
                // Verifica successo composizione
                if (composed is null || !composed.Successfully)
                {
                    output.Feedback.StatusCode = TM.StatusCodesApi.Error;
                    output.Feedback.EVLogApi.MessageErrore = "Errore durante caricamento dati da DB.";
                    return output;
                }
                
                // === STEP 2: GENERA PDF CON QUESTPDF ===
                // Usa QuestPDF per generazione veloce (non più Puppeteer)
                var pdfBytes = _questPdfRenderer.GeneratePdf(input.Offer);
                
                if (pdfBytes is null || pdfBytes.Length == 0)
                {
                    output.Feedback.StatusCode = TM.StatusCodesApi.Error;
                    output.Feedback.EVLogApi.MessageErrore = "PDF generato è vuoto.";
                    return output;
                }
                
                var fileName = $"Offerta_{input.Offer.CodeOffer}.pdf";

                // === STEP 3: PREPARA EMAIL ===
                // Imposta oggetto e corpo email (con valori di default se non forniti)
                var subject = string.IsNullOrWhiteSpace(input.Subject) 
                    ? $"Offerta {input.Offer.CodeOffer}" 
                    : input.Subject!;
                
                var bodyHtml = string.IsNullOrWhiteSpace(input.BodyHtml) 
                    ? "In allegato trovi il PDF dell'offerta." 
                    : input.BodyHtml!;

                // Costruisce oggetto email usando BuildersEmailNotification
                var emailApi = _buildersEmail.BuildNewTemplate(
                    input.EmailAddress,
                    subject,
                    bodyHtml,
                    out TMOM.BaseApiFeedback buildFeed
                );

                // Verifica eventuali errori durante costruzione template email
                if (buildFeed is not null && buildFeed.StatusCode == TM.StatusCodesApi.Error)
                {
                    output.Feedback = buildFeed;
                    return output;
                }

                // === STEP 4: ALLEGA PDF ===
                // Aggiunge PDF come allegato all'email (convertito in Base64)
                emailApi.FileAttachment.Add(new FileAttachmentApi
                {
                    FileName = fileName,
                    Extension = "application/pdf",
                    DataBase64 = Convert.ToBase64String(pdfBytes)
                });

                // === STEP 5: INVIA EMAIL ===
                // Delega invio a EmailNotification API esterno
                output = await SendEmailNotificationAsync(emailApi);
            }
            catch (Exception ex)
            {
                // Gestione errori generici con feedback dettagliato
                output.Feedback.StatusCode = TM.StatusCodesApi.Error;
                output.Feedback.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null)
                    output.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }

            return output;
        }

        /// <summary>
        /// Invia email tramite EmailNotification API.
        /// Wrapper per chiamata a EmailNotification.UI (DLL esterna).
        /// </summary>
        /// <param name="emailApi">Oggetto email configurato con destinatari e allegati</param>
        /// <returns>Output con feedback dell'operazione di invio</returns>
        private async Task<OutputRequestLicenseManager> SendEmailNotificationAsync(SendNewEmailApi emailApi)
        {
            // Inizializza output con feedback TemplateManager
            var output = new OutputRequestLicenseManager { Feedback = new TMOM.BaseApiFeedback() };

            try
            {
                // Chiama EmailNotification API (libreria esterna DLL)
                // Wrappa chiamata sincrona in Task per compatibilità async
                var resultEmail = await Task.Run(() =>
                {
                    var emailService = EmailNotification.UI.Application.DomainServiceUI.GetEmailManagerService();
                    return emailService.SendNewEmailAsync(emailApi);
                });

                // Mappa risultato da EmailNotification a TemplateManager
                // FeedBackOperation ha struttura: resultEmail.Feedback.StatusCode (enum StatusCodesApi)
                // Nota: Esistono DUE enum StatusCodesApi (TemplateManager e EmailNotification),
                //       quindi compariamo con codice numerico 200 = Success
                var isSuccess = ((int)resultEmail.Feedback.StatusCode) == 200; // 200 = Success
                output.Feedback.StatusCode = isSuccess 
                    ? TM.StatusCodesApi.Success
                    : TM.StatusCodesApi.Error;

                // Aggiunge messaggio di errore se invio fallito
                if (!isSuccess)
                {
                    output.Feedback.EVLogApi.MessageErrore = 
                        resultEmail.Feedback.EVLogApi.MessageErrore ?? "Errore invio email";
                }
            }
            catch (Exception ex)
            {
                // Gestione errori durante invio email
                output.Feedback.StatusCode = TM.StatusCodesApi.Error;
                output.Feedback.EVLogApi.MessageErrore = ex.Message;
            }

            return output;
        }

        #endregion
    }
}
