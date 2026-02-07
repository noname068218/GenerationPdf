using Newtonsoft.Json;
using System;
using TemplateManager.Common;
using TemplateManager.Common.ObjectModel;
using TemplateManager.UI;

namespace TemplateManager.UI.DomainService
{
    /// <summary>
    /// Implementation of offer service for PDF generation and email operations.
    /// This service provides methods to generate PDFs from offers and send them via email.
    /// All methods call REST API endpoints from OffersController.
    /// </summary>
    internal class OfferService : IOfferService
    {
        #region PUBLIC METHODS

        /// <summary>
        /// Generates PDF from offer contract and returns it with HTML.
        /// This method serializes the input, sends POST request to /api/offers/generate,
        /// and deserializes the response containing PDF bytes and HTML.
        /// </summary>
        /// <param name="input">Offer contract with all offer data (CodeOffer, CompanyName, Customer, etc.)</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>OutputOfferTemplateApi containing PDF bytes, HTML, and feedback</returns>
        public OutputOfferTemplateApi GeneratePdfAsync(OfferContract input, string tokenAccess)
        {
            OutputOfferTemplateApi output = new();

            try
            {
        
                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

          
                string wsUrl = ExtensionMethodsUI.LoadUrlOffersApi("generate");

             
                string inputJson = JsonConvert.SerializeObject(input, settings);

                var response = ExtensionMethodsUI.PostAPIKeyAuthentication(wsUrl, inputJson, tokenAccess);

            
                if (!string.IsNullOrWhiteSpace(response))
                {

                    output = JsonConvert.DeserializeObject<OutputOfferTemplateApi>(response, settings);
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

        /// <summary>
        /// Generates PDF and downloads it as binary file.
        /// This method calls /api/offers/generate/download endpoint which returns PDF file directly.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>PDF file as byte array, or null if error occurred</returns>
        public byte[]? DownloadPdfAsync(OfferContract input, string tokenAccess)
        {
            try
            {
            
                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

              
                string wsUrl = ExtensionMethodsUI.LoadUrlOffersApi("generate/download");

            
                string inputJson = JsonConvert.SerializeObject(input, settings);

                byte[]? pdfBytes = ExtensionMethodsUI.PostAPIKeyAuthenticationBinary(wsUrl, inputJson, tokenAccess);

                return pdfBytes;
            }
            catch (Exception)
            {
               
                return null;
            }
        }

        /// <summary>
        /// Generates PDF and converts it to base64 string.
        /// This method first generates PDF using GeneratePdfAsync, then converts PdfBytes to base64.
        /// </summary>
        /// <param name="input">Offer contract with all offer data</param>
        /// <param name="tokenAccess">Authentication token for API access</param>
        /// <returns>Base64 encoded PDF string, or null if error occurred</returns>
        public string? GeneratePdfBase64Async(OfferContract input, string tokenAccess)
        {
            try
            {
            
                var result = GeneratePdfAsync(input, tokenAccess);

               
                if (result.Feedback.StatusCode == StatusCodesApi.Success &&
                    result.PdfBytes != null &&
                    result.PdfBytes.Length > 0)
                {
                
                    return Convert.ToBase64String(result.PdfBytes);
                }

               
                return null;
            }
            catch (Exception)
            {
         
                return null;
            }
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


                string wsUrl = ExtensionMethodsUI.LoadUrlOffersApi("pdf/email");

   
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

        #endregion
    }
}