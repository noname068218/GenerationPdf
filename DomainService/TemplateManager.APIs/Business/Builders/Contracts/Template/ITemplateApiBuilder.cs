
using TemplateManager.APIs.Business.Builders.Concrete.Template;
using TemplateManager.APIs.Constants;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.Business
{
    internal interface ITemplateApiBuilder
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
        BaseApiFeedback Build(ref ITemplate output, TemplateApiBuilderArgs args);
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
