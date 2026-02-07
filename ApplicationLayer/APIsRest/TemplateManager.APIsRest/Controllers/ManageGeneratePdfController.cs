// ============================================
// Using statements necessari
// =============================================
using Microsoft.AspNetCore.Mvc;
using TemplateManager.Common.ObjectModel;
using TemplateManager.APIs.DomainService;

namespace TemplateManager.APIs.Controllers
{
    /// <summary>
    /// Controller per gestione offerte commerciali.
    /// Supporta generazione HTML, PDF (Puppeteer/QuestPDF) e invio Email.
    /// </summary>
    [Route("ServiceApi/V1.0/[controller]")]
    [ApiController]
    public class ManageGeneratePdfController : ControllerBase
    {
        #region FIELDS

        private readonly IOfferPdfEmailService _offerPdfEmail;
        private readonly IOfferTemplateServiceApi _offerTemplateApi;
        private readonly IQuestPdfRenderer _questPdfRenderer;
        private readonly ILogger<ManageGeneratePdfController> _logger;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Costruttore con dependency injection - Solo servizi QuestPDF e DB.
        /// Sistema LEGACY (Razor/Puppeteer) rimosso per performance.
        /// </summary>
        public ManageGeneratePdfController(
            IOfferPdfEmailService offerPdfEmail,
            IOfferTemplateServiceApi offerTemplateApi,
            IQuestPdfRenderer questPdfRenderer,
            ILogger<ManageGeneratePdfController> logger)
        {
            _offerPdfEmail = offerPdfEmail;
            _offerTemplateApi = offerTemplateApi;
            _questPdfRenderer = questPdfRenderer;
            _logger = logger;
        }

        #endregion

        #region METHODS - API Endpoints

