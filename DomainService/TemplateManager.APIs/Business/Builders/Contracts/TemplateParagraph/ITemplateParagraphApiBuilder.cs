
using TemplateManager.APIs.Business.Builders.Concrete.TemplateParagraph;
using TemplateManager.APIs.Constants;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.Business.Builders.Contracts.TemplateParagraph
{
    /// <summary>
    /// Interfaccia per il builder di TemplateParagraph.
    /// Builder pattern per costruire e salvare istanze di TemplateParagraph.
    /// </summary>
    internal interface ITemplateParagraphApiBuilder
    {
        #region DYNAMIC

        #region METHODS
        #region PUBLIC
        /// <summary>
        /// Data un'istanza di Confirm esegue le operazioni necessarie al suo corretto salvataggio
        /// </summary>
        /// <param name="input"></param>
        /// <param name="args"></param>
        /// <returns> <see cref="BaseApiFeedback"/></returns>
        BaseApiFeedback Build(ref ITemplateParagraph output, TemplateParagraphApiBuilderArgs args);
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
