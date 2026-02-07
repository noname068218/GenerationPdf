using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// Classe contenente gli extension methods per SQL Server.
    /// </summary>
    internal static class GatewayLoadView
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
        static IGatewayFactory _gatewayFactory;
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
        /// <summary>
        /// FornitoriRepository per l'entità <c>CatenaStato</c>.
        /// </summary>
        static IGatewayFactory GatewayFactory
        {
            get
            {
                return _gatewayFactory ??= ServiceLocator.GetGatewayFactory();
            }
        }

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
        /// Carica le collection specificate in <paramref name="views"/> per un'istanza di <see cref="TemplateManager.DAL.DomainModel.Template"/>.
        /// <para>Carica in automatico le property riguardanti la viewAnagrafica (proprietà semplici, non collection).</para>
        /// </summary>
        /// <param name="item">Istanza di <see cref="TemplateManager.DAL.DomainModel.Template"/>.</param>
        ///<param name="views">Viste (<see cref="TemplateView"/>).</param>
        /// <exception cref="System.ArgumentNullException"> 'Template'</exception>
        internal static void LoadViewsGateway(this Template item, IEnumerable<TemplateView> views = null)
         {
           if ( item == null)
              throw new ArgumentNullException(nameof(item));

           if (views == null)
             views = Enumerable.Empty<TemplateView>();

           var viewsList = views.ToList();

           if (!views.Contains(TemplateView.ViewAnagrafica))
             viewsList.Add(TemplateView.ViewAnagrafica);

             views = null;

             foreach (var v in viewsList)
              {
                   switch (v)
                   {

                   }
               }
         }

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Carica le collection specificate in <paramref name="views"/> per un'istanza di <see cref="TemplateManager.DAL.DomainModel.TemplateParagraph"/>.
        /// <para>Carica in automatico le property riguardanti la viewAnagrafica (proprietà semplici, non collection).</para>
        /// </summary>
        /// <param name="item">Istanza di <see cref="TemplateManager.DAL.DomainModel.TemplateParagraph"/>.</param>
        ///<param name="views">Viste (<see cref="TemplateParagraphView"/>).</param>
        /// <exception cref="System.ArgumentNullException"> 'TemplateParagraph'</exception>
        internal static void LoadViewsGateway(this TemplateParagraph item, IEnumerable<TemplateParagraphView> views = null)
         {
           if ( item == null)
              throw new ArgumentNullException(nameof(item));

           if (views == null)
             views = Enumerable.Empty<TemplateParagraphView>();

           var viewsList = views.ToList();

           if (!views.Contains(TemplateParagraphView.ViewAnagrafica))
             viewsList.Add(TemplateParagraphView.ViewAnagrafica);

             views = null;

             foreach (var v in viewsList)
              {
                   switch (v)
                   {

                   }
               }
         }

        #endregion



        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
