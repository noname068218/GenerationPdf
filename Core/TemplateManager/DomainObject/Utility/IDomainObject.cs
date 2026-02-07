using TemplateManager.DAL.DomainModel;

namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Interfaccia di un generico Domain Object.
    /// </summary>
    /// <typeparam name="TObjectModel"></typeparam>
    interface IDomainObject<out TObjectModel>
        where TObjectModel : IObjectModel
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Istanza dell'object model wrappata nel Domain Object.
        /// </summary>
        TObjectModel WrappedObject { get; }
        #endregion

        #region METHODS
        #endregion

    }
}
