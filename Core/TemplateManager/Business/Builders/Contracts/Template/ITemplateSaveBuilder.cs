using TemplateManager.DomainObject;

namespace TemplateManager.Business
{
    /// <summary>
    /// Builder per la Template.
    /// </summary>
    internal interface ITemplateSaveBuilder
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
        /// <exception cref="System.ArgumentNullException">Template</exception>
        void Build(ITemplate input, TemplateSaveBuilderArgs args = null);

        #endregion

    }
}
