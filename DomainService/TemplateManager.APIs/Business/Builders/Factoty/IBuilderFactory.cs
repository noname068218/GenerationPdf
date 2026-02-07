

using TemplateManager.APIs.Business.Builders.Contracts.TemplateParagraph;

namespace TemplateManager.APIs.Business.Builders.Factoty
{
    /// <summary>
    /// Interfaccia del factory per la creazione di builder per Template e TemplateParagraph.
    /// Un builder si occupa di eseguire operazioni (save, delete) su un'istanza dell'entità.
    /// </summary>
    internal interface IBuilderFactory
    {
        #region METHODS

        /// <summary>
        /// Ritorna un'istanza del ApiBuilder per Template.
        /// Factory method per creare builder di Template.
        /// </summary>
        /// <returns>Istanza di ITemplateApiBuilder</returns>
        ITemplateApiBuilder GetTemplateApiBuilder();

        /// <summary>
        /// Ritorna un'istanza del ApiBuilder per TemplateParagraph.
        /// Factory method per creare builder di TemplateParagraph.
        /// </summary>
        /// <returns>Istanza di ITemplateParagraphApiBuilder</returns>
        ITemplateParagraphApiBuilder GetTemplateParagraphApiBuilder();

        #endregion
    }
}
