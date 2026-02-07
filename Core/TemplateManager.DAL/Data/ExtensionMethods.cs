using TemplateManager.DAL.Application;
using System;

namespace TemplateManager.DAL.Data
{
    /// <summary>
    /// Extension methods per il namespace TemplateManager.DAL.Data
    /// </summary>
    public static class ExtensionMethods
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
        /// Crea gli <paramref name=args/> se non esistono, aggiunge almeno la view Anagrafica di <see cref= TemplateManager.TemplateView/>.
        /// </summary>
        /// <param name=args>argomenti per la selezione.</param>
        public static TemplateSelectArgs Fix(this TemplateSelectArgs args)
         {
           if (args == null)
               args = new TemplateSelectArgs();

           if (!args.Views.Contains(TemplateView.ViewAnagrafica))
               args.AddView(TemplateView.ViewAnagrafica);

               return args;
         }

        /// <summary>
        /// Aggiunge almeno la view Anagrafica di <see cref= TemplateManager.TemplateView/> ai criteri di ricerca, <paramref name=criteria/>.
        /// </summary>
        /// <param name=args>argomenti per la ricerca.</param>
        /// <exception cref=ArgumentNullException>i criteri di ricerca non sono stati specificati.</exception>
        public static TemplateSearchCriteria Fix(this TemplateSearchCriteria criteria)
         {
           if (criteria == null)
               throw new ArgumentNullException();

           if (!criteria.Views.Contains(TemplateView.ViewAnagrafica))
               criteria.AddView(TemplateView.ViewAnagrafica);

               return criteria;

         }
        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Crea gli <paramref name=args/> se non esistono, aggiunge almeno la view Anagrafica di <see cref= TemplateManager.TemplateParagraphView/>.
        /// </summary>
        /// <param name=args>argomenti per la selezione.</param>
        public static TemplateParagraphSelectArgs Fix(this TemplateParagraphSelectArgs args)
         {
           if (args == null)
               args = new TemplateParagraphSelectArgs();

           if (!args.Views.Contains(TemplateParagraphView.ViewAnagrafica))
               args.AddView(TemplateParagraphView.ViewAnagrafica);

               return args;
         }

        /// <summary>
        /// Aggiunge almeno la view Anagrafica di <see cref= TemplateManager.TemplateParagraphView/> ai criteri di ricerca, <paramref name=criteria/>.
        /// </summary>
        /// <param name=args>argomenti per la ricerca.</param>
        /// <exception cref=ArgumentNullException>i criteri di ricerca non sono stati specificati.</exception>
        public static TemplateParagraphSearchCriteria Fix(this TemplateParagraphSearchCriteria criteria)
         {
           if (criteria == null)
               throw new ArgumentNullException();

           if (!criteria.Views.Contains(TemplateParagraphView.ViewAnagrafica))
               criteria.AddView(TemplateParagraphView.ViewAnagrafica);

               return criteria;

         }
        #endregion



        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
