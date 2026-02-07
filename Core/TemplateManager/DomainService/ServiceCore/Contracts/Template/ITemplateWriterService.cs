
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;

namespace TemplateManager.DomainService
{
    internal interface ITemplateWriterService : ITemplateReaderService
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS
        /// <summary>
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        /// <exception cref="System.ArgumentNullException">cliente</exception>
        void Delete(
            ITemplate item,
            TemplateDeleteArgs args = null
        );

        /// <summary>
        /// Persiste un'istanza, <paramref name="item"></paramref>, dell'entità <see cref="TemplateManager.DomainObject.ITemplate"/>>.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate"/></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza, <paramref name="item"></paramref>, dell'entità <c>Template</c></param>
        /// <exception cref="System.ArgumentNullException">item</exception>
        void Save(
            ITemplate item,
            TemplateSaveArgs args = null
        );

        #region Gateway

        /// <summary>
        /// Persiste un'istanza dell'entità <c>Template</c>.
        /// </summary>
        /// <param name="item">istanza dell'entità <c>Template</c></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza dell'entità <c>Template</c></param>
        ITemplate SaveFromGateway(ITemplate item, TemplateSaveArgs args = null);


        /// <summary>
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        /// <exception cref="System.ArgumentNullException">cliente</exception>
        void DeleteFromGateway(
            ITemplate item,
            TemplateDeleteArgs args = null
        );

        #endregion

        #region Metodi Can


        /// <summary>
        /// Ritorna true se il <paramref name="item" /> può essere eliminato.
        /// </summary>
        /// <param name="item"><see cref="TemplateManager.DomainObject.ITemplate" /> da eliminare.</param>
        /// <param name="args">argomenti per la cancellazione.</param>
        /// <returns>
        /// true se il <paramref name="item" /> può essere eliminato, false altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Template</exception>
        bool CanDelete(
            ITemplate item,
            TemplateDeleteArgs args = null
        );


        /// <summary>
        /// Ritorna true se la <paramref name="item" /> può essere salvata.
        /// </summary>
        /// <param name="item"><see cref="TemplateManager.DomainObject.ITemplate" /> da salvare.</param>
        /// <param name="args">argomenti per il salvataggio.</param>
        /// <returns>
        /// true se la <paramref name="item" /> può essere salvata, false altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Template</exception>
        bool CanSave(
            ITemplate item,
            TemplateSaveArgs args = null
        );

        #endregion


        #endregion
    }
}
