
using TemplateManager.Business;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.Constants
{
    internal class TemplateApiValidatorArgs : IValidationRuleArgs
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
    internal TemplateApiValidatorArgs(TemplateApi _itemsInput)
    {
        Template = _itemsInput;
    }
    #endregion
    #region NOT PUBLIC

    #endregion
    #endregion

    #region PROPERTIES
    #region PUBLIC
        public TemplateApi Template { get; private set; }

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
