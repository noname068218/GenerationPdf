using System.Net;
using System.Text;
using TemplateManager.UI.ModelView;
using TemplateManager.Common.ObjectModel;
using TemplateManager.Common;
using Microsoft.Extensions.Configuration;
namespace TemplateManager.UI
{
    public static class ExtensionMethodsUI
    {

        #region STATIC
        #region EVENTS
        #region PUBLIC
        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

        #region FIELDS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        //private static JavaScriptSerializer m_JsonSerialize;
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna o imposta la property UserName dell'entità (<see cref=ExtensionMethodsUI/>)
        /// </summary>
        /// <value>
        /// <c>UserName</c> dell'entità FolderLoaded.
        /// </value>
        internal static String UserNameApi { get => "noreply.msgplugin"; }


        /// <summary>
        /// Ritorna o imposta la property Password dell'entità (<see cref=ExtensionMethodsUI/>)
        /// </summary>
        /// <value>
        /// <c>Password</c> dell'entità FolderLoaded.
        /// </value>
        internal static String PasswordApi { get => "Cinisello01$"; }

        /// <summary>
        /// Ritorna o imposta la property Password dell'entità (<see cref=ExtensionMethodsUI/>)
        /// </summary>
        /// <value>
        /// <c>Password</c> dell'entità FolderLoaded.
        /// </value>
        internal static String DomainNameApi { get => "EPY"; }


        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
                return builder.Build();
            }
        }
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC


        public static bool IsRange(this TimeSpan tsNow, TimeSpan startinput, TimeSpan endinput)
        {

            TimeSpan time1 = TimeSpan.FromHours(24);
            TimeSpan start = startinput;
            TimeSpan end = endinput;

            if (start <= end)
            {
                // start and stop times are in the same day
                if (tsNow >= start && tsNow <= end)
                    return true;
            }
            else
            {
                // start and stop times are in different days
                if (tsNow >= start || tsNow <= end)
                    return true;
            }

            return false;

        }



        public static string Reverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="modelName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string LoadUrlRestApi(BaseUrlRestApi baseUrl, ObjectModelName modelName, ActionOperationName action)
        {

            return baseUrl.ToBaseUrlRestApi() + modelName.ToStringObjectModelName() + "/" + action.ToStringActionOperationName();
        }





        #region Colling RestApi

        /// <summary>
        /// GetAPIKeyAuthentication
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetAPIKeyAuthentication(string url, string tokenKey, int timeout = 20)
        {
            // Istruzione per impostare il protocollo di sicurezza
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrWhiteSpace(tokenKey))
                SetAPIKeyAuthHeader(request, tokenKey);

            // Istruzione per ignorare gli errori di validazione del certificato
            request.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            request.Timeout = timeout * 1000;
            request.Method = "GET";
            string esito = string.Empty;

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    esito = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;

                using (Stream responseStream = errorResponse.GetResponseStream())
                using (StreamReader responseReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                    esito = responseReader.ReadToEnd();

                throw;
            }

            return esito;
        }

        /// <summary>
        /// Effettua una chiamata post con BasicAuthentication
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonContent"></param>
        public static string PostAPIKeyAuthentication(string url, string jsonContent, string tokenKey, int timeout = 20)
        {
            // Istruzione per impostare il protocollo di sicurezza
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrWhiteSpace(tokenKey))
                SetAPIKeyAuthHeader(request, tokenKey);

            // Istruzione per ignorare gli errori di validazione del certificato
            request.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };

            request.Timeout = timeout * 1000;
            request.Method = "POST";
            request.ContentType = @"application/json";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream dataStream = request.GetRequestStream())
            {
                using StreamWriter stmw = new(dataStream);
                stmw.Write(jsonContent);
            }

            string output = null;
            try
            {
                using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using StreamReader responseReader = new(response.GetResponseStream());
                output = responseReader.ReadToEnd();
            }
            catch (WebException)
            {
                throw;
            }

            return output;
        }

        /// <summary>
        /// Effettua una chiamata post con BasicAuthentication
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonContent"></param>
        public static string PutAPIKeyAuthentication(string url, string jsonContent, string tokenKey, int timeout = 20)
        {
            // Istruzione per impostare il protocollo di sicurezza
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrWhiteSpace(tokenKey))
                SetAPIKeyAuthHeader(request, tokenKey);

            // Istruzione per ignorare gli errori di validazione del certificato
            request.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };

            request.Timeout = timeout * 1000;
            request.Method = "PUT";
            request.ContentType = @"application/json";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream dataStream = request.GetRequestStream())
            {
                using StreamWriter stmw = new(dataStream);
                stmw.Write(jsonContent);
            }

            string output = null;
            try
            {
                using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using StreamReader responseReader = new(response.GetResponseStream());
                output = responseReader.ReadToEnd();
            }
            catch (WebException)
            {
                throw;
            }

            return output;
        }

        /// <summary>
        /// GetAPIKeyAuthentication
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DeleteAPIKeyAuthentication(string url, string tokenKey, int timeout = 20)
        {
            // Istruzione per impostare il protocollo di sicurezza
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrWhiteSpace(tokenKey))
                SetAPIKeyAuthHeader(request, tokenKey);

            // Istruzione per ignorare gli errori di validazione del certificato
            request.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            request.Timeout = timeout * 1000;
            request.Method = "DELETE";
            string esito = string.Empty;

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    esito = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;

                using (Stream responseStream = errorResponse.GetResponseStream())
                using (StreamReader responseReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                    esito = responseReader.ReadToEnd();

                throw;
            }

            return esito;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseApiFeedback"></param>
        /// <returns></returns>
        public static Feedback ToFeedback(this BaseApiFeedback input)
        {

            if (input == null)
                return new Feedback() { Stato = FeedbackStatus.Error };

            Feedback feed = new();
            feed.Stato = input.StatusCode switch
            {
                StatusCodesApi.Success => FeedbackStatus.Success,
                StatusCodesApi.Warning => FeedbackStatus.Warning,
                StatusCodesApi.Error => FeedbackStatus.Error,
                StatusCodesApi.CannotNotBeExecute => FeedbackStatus.Error,
                StatusCodesApi.NotFound => FeedbackStatus.NotFound,
                _ => FeedbackStatus.Null,
            };
            if (input.EVLogApi != null)
            {
                feed.MessaggioList.Add(input.EVLogApi.MessageErrore);

                if (string.IsNullOrWhiteSpace(input.EVLogApi.InnerMessageErrore))
                    feed.MessaggioList.Add(input.EVLogApi.InnerMessageErrore);

            }

            return feed;
        }

        #endregion

        #region APIKeyAuthHeader

        /// <summary>
        /// Set Basic AuthHeader
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        internal static void SetAPIKeyAuthHeader(WebRequest request, string tokenKey)
        {
            request.Headers["Authorization"] = tokenKey;
        }

        #endregion


        /// <summary>
        /// Controlla se la stringa è null, vuota o composta di spazi bianchi
        /// </summary>
        /// <param name="value">parametro da controllare </param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            try
            {
                if (String.IsNullOrEmpty(value))
                    return true;
                if (String.IsNullOrWhiteSpace(value))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }


        #region NOT PUBLIC

        static String? ToStringObjectModelName(this ObjectModelName modelName)
        {
            return modelName switch
            {
                ObjectModelName.LicenseManager => ObjectModelOperation.LicenseManager,
                ObjectModelName.UserManager => ObjectModelOperation.UserManager,
                ObjectModelName.Template => ObjectModelOperation.Template,
                ObjectModelName.TemplateParagraph => ObjectModelOperation.TemplateParagraph,
                ObjectModelName.ManageGeneratePdf => ObjectModelOperation.ManageGeneratePdf,
                _ => null,
            };
        }

        internal static String? ToStringActionOperationName(this ActionOperationName action)
        {
            return action switch
            {
                ActionOperationName.SendMasterLicenseAsync => OperationName.SendMasterLicenseAsync,
                ActionOperationName.ResendMasterLicenseAsync => OperationName.ResendMasterLicenseAsync,
                ActionOperationName.ActivateNewBrandNameAsync => OperationName.ActivateNewBrandNameAsync,
                ActionOperationName.ChangeCompanyNameAsync => OperationName.ChangeCompanyNameAsync,
                ActionOperationName.SendTemporalyLicenseAsync => OperationName.SendTemporalyLicenseAsync,
                ActionOperationName.ResendTemporalyLicenseAsync => OperationName.ResendTemporalyLicenseAsync,
                ActionOperationName.PasswordTemporaryAsync => OperationName.PasswordTemporaryAsync,
                ActionOperationName.CodeVerifyEmailAsync => OperationName.CodeVerifyEmailAsync,
                ActionOperationName.SendPdfByEmailAsync => OperationName.SendPdfByEmailAsync,
                ActionOperationName.GenerateFileOfferAsync => OperationName.GenerateFileOfferAsync,
                ActionOperationName.DownloadFileOfferAsync => OperationName.DownloadFileOfferAsync,

                _ => null,
            };
        }

        internal static String ToBaseUrlRestApi(this BaseUrlRestApi restApi)
        {
            switch (restApi)
            {
                case BaseUrlRestApi.Anagraphic:
                    return GetCurrentBaseUrlRestApiService;
                default:
                    return null;
            }
        }

        internal static string GetCurrentBaseUrlRestApiService
        {
            get
            {
                var itemselement = Configuration.GetSection("BaseURLMicroServices:TemplateManager");
                string _currentBaseUrlRestApiService = itemselement.Exists() ? itemselement.Value : null;

                if (String.IsNullOrWhiteSpace(_currentBaseUrlRestApiService))
                    throw new ArgumentNullException("Manca la configurazione della section BaseURLMicroServices nel appsettings.json");

                return _currentBaseUrlRestApiService;
            }
        }


        /// <summary>
        /// Builds URL for Offers API endpoints.
        /// These endpoints use fixed route /api/offers/... instead of standard pattern.
        /// </summary>
        /// <param name="endpoint">Endpoint name (e.g., "generate", "generate/download", "pdf/email")</param>
        /// <returns>Full URL for the offers API endpoint</returns>
        public static string LoadUrlOffersApi(string endpoint)
        {
            // Get base URL from configuration
            string baseUrl = GetCurrentBaseUrlRestApiService;

            // Remove trailing slash if present
            if (baseUrl.EndsWith("/"))
                baseUrl = baseUrl.TrimEnd('/');

            // Build full URL: baseUrl + /api/offers/ + endpoint
            return $"{baseUrl}/api/offers/{endpoint}";
        }


        /// <summary>
        /// Downloads binary data (PDF file) from API endpoint using POST request.
        /// This method is used for downloading PDF files directly as byte array.
        /// </summary>
        /// <param name="url">Full URL of the API endpoint</param>
        /// <param name="jsonContent">JSON content to send in POST body</param>
        /// <param name="tokenKey">Authentication token</param>
        /// <param name="timeout">Request timeout in seconds (default: 60 for large files)</param>
        /// <returns>Byte array containing downloaded file, or null if error occurred</returns>
        public static byte[]? PostAPIKeyAuthenticationBinary(string url, string jsonContent, string tokenKey, int timeout = 60)
        {
            // Set security protocol
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrWhiteSpace(tokenKey))
                SetAPIKeyAuthHeader(request, tokenKey);

            // Ignore certificate validation errors
            request.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };

            request.Timeout = timeout * 1000;
            request.Method = "POST";
            request.ContentType = @"application/json";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            // Write JSON content to request stream
            using (Stream dataStream = request.GetRequestStream())
            {
                using StreamWriter stmw = new(dataStream);
                stmw.Write(jsonContent);
            }

            try
            {
                // Get response and read binary data
                using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using Stream responseStream = response.GetResponseStream();

                // Read all bytes from response stream
                using MemoryStream memoryStream = new();
                responseStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
            catch (WebException)
            {
                // Return null on error (caller should handle exceptions)
                return null;
            }
        }



        #endregion
        #endregion

        #endregion
        #endregion
    }
}
