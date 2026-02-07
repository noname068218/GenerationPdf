
using TemplateManager.APIs.Business.Validators.Contracts.Template;

namespace TemplateManager.APIs.Business.Validators.Factory
{
    /// <summary>
    /// Interfaccia factory per validators di Template e TemplateParagraph.
    /// Factory pattern per creare istanze di validators per validazione entità.
    /// </summary>
    internal interface IValidatorsFactory
    {
        #region METHODS

        /// <summary>
        /// Ritorna validator per Template.
        /// </summary>
        ITemplateApiValidator GetTemplateApiValidator();

        /// <summary>
        /// Ritorna validator per TemplateParagraph.
        /// </summary>
        ITemplateParagraphApiValidator GetTemplateParagraphApiValidator();

        #endregion
    }
}
