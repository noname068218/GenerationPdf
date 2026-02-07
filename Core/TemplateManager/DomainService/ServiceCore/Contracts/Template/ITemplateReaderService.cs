using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;
using System.Collections.Generic;


namespace TemplateManager.DomainService
{
    /// <summary>
    /// Interfaccia per il service a livello di Domain relativo all'entità <see cref="TemplateManager.DomainObject.ITemplate"/>.
    /// </summary>
    public interface ITemplateReaderService
    {
        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS
        /// <summary>
        /// Crea una nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplate"/>. 
        /// </summary>
        /// <returns>Nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplate"/>.</returns>
        ITemplate NewTemplate();


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id e alle viste specificate negli <c>args</c>.
        /// </summary>
        /// <param name="id">Id numerico associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di select su un'istanza dell'entità</param>
        ITemplate GetById(int id, TemplateSelectArgs args = null);


        /// <summary>
        /// Ritorna una lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplate"/> in base ai 
        /// criteri di ricerca definiti in <c>criteria</c>.
        /// </summary>
        /// <param name="criteria">criteri di ricerca e viste relative alle istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplate"/> che si intendono recuperare</param>
        /// <returns>Lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplate"/></returns>
        /// <exception cref="System.ArgumentNullException">se <paramref name="criteria"/> è null.</exception>
        IEnumerable<ITemplate> Search(
            TemplateSearchCriteria criteria
        );


        #region Gateway

        /// <summary>
        /// Ritorna un'istanza dell'entità <c>Template</c> in base all'id e
        /// agli argomenti specificati in <c>TemplateSelectArgs</c>.
        /// </summary>
        /// <param name="id">id numerico relativo al <c>FlussoStato</c></param>
        /// <param name="args">viste relative all'entità <c>Template</c></param>
        /// <returns>Istanza dell'entità <c>Template</c></returns>
        ITemplate GetByIdFromGateway(int id, TemplateSelectArgs args = null);

        /// <summary>
        /// Ritorna una lista di istanze dell'entità <c>Template</c> in base ai 
        /// criteri di ricerca definiti in <c>criteria</c>.
        /// </summary>
        /// <param name="criteria">criteri di ricerca e viste relative alle istanze dell'entità <c>Template</c> che si intendono recuperare</param>
        /// <returns>Lista di istanze dell'entità <c>Template</c></returns>
        IEnumerable<ITemplate> SearchFromGateway(TemplateSearchCriteria criteria);

        #endregion		

        #endregion

    }
}
