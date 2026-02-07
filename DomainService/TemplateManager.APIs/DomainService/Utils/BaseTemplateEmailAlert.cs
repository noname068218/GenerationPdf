// ============================================
// Base class per costruire template email
// Utilizzato da BuildersEmailNotification per creare oggetti SendNewEmailApi
// ============================================
using System.Net.Mail;
using TemplateManager.Common;
using EmailNotification.Common.ObjectModel;
using TMOM = TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.Business
{
    /// <summary>
    /// Classe base astratta per costruzione template email.
    /// Contiene logica comune per creare richieste email con EmailNotification API.
    /// </summary>
    internal abstract class BaseTemplateEmailAlert
    {
        #region PROPERTIES

        #region PUBLIC

        /// <summary>
        /// Indirizzo email mittente di default per notifiche automatiche.
        /// </summary>
        internal static string EmailFrom { get => "noreply.msgplugin@epy.it"; }

        /// <summary>
        /// Codice provider TurboSMTP per invio email.
        /// </summary>
        internal static int CodeProviderTurboSMTP { get => 1; }

        /// <summary>
        /// Codice provider Mailjet per invio email (raccomandato).
        /// </summary>
        internal static int CodeProviderMailjet { get => 3; }

        #endregion
        #region NOT PUBLIC

        /// <summary>
        /// Costruisce oggetto base per invio email tramite EmailNotification API.
        /// Configura mittente, destinatario, oggetto e provider email.
        /// </summary>
        /// <param name="emailAddress">Indirizzo email destinatario</param>
        /// <param name="emailSubject">Oggetto dell'email</param>
        /// <param name="feed">Feedback operazione (out parameter)</param>
        /// <returns>Oggetto SendNewEmailApi configurato e pronto per l'invio</returns>
        protected SendNewEmailApi BuildBaseTemplateEmail(
            string emailAddress,
            string emailSubject,
            out TMOM.BaseApiFeedback feed)
        {
            feed = new TMOM.BaseApiFeedback();
            SendNewEmailApi sendNewEmailApi = new();

            try
            {
                // Configurazione email base
                sendNewEmailApi.IsToBeMonitored = true;                     // Abilita monitoraggio invio
                sendNewEmailApi.CodeProviderMail = CodeProviderMailjet;     // Usa Mailjet come provider
                sendNewEmailApi.ExternalRequestIdentity = GeneraiteUniCode(); // ID univoco richiesta
                sendNewEmailApi.EmailAddressFrom = EmailFrom;               // Mittente di default
                sendNewEmailApi.SendForEachContact = true;                  // Invia separatamente per ogni destinatario
                sendNewEmailApi.EmailSubject = emailSubject;                // Oggetto email
                sendNewEmailApi.DateRequestSend = DateTime.Now;             // Data richiesta invio

                // Estrae nome da indirizzo email (prima della @)
                string? denomination = emailAddress.BuildNameFromEmailAddress();

                // Aggiunge destinatario se email valida
                if (!emailAddress.IsNullOrEmptyOrWhiteSpace())
                {
                    sendNewEmailApi.EmailRecipients.Add(new EmailRecipientApi()
                    {
                        Name = denomination,
                        EmailAddress = emailAddress,
                        AddressInTo = true,  // Aggiunge nel campo "To" (non CC o BCC)
                    });
                }
            }
            catch (Exception ex)
            {
                // Gestione errori con feedback dettagliato
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null)
                    feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;
            }

            return sendNewEmailApi;
        }

        /// <summary>
        /// Genera codice univoco basato su timestamp UTC.
        /// Utilizzato come ExternalRequestIdentity per tracciare richieste email.
        /// </summary>
        /// <returns>Numero long univoco positivo</returns>
        long GeneraiteUniCode()
        {
            try
            {
                // Genera hash dal timestamp corrente
                long date = DateTime.UtcNow.GetHashCode();

                // Assicura che sia sempre positivo
                if (date < 0)
                    return date * -1;
                else
                    return date;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        #endregion
    }
}
