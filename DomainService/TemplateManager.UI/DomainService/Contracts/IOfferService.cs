

using TemplateManager.Common.ObjectModel;

namespace TemplateManager.UI.DomainService
{
    /// <summary>
    /// Interface for offer PDF generation and email services.
    /// Provides methods to generate PDFs from offers and send them via email.
    /// </summary>
    public interface IOfferService
    {
        /// <summary>
        /// Generates PDF from offer contract and returns it with HTML.
        /// Calls POST /api/offers/generate endpoint.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>OutputOfferTemplateApi containing PDF bytes and HTML</returns>
        OutputOfferTemplateApi GeneratePdfAsync(OfferContract input, string tokenAccess);

        /// <summary>
        /// Generates PDF and downloads it as binary file.
        /// Calls POST /api/offers/generate/download endpoint.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>PDF file as byte array, or null if error occurred</returns>
        byte[]? DownloadPdfAsync(OfferContract input, string tokenAccess);

        /// <summary>
        /// Generates PDF and converts it to base64 string.
        /// Uses GeneratePdfAsync and converts PdfBytes to base64.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>Base64 encoded PDF string, or null if error occurred</returns>
        string? GeneratePdfBase64Async(OfferContract input, string tokenAccess);

        /// <summary>
        /// Generates PDF and sends it via email.
        /// Calls POST /api/offers/pdf/email endpoint.
        /// </summary>
        /// <param name="input">SendOfferPdfRequest containing offer and email details</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>OutputRequestLicenseManager with operation result</returns>
        OutputRequestLicenseManager SendPdfByEmailAsync(SendOfferPdfRequest input, string tokenAccess);
    }
}