using TemplateManager.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;
using TemplateManager.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateManager.DomainService
{
    internal static class ExtensionMethods
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
        /// Aggiunge le view (<see cref='TemplateManager.DAL.TemplateView'/>) agli argomenti per la ricerca per l'entità <see cref='ITemplateManager.DomainObject.ITemplate'/>.
        /// </summary>
        /// <param name='criteria'>Argomenti per la selezione di <see cref='TemplateManager.DomainObject.ITemplate'/></param>
        /// <returns>Argomenti per la ricerca di <see cref='TemplateManager.DomainObject.ITemplate'/> con viste.</returns>
        internal static TemplateSearchCriteria AddViews(this TemplateSearchCriteria criteria)
         {
           if (criteria == null)
            criteria = new TemplateSearchCriteria();

             return criteria;
         }

        /// <summary>
        /// Aggiunge le view (<see cref='TemplateManager.TemplateView'/>) agli argomenti per la ricerca per l'entità <see cref='TemplateManager.DomainObject.ITemplate'/>.
        /// </summary>
        /// <param name='args'>Argomenti per la selezione di <see cref='TemplateManager.DomainObject.ITemplate'/></param>
        /// <returns>Argomenti per la ricerca di <see cref='TemplateManager.DomainObject.ITemplate'/> con viste.</returns>
        internal static TemplateSelectArgs AddViews(this TemplateSelectArgs args)
         {
           if (args == null);
             args = new TemplateSelectArgs();

             return args;
         }

        /// <summary>
        /// Converte <paramref name='item' /> di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateObjectModel' />
        /// in un oggetto di tipo <see cref='TemplateManager.DomainObject.ITemplate' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateObjectModel' /></param>
        /// <returns> oggetto di tipo <see cref='TemplateManager.DomainObject.ITemplate' /> con viste.</returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplate ToDomainObject(this ITemplateObjectModel item)
         {
           if (item == null)
             throw new ArgumentNullException("TemplateManager.DAL.DomainModel.ITemplateObjectModel");

             return DomainServiceLocator.GetDomainObjectFactory().CreateNewTemplate(item);
         }

        /// <summary>
        ///Converte <paramref name='item' /> di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateObjectModel' />
        /// in un oggetto di tipo <see cref='TemplateManager.DomainObject.ITemplate' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateObjectModel' /></param>
        /// <returns> oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplate'/> con viste. con viste o un valore ti tipo null </returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplate ToDomainObjectOrNull(this ITemplateObjectModel item)
         {
           if (item == null)
             return null;

             return DomainServiceLocator.GetDomainObjectFactory().CreateNewTemplate(item);
         }

        /// <summary>
        ///Converte una lista di <paramref name='item' /> di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateObjectModel' />
        /// in un una lista di oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplate' />.
        /// </summary>
        /// <param name='item'> lista di oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateObjectModel' /></param>
        /// <returns> una lista di oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplate'/> con viste. </returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static List<ITemplate> ToDomainObject(this IEnumerable<ITemplateObjectModel> lst)
         {
           if (lst == null)
             return new List<ITemplate>();

             return lst.Select(x => x.ToDomainObject()).ToList();
         }

        /// <summary>
        ///Converte <paramref name='item' /> di tipo <see cref='ITemplateManager.DomainObject.ITemplate' />
        /// in un oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateObjectModel' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplate' /></param>
        /// <returns> oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateObjectModel' /> con viste.</returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplateObjectModel ToObjectModel(this ITemplate item)
         {
           if (item == null)
             throw new ArgumentNullException("ITemplateManager.DomainObject.ITemplate");

             return (item as IDomainObject<ITemplateObjectModel>).ToObjectModel();
         }

        /// <summary>
        ///Converte <paramref name='item' /> di tipo <see cref='ITemplateManager.DomainObject.ITemplate' />
        /// in un oggetto di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateObjectModel' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplate' /></param>
        /// <returns> oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateObjectModel' /> con viste o un valore ti tipo null </returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplateObjectModel ToObjectModel(this IDomainObject<ITemplateObjectModel> item)
         {
           if (item == null)
             throw new ArgumentNullException("TemplateManager.DomainObject.ITemplate");

             return item.WrappedObject;
         }

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Aggiunge le view (<see cref='TemplateManager.DAL.TemplateParagraphView'/>) agli argomenti per la ricerca per l'entità <see cref='ITemplateManager.DomainObject.ITemplateParagraph'/>.
        /// </summary>
        /// <param name='criteria'>Argomenti per la selezione di <see cref='TemplateManager.DomainObject.ITemplateParagraph'/></param>
        /// <returns>Argomenti per la ricerca di <see cref='TemplateManager.DomainObject.ITemplateParagraph'/> con viste.</returns>
        internal static TemplateParagraphSearchCriteria AddViews(this TemplateParagraphSearchCriteria criteria)
         {
           if (criteria == null)
            criteria = new TemplateParagraphSearchCriteria();

             return criteria;
         }

        /// <summary>
        /// Aggiunge le view (<see cref='TemplateManager.TemplateParagraphView'/>) agli argomenti per la ricerca per l'entità <see cref='TemplateManager.DomainObject.ITemplateParagraph'/>.
        /// </summary>
        /// <param name='args'>Argomenti per la selezione di <see cref='TemplateManager.DomainObject.ITemplateParagraph'/></param>
        /// <returns>Argomenti per la ricerca di <see cref='TemplateManager.DomainObject.ITemplateParagraph'/> con viste.</returns>
        internal static TemplateParagraphSelectArgs AddViews(this TemplateParagraphSelectArgs args)
         {
           if (args == null);
             args = new TemplateParagraphSelectArgs();

             return args;
         }

        /// <summary>
        /// Converte <paramref name='item' /> di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' />
        /// in un oggetto di tipo <see cref='TemplateManager.DomainObject.ITemplateParagraph' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' /></param>
        /// <returns> oggetto di tipo <see cref='TemplateManager.DomainObject.ITemplateParagraph' /> con viste.</returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplateParagraph ToDomainObject(this ITemplateParagraphObjectModel item)
         {
           if (item == null)
             throw new ArgumentNullException("TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel");

             return DomainServiceLocator.GetDomainObjectFactory().CreateNewTemplateParagraph(item);
         }

        /// <summary>
        ///Converte <paramref name='item' /> di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' />
        /// in un oggetto di tipo <see cref='TemplateManager.DomainObject.ITemplateParagraph' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' /></param>
        /// <returns> oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplateParagraph'/> con viste. con viste o un valore ti tipo null </returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplateParagraph ToDomainObjectOrNull(this ITemplateParagraphObjectModel item)
         {
           if (item == null)
             return null;

             return DomainServiceLocator.GetDomainObjectFactory().CreateNewTemplateParagraph(item);
         }

        /// <summary>
        ///Converte una lista di <paramref name='item' /> di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' />
        /// in un una lista di oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplateParagraph' />.
        /// </summary>
        /// <param name='item'> lista di oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' /></param>
        /// <returns> una lista di oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplateParagraph'/> con viste. </returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static List<ITemplateParagraph> ToDomainObject(this IEnumerable<ITemplateParagraphObjectModel> lst)
         {
           if (lst == null)
             return new List<ITemplateParagraph>();

             return lst.Select(x => x.ToDomainObject()).ToList();
         }

        /// <summary>
        ///Converte <paramref name='item' /> di tipo <see cref='ITemplateManager.DomainObject.ITemplateParagraph' />
        /// in un oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplateParagraph' /></param>
        /// <returns> oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' /> con viste.</returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplateParagraphObjectModel ToObjectModel(this ITemplateParagraph item)
         {
           if (item == null)
             throw new ArgumentNullException("ITemplateManager.DomainObject.ITemplateParagraph");

             return (item as IDomainObject<ITemplateParagraphObjectModel>).ToObjectModel();
         }

        /// <summary>
        ///Converte <paramref name='item' /> di tipo <see cref='ITemplateManager.DomainObject.ITemplateParagraph' />
        /// in un oggetto di tipo <see cref='TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' />.
        /// </summary>
        /// <param name='item'>oggetto di tipo <see cref='ITemplateManager.DomainObject.ITemplateParagraph' /></param>
        /// <returns> oggetto di tipo <see cref='ITemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel' /> con viste o un valore ti tipo null </returns>
        /// <exception cref=System.ArgumentNullException>item</exception>
        public static ITemplateParagraphObjectModel ToObjectModel(this IDomainObject<ITemplateParagraphObjectModel> item)
         {
           if (item == null)
             throw new ArgumentNullException("TemplateManager.DomainObject.ITemplateParagraph");

             return item.WrappedObject;
         }

        #endregion



        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
