using TemplateManager.UI.Business;
using TemplateManager.UI.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.UI.Application
{
    public static class DomainServiceUI
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

        #region NOT PUBLIC

        ///// <summary>
        ///// Ritorna un'istanza del service relativo all'entità a livello Object Model.
        ///// </summary>
        ///// <returns>istanza del service relativo all'entità a livello Object Model.</returns>
        internal static IServiceLocatorFactory GetServiceLocatore() => ServiceLocatorFactory.Instance;
        #endregion

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

        //#region LicenseManager

        ///// <summary>
        ///// Ritorna un'istanza del service relativo all'entità <see cref= TemplateManager.UI.DomainService.ILicenseManagerServiceApi/> a livello Domain.
        ///// </summary>
        ///// <returns>istanza del service relativo all'entità (<see cref= TemplateManager.UI.DomainService.ILicenseManagerServiceApi/>) a livello Domain.</returns>
        //public static ILicenseManagerService GetLicenseManagerService() => GetServiceLocatore().GetDomainService<LicenseManagerService>();
        //#endregion

        //#region UserManager

        ///// <summary>
        ///// Ritorna un'istanza del service relativo all'entità <see cref= TemplateManager.UI.DomainService.IUserManagerServiceApi/> a livello Domain.
        ///// </summary>
        ///// <returns>istanza del service relativo all'entità (<see cref= TemplateManager.UI.DomainService.IUserManagerServiceApi/>) a livello Domain.</returns>
        //public static IUserManagerService GetUserManagerService() => GetServiceLocatore().GetDomainService<UserManagerService>();
        //#endregion




        #endregion

        #endregion

        #endregion

        #region Validators
        /// <summary>
        /// Ritorna la factory per ottenere le classi di validazione.
        /// </summary>
        /// <returns>Factory per ottenere le classi di validazione.</returns>
        internal static IValidatorsFactory GetValidatorsFactory() =>  new ValidatorsFactory();

        #endregion

        #region Builder
        /// <summary>
        /// Ritorna la factory per i builder per le entità di TemplateManager.
        /// Un builder è una classe che si occupa di eseguire un'operazione 
        /// su un'istanza di un'entità di TemplateManager.
        /// </summary>
        /// <returns></returns>
        internal static IBuilderFactory GetBuilderFactory() => new BuilderFactory();

        #endregion

        #region Service

        #region ManageGeneratePdf

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= IManageGeneratePdfService/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= IManageGeneratePdfService/>) a livello Domain.</returns>
        public static IManageGeneratePdfService GetManageGeneratePdfService() => GetServiceLocatore().GetDomainService<ManageGeneratePdfService>();
        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= ITemplateParagraphService/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= ITemplateParagraphService/>) a livello Domain.</returns>
        public static ITemplateParagraphService GetTemplateParagraphService() => GetServiceLocatore().GetDomainService<TemplateParagraphService>();
        #endregion

        #region Template

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= ITemplateService/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= ITemplateService/>) a livello Domain.</returns>
        public static ITemplateService GetTemplateService() => GetServiceLocatore().GetDomainService<TemplateService>();
        #endregion

        #endregion

        #endregion
        #region NOT PUBLIC

        #endregion

    }
}
