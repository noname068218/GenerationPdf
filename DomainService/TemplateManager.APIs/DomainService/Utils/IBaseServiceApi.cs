using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.APIs.DomainService
{
    /// <summary>
    /// Interfaccia che descrive un repository per una generic entità.
    /// </summary>
    public interface IBaseServiceApi<TEntity, TSearchCriteria,TSelectArgs, TOutputEntity, TFeedBackOperation>
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
        Task<TFeedBackOperation> SaveAsync(TEntity input, string tokenAccess = null);


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id.
        /// </summary>
        /// <param name="Id">Id identificativo associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di save sull'istanza dell'entità.</param>
        /// <param name="tokenAccess"> tokenAccess di validazione</param>
        /// <returns></returns>
        Task<TOutputEntity> GetByIdAsync(int Id, TSelectArgs args, string tokenAccess = null);


        /// <summary>
        /// Recupera un'insieme di istanze dell'entità considerata in base ai criteri di ricerca definiti negli <c>args</c>.
        /// </summary>
        /// <param name="searchCriteria">argomenti che descrivono l'operazione di search sulle istanze dell'entità</param>
        /// <param name="tokenAccess">tokenAccess di validazione</param>
        /// <returns></returns>
        Task<TOutputEntity> LoadListAsync(TSearchCriteria searchCriteria, string tokenAccess = null);

        /// <summary>
        /// Elimina un'istanza dell'entità. 
        /// </summary>
        /// <param name="Id">Id identificativo associato all'entità</param>
        /// <param name="tokenAccess">tokenAccess di validazione</param>
        /// <returns> entita feedback Operation</returns>
        Task<TFeedBackOperation> DeleteAsync(int Id, string tokenAccess = null);

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
