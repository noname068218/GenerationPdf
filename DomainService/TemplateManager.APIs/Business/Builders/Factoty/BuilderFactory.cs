

using TemplateManager.APIs.Business.Builders.Concrete.Template;
using TemplateManager.APIs.Business.Builders.Concrete.TemplateParagraph;
using TemplateManager.APIs.Business.Builders.Contracts.TemplateParagraph;

namespace TemplateManager.APIs.Business.Builders.Factoty
{
    /// <summary>
    /// Classe che si occupa di gestire un'operazione su un'istanza dell'entità.
    /// </summary>
    internal class BuilderFactory : IBuilderFactory
    {

        #region DYNAMIC

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
        #region PUBLIC

        #region Template

        /// <summary>
        /// Ritorna un'istanza del ApiBuilder per Template.
        /// Factory method per creare builder di Template.
        /// </summary>
        /// <returns>Istanza di ITemplateApiBuilder</returns>
        public ITemplateApiBuilder GetTemplateApiBuilder() => 
            ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<TemplateApiBuilder>();

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Ritorna un'istanza del ApiBuilder per TemplateParagraph.
        /// Factory method per creare builder di TemplateParagraph.
        /// </summary>
        /// <returns>Istanza di ITemplateParagraphApiBuilder</returns>
        public ITemplateParagraphApiBuilder GetTemplateParagraphApiBuilder() => 
            ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<TemplateParagraphApiBuilder>();

        #endregion

        #endregion

        #region NOT PUBLIC
        #endregion

        #endregion

        #endregion
    }
}
