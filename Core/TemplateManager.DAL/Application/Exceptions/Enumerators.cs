
namespace TemplateManager.DAL.Application
{
    /// <summary>
    /// Enum che indica il livello a cui è avvenuto un'eccezione.
    /// </summary>
    public enum LayerExceptions
    {
        /// <summary>
        /// Indica che non è possibile effettuare il save di un'entità figlio prima di
        /// aver salvato i padri.
        /// </summary>
        AncestorsMustBeSavedFirst,
        /// <summary>
        /// Domain
        /// </summary>
        CoreApplication,
        /// <summary>
        /// Service
        /// </summary>
        ConfigurationContex,
        /// <summary>
        /// DAL
        /// </summary>
        ContexManager,
        /// <summary>
        /// Authorization
        /// </summary>
        DomainModel,

        /// <summary>
        /// Authentication
        /// </summary>
        Gateway,
        /// <summary>
        /// 
        /// </summary>
        Repository,

        /// <summary>
        /// Domain
        /// </summary>
        CoreBusiness,
        /// <summary>
        /// Service
        /// </summary>
        CoreDomainObject,
    }
}
