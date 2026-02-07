using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.UI.DomainService
{
    /// <summary>
    /// Interfaccia che descrive un repository per una generic entità.
    /// </summary>
    public interface IBaseServiceUI<TEntity, TSearchCriteria, TSelectArgs, TOutputEntity, TFeedBackOperation>
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

        /// <summary>
        /// Salva un'istanza dell'entità. 
        /// </summary>
        /// <param name="input">istanza dell'entità./param>
        /// <param name="tokenAccess"> tokenAccess di validazione</param>
        /// <returns></returns>
        TFeedBackOperation SaveAsync(TEntity input, string tokenAccess);


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id.
        /// </summary>
        /// <param name="Id">Id identificativo associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di save sull'istanza dell'entità.</param>
        /// <param name="tokenAccess"> tokenAccess di validazione</param>
        /// <returns></returns>
        TOutputEntity GetByIdAsync(int Id, string tokenAccess);


        /// <summary>
        /// Recupera un'insieme di istanze dell'entità considerata in base ai criteri di ricerca definiti negli <c>args</c>.
        /// </summary>
        /// <param name="searchCriteria">argomenti che descrivono l'operazione di search sulle istanze dell'entità</param>
        /// <param name="tokenAccess">tokenAccess di validazione</param>
        /// <returns></returns>
        TOutputEntity LoadListAsync(TSearchCriteria searchCriteria, string tokenAccess);

        /// <summary>
        /// Elimina un'istanza dell'entità. 
        /// </summary>
        /// <param name="Id">Id identificativo associato all'entità</param>
        /// <param name="tokenAccess">tokenAccess di validazione</param>
        /// <returns> entita feedback Operation</returns>
        TFeedBackOperation DeleteAsync(int Id, string tokenAccess);

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
