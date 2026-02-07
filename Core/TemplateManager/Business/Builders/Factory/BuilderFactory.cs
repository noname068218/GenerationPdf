using TemplateManager.Application;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Business
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
        /// Ritorna un'istanza del Builder per <see cref= TemplateManager.DomainObject.ITemplate/>.
        /// </summary>
        /// <returns>L'istanza del Builder per (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        public ITemplateSaveBuilder GetTemplateSaveBuilder() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<TemplateSaveBuilder>();

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Ritorna un'istanza del Builder per <see cref= TemplateManager.DomainObject.ITemplateParagraph/>.
        /// </summary>
        /// <returns>L'istanza del Builder per (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        public ITemplateParagraphSaveBuilder GetTemplateParagraphSaveBuilder() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<TemplateParagraphSaveBuilder>();

        #endregion



        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
