using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.Constants
{
    public class TemplateParagraphApiBuilderArgs
    {

        #region DYNAMIC

        #region METHODS
        #region PUBLIC
        internal TemplateParagraphApiBuilderArgs(TemplateParagraphApi _itemsInput)
        {
            TemplateParagraph = _itemsInput;
        }
        #endregion
        public TemplateParagraphApi TemplateParagraph { get; private set; }

        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion

    }
}
