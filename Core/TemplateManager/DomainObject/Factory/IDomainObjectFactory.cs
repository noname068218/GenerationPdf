using TemplateManager.DAL.DomainModel;
using System;

namespace TemplateManager.DomainObject
{
    interface IDomainObjectFactory
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS

        #region Template 

        /// <summary>
        /// Crea un'istanza di tipo <see cref= TemplateManager.DomainObject.ITemplate/>.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        ITemplate CreateNewTemplate();

        /// <summary>
        /// Crea un'istanza di tipo <see cref= TemplateManager.DomainObject.ITemplate/>.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        ITemplate CreateNewTemplate(ITemplateObjectModel cliente);

        #endregion

        #region TemplateParagraph 

        /// <summary>
        /// Crea un'istanza di tipo <see cref= TemplateManager.DomainObject.ITemplateParagraph/>.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        ITemplateParagraph CreateNewTemplateParagraph();

        /// <summary>
        /// Crea un'istanza di tipo <see cref= TemplateManager.DomainObject.ITemplateParagraph/>.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        ITemplateParagraph CreateNewTemplateParagraph(ITemplateParagraphObjectModel cliente);

        #endregion



        #endregion
    }
}
