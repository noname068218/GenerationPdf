
namespace TemplateManager.UI.Business
{
    /// <summary>
    /// Interfaccia che accetta un IMapper.
    /// </summary>
    public interface IMapping
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS

        /// <summary>
        /// Metodo di accettazione di un <see/>.
        /// </summary>
        /// <param name="draw">Il visitor da generare.</param>
        /// <param name="args">argomenti relativi alla creazione del documento.</param>
        void Accept(IMappingVisitor draw, MappingArgs args = null);

        #endregion


    }
}
