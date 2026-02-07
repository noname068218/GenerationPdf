
using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.UI.DomainService
{
    /// <summary>
    ///Interfaccia dei sevizi APIs per l'entità <see cref="IManageGeneratePdfService"/>. 
    /// </summary>
    /// <typeparam <see cref="IManageGeneratePdfService"/></typeparam>
    public interface IManageGeneratePdfService
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        #region PUBLIC

        #region METODI Members

        /// <summary>
        /// Generates PDF and downloads it as binary file.
        /// Calls POST /api/offers/generate/download endpoint.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>PDF file as byte array, or null if error occurred</returns>
        OutputDownloadFileOfferApi DownloadFileOfferAsync(OfferContract input, string tokenAccess);

        /// <summary>OutputDownloadBase64OfferApi
        /// Generates PDF and converts it to base64 string.
        /// Uses GeneratePdfAsync and converts PdfBytes to base64.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>Base64 encoded PDF string, or null if error occurred</returns>
        OutputDownloadBase64OfferApi DownloadPdfBase64Async(OfferContract input, string tokenAccess);

        /// <summary>
        /// Generates PDF and sends it via email.
        /// Calls POST /api/offers/pdf/email endpoint.
        /// </summary>
        /// <param name="input">SendOfferPdfRequest containing offer and email details</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>OutputRequestLicenseManager with operation result</returns>
        OutputRequestLicenseManager SendPdfByEmailAsync(SendOfferPdfRequest input, string tokenAccess);
        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion
    }
}
