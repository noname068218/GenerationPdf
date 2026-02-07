using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.UI.DomainService
{
    internal class ManageGeneratePdfService : IManageGeneratePdfService
    {
        #region PUBLIC METHODS


        /// <summary>
        /// Generates PDF and downloads it as binary file.
        /// This method calls /api/offers/generate/download endpoint which returns PDF file directly.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>PDF file as byte array, or null if error occurred</returns>
        public OutputDownloadFileOfferApi DownloadFileOfferAsync(OfferContract input, string tokenAccess)
        {
            OutputDownloadFileOfferApi output = new();

            try
            {
                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

                string wsUrl = ExtensionMethodsUI.LoadUrlRestApi(BaseUrlRestApi.Anagraphic, ObjectModelName.ManageGeneratePdf, ActionOperationName.DownloadFileOfferAsync);

                string inputJson = JsonConvert.SerializeObject(input, settings);

                output.PdfBytes = ExtensionMethodsUI.PostAPIKeyAuthenticationBinary(wsUrl, inputJson, tokenAccess);

            }
            catch (Exception ex)
            {

                output.Feedback.StatusCode = StatusCodesApi.Error;

                if (output.Feedback.EVLogApi == null)
                    output.Feedback.EVLogApi = new EVLogApi();

                output.Feedback.EVLogApi.MessageErrore = ex.Message;

                if (ex.InnerException != null)
                    output.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }

            return output;
        }

        /// <summary>
        /// Generates PDF and converts it to base64 string.
        /// This method first generates PDF using GeneratePdfAsync, then converts PdfBytes to base64.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>Base64 encoded PDF string, or null if error occurred</returns>
        public OutputDownloadBase64OfferApi DownloadPdfBase64Async(OfferContract input, string tokenAccess)
        {
            OutputDownloadBase64OfferApi output = new();

            try
            {
                var result = GenerateFileOfferAsync(input, tokenAccess);

                if (result.Feedback.StatusCode == StatusCodesApi.Success && result.PdfBytes != null && result.PdfBytes.Length > 0)
                    output.PdfBase64 = Convert.ToBase64String(result.PdfBytes);
                else
                    output.Feedback = result.Feedback;
            }
            catch (Exception ex)
            {
                output.Feedback.StatusCode = StatusCodesApi.Error;

                if (output.Feedback.EVLogApi == null)
                    output.Feedback.EVLogApi = new EVLogApi();

                output.Feedback.EVLogApi.MessageErrore = ex.Message;

                if (ex.InnerException != null)
                    output.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }
            return output;
        }

        /// <summary>
        /// Generates PDF and sends it via email.
        /// This method calls /api/offers/pdf/email endpoint with offer and email details.
        /// </summary>
        /// <param name="input">SendOfferPdfRequest containing offer contract and email details (emailAddress, subject, bodyHtml, cc, bcc)</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>OutputRequestLicenseManager with operation result</returns>
        public OutputRequestLicenseManager SendPdfByEmailAsync(SendOfferPdfRequest input, string tokenAccess)
        {
            OutputRequestLicenseManager output = new();

            try
            {
                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

                string wsUrl = ExtensionMethodsUI.LoadUrlOffersApi("SendPdfByEmailAsync");

                string inputJson = JsonConvert.SerializeObject(input, settings);

                var response = ExtensionMethodsUI.PostAPIKeyAuthentication(wsUrl, inputJson, tokenAccess);

                if (!string.IsNullOrWhiteSpace(response))
                {
                    output = JsonConvert.DeserializeObject<OutputRequestLicenseManager>(response, settings);
                }
                else
                {
                    output.Feedback.StatusCode = StatusCodesApi.Error;
                }
            }
            catch (Exception ex)
            {
                output.Feedback.StatusCode = StatusCodesApi.Error;

                if (output.Feedback.EVLogApi == null)
                    output.Feedback.EVLogApi = new EVLogApi();

                output.Feedback.EVLogApi.MessageErrore = ex.Message;

                if (ex.InnerException != null)
                    output.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }

            return output;
        }


        OutputOfferTemplateApi GenerateFileOfferAsync(OfferContract input, string tokenAccess)
        {
            OutputOfferTemplateApi output = new();

            try
            {

                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

                string wsUrl = ExtensionMethodsUI.LoadUrlRestApi(BaseUrlRestApi.Anagraphic, ObjectModelName.ManageGeneratePdf, ActionOperationName.GenerateFileOfferAsync);
                string inputJson = JsonConvert.SerializeObject(input, settings);
                var response = ExtensionMethodsUI.PostAPIKeyAuthentication(wsUrl, inputJson, tokenAccess);

                if (!string.IsNullOrWhiteSpace(response))
                    output = JsonConvert.DeserializeObject<OutputOfferTemplateApi>(response, settings);
                else
                    output.Feedback.StatusCode = StatusCodesApi.Error;
            }
            catch (Exception ex)
            {

                output.Feedback.StatusCode = StatusCodesApi.Error;

                if (output.Feedback.EVLogApi == null)
                    output.Feedback.EVLogApi = new EVLogApi();

                output.Feedback.EVLogApi.MessageErrore = ex.Message;

                if (ex.InnerException != null)
                    output.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }

            return output;
        }

        #endregion
    }
}