using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.DomainService.Concrete.QuestPdf
{

    /// <summary>
    /// Renderer moderno per generazione PDF usando QuestPDF.
    /// </summary>
    public class QuestPdfRenderer : IQuestPdfRenderer
    {
        #region FIELDS
        private readonly ILogger<IQuestPdfRenderer> _logger;

        #endregion

        #region CONSTRUCTORS

        public QuestPdfRenderer(ILogger<IQuestPdfRenderer> logger)
        {
            _logger = logger;
        }

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        public Byte[] GeneratePdf(OfferContract offer)
        {
            try
            {
                //Crea documento usando QuestPDF
                var document = new OfferPdfDocument(offer);

                //Genera e restituisci PDF come array di byte
                return document.GeneratePdf();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Errore nella generazione PDF per offerta {CodeOffer}", offer.CodeOffer);
                throw;
            }
        }

        #region PUBLIC

        #region METODI Members

        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion
    }
}
