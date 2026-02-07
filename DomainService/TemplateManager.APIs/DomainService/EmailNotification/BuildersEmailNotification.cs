// ============================================
// Builder per costruzione template email con allegati PDF
// Utilizzato da OfferPdfEmailService per inviare offerte via email
// ============================================
using TemplateManager.Common;
using EmailNotification.Common.ObjectModel;
using TMOM = TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.Business.EmailNotification
{
    /// <summary>
    /// Classe concreta per costruzione template email personalizzati.
    /// Estende BaseTemplateEmailAlert aggiungendo supporto per corpo HTML personalizzato.
    /// </summary>
    internal class BuildersEmailNotification : BaseTemplateEmailAlert
    {
        #region FIELDS
        // Nessun field aggiuntivo necessario
        #endregion

        #region CONSTRUCTORS
        // Costruttore di default (implicito)
        #endregion

        #region PROPERTIES
        // Nessuna property aggiuntiva
        #endregion

        #region METHODS

        #region PUBLIC

        /// <summary>
        /// Costruisce template email completo con destinatario, oggetto e corpo HTML.
        /// Metodo principale chiamato da OfferPdfEmailService per preparare invio email.
        /// </summary>
        /// <param name="emailAddress">Indirizzo email destinatario</param>
        /// <param name="emailSubject">Oggetto dell'email (es: "Offerta OF-2025-001")</param>
        /// <param name="htmlMessageBody">Corpo email in formato HTML</param>
        /// <param name="feed">Feedback operazione (out parameter per errori)</param>
        /// <returns>Oggetto SendNewEmailApi pronto per invio con EmailNotification API</returns>
        internal SendNewEmailApi BuildNewTemplate(
            string emailAddress,
            string emailSubject,
            string htmlMessageBody,
            out TMOM.BaseApiFeedback feed)
        {
            feed = new TMOM.BaseApiFeedback();
            SendNewEmailApi sendNewEmailApi = new();

            try
            {
                // 1. Costruisce template base (mittente, destinatario, oggetto)
                //    usando metodo della classe base
                sendNewEmailApi = BuildBaseTemplateEmail(emailAddress, emailSubject, out feed);

                // 2. Aggiunge corpo HTML personalizzato
                //    Questo può includere testo, immagini, link, etc.
                sendNewEmailApi.MessageBody = htmlMessageBody;

                // Nota: gli allegati PDF vengono aggiunti successivamente
                // da OfferPdfEmailService usando sendNewEmailApi.FileAttachment.Add()
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

        #endregion

        #region NOT PUBLIC
        // Nessun metodo privato aggiuntivo
        #endregion

        #endregion
    }
}
