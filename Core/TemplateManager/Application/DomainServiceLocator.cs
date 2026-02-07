using TemplateManager.Business;
using TemplateManager.DomainService;
using TemplateManager.DomainObject;

namespace TemplateManager.Application
{
    /// <summary>
    /// Classe da cui recuperare le istanze di
    /// <list type="circle">
    ///     <item>service che operano a livello di Domain</item>
    ///     <item>validatori per le entità a livello di Domain</item>
    /// </list>
    /// </summary>
    public static class DomainServiceLocator
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
        /// <summary>
        /// Istanza  della ValidatorsFactory.
        /// </summary>
        private static IValidatorsFactory _ValidatorFactory;


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

        internal static IDomainObjectFactory GetDomainObjectFactory() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<DomainObjectFactory>();

        #region DomainService

                #region Template

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= TemplateManager.DomainObject.ITemplate/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= TemplateManager.DomainObject.ITemplate/>) a livello Domain.</returns>
        public static ITemplateReaderService GetTemplateService() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<TemplateService>();

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= TemplateManager.DomainObject.ITemplateParagraph/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>) a livello Domain.</returns>
        public static ITemplateParagraphReaderService GetTemplateParagraphService() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<TemplateParagraphService>();

        #endregion



        #endregion

        #endregion

        #endregion

        #region Validators
        /// <summary>
        /// Ritorna la factory per ottenere le classi di validazione.
        /// </summary>
        /// <returns>Factory per ottenere le classi di validazione.</returns>
        public static IValidatorsFactory GetValidatorsFactory()
        {
            if (_ValidatorFactory == null)
            {
                _ValidatorFactory = new ValidatorsFactory();
            }

            return _ValidatorFactory;
        }


        /// <summary>
        /// Ritorna la factory per i builder per le entità di TemplateManager.
        /// Un builder è una classe che si occupa di eseguire un'operazione 
        /// su un'istanza di un'entità di TemplateManager.
        /// </summary>
        /// <returns></returns>
        internal static IBuilderFactory GetBuilderFactory() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<BuilderFactory>();
        #endregion

        #region Business

        /// <summary>
        /// Ritorna una factory per le entità definite nella namespace di Business di TemplateManager.
        /// </summary>
        /// <returns></returns>
        public static IBusinessFactory GetBusinessFactory() => DAL.ExtensionMethods.GetServiceLocatore().GetDomainService<BusinessFactory>();

        #endregion

        #region Service


        #endregion

        #endregion
        #region NOT PUBLIC

        #endregion

    }
}
