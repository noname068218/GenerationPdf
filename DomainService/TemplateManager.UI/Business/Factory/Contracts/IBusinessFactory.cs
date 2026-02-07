
namespace TemplateManager.UI.Business
{
    /// <summary>
    /// Interfacia di Factory per il Business.
    /// </summary>
    public interface IBusinessFactory
    {
        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS

        #region MappingVisitor

        /// <summary>
        /// Ritorna un istanza di <see cref="IMappingVisitor"/> per la creazione  un'entità che implementa l'interfaccia <see cref="IMappingVisitor"/>.
        /// </summary>
        /// <returns></returns>
        IMappingVisitor GetMappingVisitor();

        #endregion

        #endregion

    }
}