        /// <summary>
        /// Genera PDF con QuestPDF e invia per email.
        /// Carica automaticamente testi statici da DB e supporta CC, BCC.
        /// </summary>
        [HttpPost("SendPdfByEmailAsync")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OutputRequestLicenseManager), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OutputRequestLicenseManager>> SendPdfByEmailAsync(
            [FromBody] DomainService.SendOfferPdfRequest input,
            CancellationToken ct)
        {
            try
            {
                _logger.LogInformation("Invio email per offerta {CodeOffer}", input.Offer?.CodeOffer);

                // Delega al servizio dedicato (ora usa QuestPDF)
                var result = await _offerPdfEmail.SendAsync(input, ct);

                if (result.Feedback.StatusCode == Common.StatusCodesApi.Success)
                {
                    _logger.LogInformation("Email inviata con successo per {CodeOffer}", input.Offer?.CodeOffer);
                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("Fallimento invio email per {CodeOffer}: {Error}",
                        input.Offer?.CodeOffer,
                        result.Feedback.EVLogApi.MessageErrore);
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore invio email per {CodeOffer}", input.Offer?.CodeOffer);
                return StatusCode(500, new OutputRequestLicenseManager
                {
                    Feedback = new BaseApiFeedback
                    {
                        StatusCode = Common.StatusCodesApi.Error,
                        EVLogApi = new EVLogApi
                        {
                            MessageErrore = "Errore interno durante invio email",
                            InnerMessageErrore = ex.Message
                        }
                    }
                });
            }
        }

        /// <summary>
        /// [RACCOMANDATO] Genera PDF con QuestPDF
        /// Carica automaticamente testi statici da DB e compone documento completo.
        /// </summary>
        /// <param name="input">Dati minimi richiesti: CodeOffer, CompanyName, Customer, AlphaCode, CodeTemplate</param>
        /// <returns>Output con HTML e PDF in Base64</returns>
        [HttpPost("GenerateFileOfferAsync")]
        [ProducesResponseType(typeof(DomainService.OutputOfferTemplateApi), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DomainService.OutputOfferTemplateApi>> GenerateFileOfferAsync([FromBody] OfferContract input)
        {
            try
            {
                _logger.LogInformation("Generazione PDF per offerta {CodeOffer}", input.CodeOffer);

                // 1. Carica dati statici da DB (TemplateParagraph) e compone offerta completa
                var composedOffer = await _offerTemplateApi.GenerateAsync(input);

                if (!composedOffer.Successfully)
                {
                    _logger.LogWarning("Fallimento composizione offerta {CodeOffer}", input.CodeOffer);
                    return BadRequest(composedOffer.Feedback);
                }

                // 2. Genera PDF con QuestPDF (molto più veloce di Puppeteer)
                var pdfBytes = _questPdfRenderer.GeneratePdf(input);

                _logger.LogInformation("PDF generato con successo per {CodeOffer}, size: {Size} bytes",
                    input.CodeOffer, pdfBytes?.Length ?? 0);

                // 3. Restituisci risultato con HTML e PDF
                return Ok(new DomainService.OutputOfferTemplateApi
                {
                    Successfully = true,
                    Html = composedOffer.Html,
                    PdfBytes = pdfBytes,
                    Feedback = new BaseApiFeedback { StatusCode = Common.StatusCodesApi.Success }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore generazione PDF per {CodeOffer}", input.CodeOffer);
                return StatusCode(500, new
                {
                    error = "Errore interno durante la generazione del PDF",
                    details = ex.Message
                });
            }
        }

        /// <summary>
        /// Genera PDF con QuestPDF e lo restituisce come file scaricabile.
        /// Carica automaticamente testi statici da DB tramite CodeTemplate e AlphaCode.
        /// I dati dinamici (tabelle costi, firme, ecc.) devono essere forniti nel JSON di input.
        /// Questo endpoint è ottimizzato per il download diretto in Swagger e browser.
        /// </summary>
        /// <param name="input">
        /// Dati richiesti:
        /// - CodeOffer: codice univoco dell'offerta
        /// - CodeTemplate: ID template per caricare testi statici dal DB (es. 100)
        /// - AlphaCode: codice lingua per i testi (es. "IT", "EN")
        /// - CompanyName: nome azienda
        /// - Customer: nome cliente
        /// - AssetOfOfferCosts: tabella con moduli e costi (opzionale, se non fornito usa testi DB)
        /// - Altri campi opzionali per personalizzazione
        /// </param>
        /// <returns>File PDF pronto per il download</returns>
        [HttpPost("DownloadFileOfferAsync")]
        [Produces("application/pdf", "application/json")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseApiFeedback), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DownloadFileOfferAsync([FromBody] OfferContract input)
        {
            try
            {
                _logger.LogInformation("Generazione PDF per download - Offerta: {CodeOffer}", input.CodeOffer);

                // 1. Carica dati statici da DB (TemplateParagraph) tramite CodeTemplate e AlphaCode
                //    Se l'utente ha fornito dati personalizzati (es. AssetOfOfferCosts), questi vengono mantenuti
                //    Altrimenti vengono caricati i testi statici dal database
                var composedOffer = await _offerTemplateApi.GenerateAsync(input);

                if (!composedOffer.Successfully)
                {
                    _logger.LogWarning("Fallimento composizione offerta {CodeOffer}", input.CodeOffer);
                    return BadRequest(composedOffer.Feedback);
                }

                // 2. Genera PDF con QuestPDF (molto più veloce di Puppeteer)
                //    Usa il contratto completo con dati statici da DB + dati dinamici forniti dall'utente
                var pdfBytes = _questPdfRenderer.GeneratePdf(input);

                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    _logger.LogWarning("PDF generato è vuoto per {CodeOffer}", input.CodeOffer);
                    return BadRequest(new BaseApiFeedback
                    {
                        StatusCode = Common.StatusCodesApi.Error,
                        EVLogApi = new EVLogApi
                        {
                            MessageErrore = "Il PDF generato è vuoto"
                        }
                    });
                }

                _logger.LogInformation("PDF generato con successo per {CodeOffer}, dimensione: {Size} bytes",
                    input.CodeOffer, pdfBytes.Length);

                // 3. Restituisci PDF come file scaricabile
                //    Genera nome file con codice offerta e data corrente
                var fileName = $"Offerta_{input.CodeOffer}_{DateTime.Now:yyyyMMdd}.pdf";

                // Restituisce il file con Content-Type corretto per PDF
                // Questo farà apparire il pulsante "Download file" in Swagger
                return File(pdfBytes, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore generazione PDF per download - Offerta: {CodeOffer}", input.CodeOffer);
                return StatusCode(500, new BaseApiFeedback
                {
                    StatusCode = Common.StatusCodesApi.Error,
                    EVLogApi = new EVLogApi
                    {
                        MessageErrore = "Errore interno durante la generazione del PDF",
                        InnerMessageErrore = ex.Message
                    }
                });
            }
        }


        /// <summary>
        /// Get list of offers with pagination and filters (MOCK DATA for testing)
        /// POST: api/offers/list
        /// </summary>
        [HttpPost("GetOffersList")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public IActionResult GetOffersList([FromBody] object filters)
        {
            _logger.LogInformation("Richiesta lista offerte ricevuta");

            // MOCK DATA for testing DataGrid
            // TODO: Replace with real database query later
            var mockOffers = new[]
            {
        new
        {
            codeOffer = "OFF-2025-001",
            customer = "Acme Corporation",
            companyName = "MyCompany SRL",
            dateOffer = "2025-01-15",
            alphaCode = "IT",
            codeTemplate = 1,
            emailCustomer = "contact@acme.com",
            vatNumber = "IT12345678901"
        },
        new
        {
            codeOffer = "OFF-2025-002",
            customer = "Tech Solutions Ltd",
            companyName = "MyCompany SRL",
            dateOffer = "2025-01-20",
            alphaCode = "EN",
            codeTemplate = 1,
            emailCustomer = "info@techsolutions.com",
            vatNumber = "GB987654321"
        },
        new
        {
            codeOffer = "OFF-2025-003",
            customer = "Global Services Inc",
            companyName = "MyCompany SRL",
            dateOffer = "2025-01-25",
            alphaCode = "IT",
            codeTemplate = 2,
            emailCustomer = "sales@globalservices.com",
            vatNumber = "IT98765432109"
        },
        new
        {
            codeOffer = "OFF-2025-004",
            customer = "Innovation Labs",
            companyName = "MyCompany SRL",
            dateOffer = "2025-02-01",
            alphaCode = "EN",
            codeTemplate = 1,
            emailCustomer = "hello@innovationlabs.com",
            vatNumber = "DE123456789"
        },
        new
        {
            codeOffer = "OFF-2025-005",
            customer = "Digital Partners SA",
            companyName = "MyCompany SRL",
            dateOffer = "2025-02-05",
            alphaCode = "FR",
            codeTemplate = 2,
            emailCustomer = "contact@digitalpartners.fr",
            vatNumber = "FR55512345678"
        }
    };

            var response = new
            {
                listOffers = mockOffers,
                totalCount = mockOffers.Length,
                feedback = new
                {
                    status = "OK",
                    statusCode = 200,
                    evLogApi = new
                    {
                        codeError = "",
                        nameSpaceClassError = "",
                        messageErrore = "",
                        innerMessageErrore = ""
                    }
                }
            };

            _logger.LogInformation("Ritornate {Count} offerte", mockOffers.Length);
            return Ok(response);
        }
        #endregion
    }
}
