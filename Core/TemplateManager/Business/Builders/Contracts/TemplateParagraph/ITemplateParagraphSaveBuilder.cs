using TemplateManager.DomainObject;

namespace TemplateManager.Business
{
    /// <summary>
    /// Builder per la TemplateParagraph.
    /// </summary>
    internal interface ITemplateParagraphSaveBuilder
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS

        /// <summary>
        /// Data un'istanza di Transazione esegue le operazioni necessarie al suo corretto salvataggio.
        /// </summary>
        /// <param name="input">Transazione.</param>
        /// <param name="args">Argomenti per la gestione del builder.</param>
        /// <exception cref="System.ArgumentNullException">TemplateParagraph</exception>
        void Build(ITemplateParagraph input, TemplateParagraphSaveBuilderArgs args = null);

        #endregion

    }
}
