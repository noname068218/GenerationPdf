using TemplateManager.Application;
using TemplateManager.Business;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DAL.Gateway;
using TemplateManager.DomainObject;

namespace TemplateManager.DomainService
{
    /// <summary>
    /// Service per la gestione dell' entità TemplateParagraph:
    /// </summary>
    internal class TemplateParagraphService : ITemplateParagraphWriterService
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

        /// <summary>
        /// Validatore per l'entità <c>TemplateParagraph</c>.
        /// </summary>
        private ITemplateParagraphValidator _TemplateParagraphValidator;

        #endregion

        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        /// <summary>
        /// Validatore per l'entità <c>TemplateParagraph</c>.
        /// </summary>
        protected ITemplateParagraphValidator TemplateParagraphValidator
        {
            get
            {
                return _TemplateParagraphValidator ??
                       (_TemplateParagraphValidator = DomainServiceLocator.GetValidatorsFactory().GetTemplateParagraphValidator());
            }
        }

        /// <summary>
        /// Ritorna il servizio a livello Object Model per l'entità <c>TemplateParagraph</c>.
        /// </summary>
        protected ITemplateParagraphGateway GatewayService
        {
            get
            {
                return ServiceLocator.GetGatewayFactory().GetTemplateParagraphGateway();
            }
        }

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
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza 
        /// <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        public void Delete(
            ITemplateParagraph item,
            TemplateParagraphDeleteArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("TemplateParagraph");

            GatewayService.Delete(item.ToObjectModel());
        }


        /// <summary>
        /// Persiste un'istanza, <paramref name="item"></paramref>, dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/>>.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza, 
        /// <paramref name="item"></paramref>, dell'entità <c>TemplateParagraph</c></param>
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        public void Save(
            ITemplateParagraph item,
            TemplateParagraphSaveArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("TemplateParagraph");

            ITemplateParagraphSaveBuilder builder = DomainServiceLocator.GetBuilderFactory().GetTemplateParagraphSaveBuilder();

            //Build del TemplateParagraph
            builder.Build(item);

            GatewayService.Save(item.ToObjectModel());
        }


        /// <summary>
        /// Ritorna un'istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /> in base all'<paramref name="id" /> e
        /// agli argomenti specificati in <paramref name="args" />.
        /// </summary>
        /// <param name="id">id relativo al <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        /// <param name="args">argomenti per la selezione di un'istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /> (<see cref="TemplateManager.DAL.Data.TemplateParagraphSelectArgs" />)</param>
        /// <returns>
        /// Istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />; null se non esiste alcun TemplateParagraph con l'<paramref name="id"/> specificato.
        /// </returns>
        /// <exception cref="System.ArgumentException">se <paramref name="id"/> minore o uguale a 0.</exception>
        public ITemplateParagraph GetById(
            int id,
            TemplateParagraphSelectArgs args = null
        )
        {
            if (id <= 0)
                throw new ArgumentException("id <= 0");
            return GatewayService.GetById(id, args).ToDomainObjectOrNull();
            //return RepositoryService.GetById(id).ToDomainObjectOrNull();
        }


        /// <summary>
        /// Ritorna una lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /> in base criteri di ricerca definiti in <paramref name="criteria" />.
        /// </summary>
        /// <param name="criteria">criteri di ricerca (<see cref="TemplateParagraphSearchCriteria" />)</param>
        /// <returns>
        /// lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">criteria</exception>
        public IEnumerable<ITemplateParagraph> Search(TemplateParagraphSearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            //return GatewayService.Search(criteria).ToDomainObject();
            return GatewayService.Search(criteria).ToDomainObject();
        }

        /// <summary>
        /// Crea una nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/>. 
        /// </summary>
        /// <returns>Nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph"/>.</returns>
        public ITemplateParagraph NewTemplateParagraph()
        {
            return ServiceLocator.GetIObjectModelFactory().CreateNewTemplateParagraph().ToDomainObject();
        }

        #region Gateway

        /// <summary>
        /// Persiste un'istanza dell'entità <c>TemplateParagraph</c>.
        /// </summary>
        /// <param name="TemplateParagraph">istanza dell'entità <c>TemplateParagraph</c></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza dell'entità <c>TemplateParagraph</c></param>
		public ITemplateParagraph SaveFromGateway(ITemplateParagraph item, TemplateParagraphSaveArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("TemplateParagraph");

            ITemplateParagraphSaveBuilder builder = DomainServiceLocator.GetBuilderFactory().GetTemplateParagraphSaveBuilder();

            //Build del TemplateParagraph
            builder.Build(item);

             item = GatewayService.Save(item.ToObjectModel(), args).ToDomainObject();

            return item;
        }


        /// <summary>
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza 
        /// <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" /></param>
        public void DeleteFromGateway(
            ITemplateParagraph item,
            TemplateParagraphDeleteArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("TemplateParagraph");

            GatewayService.Delete(item.ToObjectModel());
        }


        /// <summary>
        /// Ritorna un'istanza dell'entità <c>TemplateParagraph</c> in base all'id e
        /// agli argomenti specificati in <c>TemplateParagraphSelectArgs</c>.
        /// </summary>
        /// <param name="id">id numerico relativo al <c>TemplateParagraph</c></param>
        /// <param name="args">viste relative all'entità <c>TemplateParagraph</c></param>
        /// <returns>Istanza dell'entità <c>TemplateParagraph</c></returns>
        public ITemplateParagraph GetByIdFromGateway(int id, TemplateParagraphSelectArgs args = null)
        {
            if (id <= 0)
                throw new ArgumentException("id <= 0");

            return GatewayService.GetById(id, args).ToDomainObjectOrNull();
        }

        /// <summary>
        /// Ritorna una lista di istanze dell'entità <c>TemplateParagraph</c> in base ai 
        /// criteri di ricerca definiti in <c>criteria</c>.
        /// </summary>
        /// <param name="criteria">criteri di ricerca e viste relative alle istanze dell'entità <c>TemplateParagraph</c> che si intendono recuperare</param>
        /// <returns>Lista di istanze dell'entità <c>TemplateParagraph</c></returns>
        public IEnumerable<ITemplateParagraph> SearchFromGateway(TemplateParagraphSearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));

            return GatewayService.Search(criteria).ToDomainObject();
        }

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
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        public bool CanDelete(
            ITemplateParagraph item,
            TemplateParagraphDeleteArgs args = null
        )
        {
            if (item == null)
                throw new ArgumentNullException("TemplateParagraph");


            //return DeleteValidator.Verify(item.ToObjectModel(), args);

            return true;
        }


        /// <summary>
        /// Ritorna true se la <paramref name="item" /> può essere salvata.
        /// </summary>
        /// <param name="item"><see cref="TemplateManager.DomainObject.ITemplateParagraph" /> da salvare.</param>
        /// <param name="args">argomenti per il salvataggio.</param>
        /// <returns>
        /// true se la <paramref name="item" /> può essere salvata, false altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">TemplateParagraph</exception>
        public bool CanSave(ITemplateParagraph item, TemplateParagraphSaveArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException
                    (
                    "item: il TemplateParagraph non può essere null",
                    "item: non è di tipo TemplateManager.DomainObject.ITemplateParagraph");

            return DomainServiceLocator.GetValidatorsFactory().GetTemplateParagraphValidator().Validate(item);
        }


        #endregion

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
