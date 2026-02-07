
using TemplateManager.APIs.Constants;
using TemplateManager.APIs.Constants.Business.Validators;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.Business.Validators.Contracts.Template
{
    /// <summary>
    /// Interfaccia per validator di Template.
    /// Implementa regole di validazione per istanze Template.
    /// </summary>
    internal interface ITemplateApiValidator : IValidationRule<ITemplate, BaseApiFeedback, TemplateApiValidatorArgs>
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

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
