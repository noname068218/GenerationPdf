// ============================================
// Service locator per Domain Services API
// ============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.APIs.Business;
using TemplateManager.APIs.Business.Builders.Factoty;
using TemplateManager.APIs.Business.Validators.Factory;
using TemplateManager.APIs.DomainService;

namespace TemplateManager.APIs.Application
{
    public static class DomainServiceAPIs
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

        #region DomainService

        #region Template

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= TemplateManager.APIs.DomainService.ITemplateServiceApi/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= TemplateManager.APIs.DomainService.ITemplateServiceApi/>) a livello Domain.</returns>
        public static ITemplateServiceApi GetTemplateServiceApi() => ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<TemplateServiceApi>();
        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= TemplateManager.APIs.DomainService.ITemplateParagraphServiceApi/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= TemplateManager.APIs.DomainService.ITemplateParagraphServiceApi/>) a livello Domain.</returns>
        public static ITemplateParagraphServiceApi GetTemplateParagraphServiceApi() => ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<TemplateParagraphServiceApi>();
        #endregion



        #endregion

        #endregion

        #endregion

        #region Validators
        /// <summary>
        /// Ritorna la factory per ottenere le classi di validazione.
        /// </summary>
        /// <returns>Factory per ottenere le classi di validazione.</returns>
        internal static IValidatorsFactory GetValidatorsFactory() => ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<ValidatorsFactory>();

        #endregion

        #region Builder
        /// <summary>
        /// Ritorna la factory per i builder per le entità di TemplateManager.
        /// Un builder è una classe che si occupa di eseguire un'operazione 
        /// su un'istanza di un'entità di TemplateManager.
        /// </summary>
        /// <returns></returns>
        internal static IBuilderFactory GetBuilderFactory() => ExtensionMethodsAPIs.GetServiceLocatore().GetDomainService<BuilderFactory>();

        #endregion

        #region Service


        #endregion

        #endregion
        #region NOT PUBLIC

        #endregion

    }
}
