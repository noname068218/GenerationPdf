
namespace TemplateManager.DAL.Application
{
    /// <summary>
    /// Classe che descrive il contesto all'interno del quale è avvenuto l'eccezione.
    /// </summary>
    public class CoreAppExceptionContext
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
        /// <summary>
        /// Ritorna il livello a cui è avvenuta l'eccezione
        /// </summary>
        /// <value>
        /// Livello a cui è avvenuta l'eccezione
        /// </value>
        public LayerExceptions Livello { get; private set; }

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
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

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
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        /// <summary>
        /// Inizializza una nuova istanza di <see cref="CoreAppExceptionContext"/>.
        /// </summary>
        /// <param name="livello">Livello a cui si è verificata l'eccezione.</param>
        public CoreAppExceptionContext(LayerExceptions livello)
        {
            Livello = livello;
        }
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
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
