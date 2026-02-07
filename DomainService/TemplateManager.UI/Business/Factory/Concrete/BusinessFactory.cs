
namespace TemplateManager.UI.Business
{
    /// <summary>
    /// Implementazione concreta dell'intefaccia Factory per il Business.
    /// </summary>
    class BusinessFactory : IBusinessFactory
    {
        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS

        /// <summary>
        /// Ritorna un'istanza del validatore per <see cref="IMappingVisitor"/>.
        /// </summary>
        /// <returns>
        /// Istanza del validatore per <see cref="IMappingVisitor"/>.
        /// </returns>
        public IMappingVisitor GetMappingVisitor()
        {
            return new MappingVisitor();
        }



        #endregion


    }

}
