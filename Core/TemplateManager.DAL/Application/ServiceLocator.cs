using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;
using TemplateManager.DAL.Gateway;
using TemplateManager.DAL;

namespace TemplateManager.DAL.Application
{
    /// <summary>
    /// Classe da cui recuperare le istanze di
    /// <list type="circle">
    ///     <item><c>IObjectModelFactory</c></item>
    ///     <item><c>IDALContextManagerDispenser</c></item>
    ///     <item><c>IDALContextManagerBuilder</c></item>
    ///     <item>service che operano a livello di ObjectModel</item>
    /// </list>
    /// </summary>
    public static class ServiceLocator
    {

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

        #region ObjectModel

        public static IObjectModelFactory GetIObjectModelFactory()
        {
            return DAL.ExtensionDALMethods.GetServiceLocatore().GetDomainService<EFObjectFactory>();
        }
        #endregion

        #region ObjectModel
        public static IServiceLocatorFactory GetIServiceLocatorFactory()
        {
            return DAL.ExtensionDALMethods.GetServiceLocatore().GetDomainService<ServiceLocatorFactory>();
        }
        #endregion


        #region Gateway

        /// <summary>
        /// Ritorna un'istanza della classe factory per i Gateway
        /// </summary>
        /// <returns></returns>

        public static IGatewayFactory GetGatewayFactory()
        {
            return DAL.ExtensionDALMethods.GetServiceLocatore().GetDomainService<GatewayFactory>();
        }

        #endregion

        #region ContextTemplateManager



        #endregion

        #endregion

        #region Privat

        #region ContextBilling


        #endregion


        #endregion

        #endregion
    }
}

