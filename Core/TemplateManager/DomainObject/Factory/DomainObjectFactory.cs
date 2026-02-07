using System;
using System.Runtime.CompilerServices;
using TemplateManager.DAL.DomainModel;

namespace TemplateManager.DomainObject
{
    internal class DomainObjectFactory : IDomainObjectFactory
    {

        #region STATIC

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

        #region PROPERTIES
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        public static ConditionalWeakTable<IObjectModel, object> DomainObjectTable = new();
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
        static DomainObjectFactory()
        {
            DomainObjectTable = new ConditionalWeakTable<IObjectModel, object>();
        }


        #region Template

        /// <summary>
        /// Crea un'istanza di <c>ITemplate</c> (<see cref= TemplateManager.DomainObject.ITemplate/>)
        /// </summary>
        /// <returns>L'istanza di <c>ITemplate</c> (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        public ITemplate CreateNewTemplate()
         {
           return new Template();
         }

        /// <summary>
        /// Crea un'istanza di <c>ITemplate</c> (<see cref= TemplateManager.DomainObject.ITemplate/>)
        /// </summary>
        /// <returns>L'istanza di <c>ITemplate</c> (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        public ITemplate CreateNewTemplate(ITemplateObjectModel item)
         {
           object domainObject;

           if (DomainObjectTable.TryGetValue(item, out domainObject))
              return domainObject as ITemplate;

           ITemplate itemDomainObject = new Template(item);

           DomainObjectTable.Add(item, itemDomainObject);

           return itemDomainObject;

         }

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Crea un'istanza di <c>ITemplateParagraph</c> (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>)
        /// </summary>
        /// <returns>L'istanza di <c>ITemplateParagraph</c> (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        public ITemplateParagraph CreateNewTemplateParagraph()
         {
           return new TemplateParagraph();
         }

        /// <summary>
        /// Crea un'istanza di <c>ITemplateParagraph</c> (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>)
        /// </summary>
        /// <returns>L'istanza di <c>ITemplateParagraph</c> (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        public ITemplateParagraph CreateNewTemplateParagraph(ITemplateParagraphObjectModel item)
         {
           object domainObject;

           if (DomainObjectTable.TryGetValue(item, out domainObject))
              return domainObject as ITemplateParagraph;

           ITemplateParagraph itemDomainObject = new TemplateParagraph(item);

           DomainObjectTable.Add(item, itemDomainObject);

           return itemDomainObject;

         }

        #endregion



        #endregion

        #region NOT PUBLIC
        #endregion

        #endregion

        #endregion


    }
}
