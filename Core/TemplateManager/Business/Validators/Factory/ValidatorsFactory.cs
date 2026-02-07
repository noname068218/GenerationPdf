


using TemplateManager.Application;

namespace TemplateManager.Business
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
        #region PUBLIC

        #region Template

        /// <summary>
        /// Ritorna un'istanza del Validators per <see cref= TemplateManager.DomainObject.ITemplate/>.
        /// </summary>
        /// <returns>L'istanza del Validators per (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        public ITemplateValidator GetTemplateValidator() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<TemplateValidator>();

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Ritorna un'istanza del Validators per <see cref= TemplateManager.DomainObject.ITemplateParagraph/>.
        /// </summary>
        /// <returns>L'istanza del Validators per (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        public ITemplateParagraphValidator GetTemplateParagraphValidator() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<TemplateParagraphValidator>();

        #endregion



        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion


    }
}
