
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;

namespace TemplateManager.DomainService
{
    internal interface ITemplateParagraphWriterService : ITemplateParagraphReaderService
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS
        /// <summary>
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        /// <exception cref="System.ArgumentNullException">cliente</exception>
        void Delete(
            ITemplateParagraph item,
            TemplateParagraphDeleteArgs args = null
        );

        /// <summary>
        /// Persiste un'istanza, <paramref name="item"></paramref>, dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/>>.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza, <paramref name="item"></paramref>, dell'entità <c>TemplateParagraph</c></param>
        /// <exception cref="System.ArgumentNullException">item</exception>
        void Save(
            ITemplateParagraph item,
            TemplateParagraphSaveArgs args = null
        );

        #region Gateway

        /// <summary>
        /// Persiste un'istanza dell'entità <c>TemplateParagraph</c>.
        /// </summary>
        /// <param name="item">istanza dell'entità <c>TemplateParagraph</c></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza dell'entità <c>TemplateParagraph</c></param>
        ITemplateParagraph SaveFromGateway(ITemplateParagraph item, TemplateParagraphSaveArgs args = null);


        /// <summary>
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        /// <exception cref="System.ArgumentNullException">cliente</exception>
        void DeleteFromGateway(
            ITemplateParagraph item,
            TemplateParagraphDeleteArgs args = null
        );

        #endregion

        #region Metodi Can


        /// <summary>
        /// Ritorna true se il <paramref name="item" /> può essere eliminato.
        /// </summary>
        /// <param name="item"><see cref="TemplateManager.DomainObject.ITemplateParagraph" /> da eliminare.</param>
        /// <param name="args">argomenti per la cancellazione.</param>
        /// <returns>
        /// true se il <paramref name="item" /> può essere eliminato, false altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">TemplateParagraph</exception>
        bool CanDelete(
            ITemplateParagraph item,
            TemplateParagraphDeleteArgs args = null
        );


        /// <summary>
        /// Ritorna true se la <paramref name="item" /> può essere salvata.
        /// </summary>
        /// <param name="item"><see cref="TemplateManager.DomainObject.ITemplateParagraph" /> da salvare.</param>
        /// <param name="args">argomenti per il salvataggio.</param>
        /// <returns>
        /// true se la <paramref name="item" /> può essere salvata, false altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">TemplateParagraph</exception>
        bool CanSave(
            ITemplateParagraph item,
            TemplateParagraphSaveArgs args = null
        );

        #endregion


        #endregion
    }
}
