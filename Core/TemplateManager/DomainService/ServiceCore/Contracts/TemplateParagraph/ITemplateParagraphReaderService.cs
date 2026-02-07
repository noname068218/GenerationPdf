using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;
using System.Collections.Generic;


namespace TemplateManager.DomainService
{
    /// <summary>
    /// Interfaccia per il service a livello di Domain relativo all'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/>.
    /// </summary>
    public interface ITemplateParagraphReaderService
    {
        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS
        /// <summary>
        /// Crea una nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/>. 
        /// </summary>
        /// <returns>Nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/>.</returns>
        ITemplateParagraph NewTemplateParagraph();


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id e alle viste specificate negli <c>args</c>.
        /// </summary>
        /// <param name="id">Id numerico associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di select su un'istanza dell'entità</param>
        ITemplateParagraph GetById(int id, TemplateParagraphSelectArgs args = null);


        /// <summary>
        /// Ritorna una lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/> in base ai 
        /// criteri di ricerca definiti in <c>criteria</c>.
        /// </summary>
        /// <param name="criteria">criteri di ricerca e viste relative alle istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/> che si intendono recuperare</param>
        /// <returns>Lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/></returns>
        /// <exception cref="System.ArgumentNullException">se <paramref name="criteria"/> è null.</exception>
        IEnumerable<ITemplateParagraph> Search(
            TemplateParagraphSearchCriteria criteria
        );


        #region Gateway

        /// <summary>
        /// Ritorna un'istanza dell'entità <c>TemplateParagraph</c> in base all'id e
        /// agli argomenti specificati in <c>TemplateParagraphSelectArgs</c>.
        /// </summary>
        /// <param name="id">id numerico relativo al <c>FlussoStato</c></param>
        /// <param name="args">viste relative all'entità <c>TemplateParagraph</c></param>
        /// <returns>Istanza dell'entità <c>TemplateParagraph</c></returns>
        ITemplateParagraph GetByIdFromGateway(int id, TemplateParagraphSelectArgs args = null);

        /// <summary>
        /// Ritorna una lista di istanze dell'entità <c>TemplateParagraph</c> in base ai 
        /// criteri di ricerca definiti in <c>criteria</c>.
        /// </summary>
        /// <param name="criteria">criteri di ricerca e viste relative alle istanze dell'entità <c>TemplateParagraph</c> che si intendono recuperare</param>
        /// <returns>Lista di istanze dell'entità <c>TemplateParagraph</c></returns>
        IEnumerable<ITemplateParagraph> SearchFromGateway(TemplateParagraphSearchCriteria criteria);

        #endregion		

        #endregion

    }
}
