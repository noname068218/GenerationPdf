
using TemplateManager.APIs.Business.Validators.Concrete.Template;
using TemplateManager.APIs.Business.Validators.Contracts.Template;

namespace TemplateManager.APIs.Business.Validators.Factory
{
    /// <summary>
    /// Factory per istanziare i validatori.
    /// </summary>
    internal class ValidatorsFactory : IValidatorsFactory
    {


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

        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
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

        /// <summary>
        /// Ritorna validator per Template.
        /// Factory method per creare validator di Template.
        /// </summary>
        public ITemplateApiValidator GetTemplateApiValidator() => 
            ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<TemplateApiValidator>();

        /// <summary>
        /// Ritorna validator per TemplateParagraph.
        /// Factory method per creare validator di TemplateParagraph.
        /// </summary>
        public ITemplateParagraphApiValidator GetTemplateParagraphApiValidator() => 
            ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<TemplateParagraphApiValidator>();

        #endregion


    }
}
