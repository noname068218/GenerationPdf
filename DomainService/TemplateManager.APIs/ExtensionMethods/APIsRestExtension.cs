using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;


namespace TemplateManager.APIs
{
    public static class APIsRestExtension
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


        #region BasicAuthHeader

        /// <summary>
        /// Set Basic AuthHeader
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        internal static void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
        }

        #endregion

        #endregion

        #region NOT PUBLIC


        #endregion
        #endregion

        #endregion

    }
}
