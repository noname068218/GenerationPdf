using System;
using System.Collections.Generic;
using TemplateManager.Application;
using TemplateManager.Business;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DAL.Gateway;
using TemplateManager.DomainObject;

namespace TemplateManager.DomainService
{
    /// <summary>
    /// Service per la gestione dell' entità Template:
    /// </summary>
    internal class TemplateService : ITemplateWriterService
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
        /// Validatore per l'entità <c>Template</c>.
        /// </summary>
        private ITemplateValidator _TemplateValidator;

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
        /// Validatore per l'entità <c>Template</c>.
        /// </summary>
        protected ITemplateValidator TemplateValidator
        {
            get
            {
                return _TemplateValidator ??
                       (_TemplateValidator = DomainServiceLocator.GetValidatorsFactory().GetTemplateValidator());
            }
        }

        /// <summary>
        /// Ritorna il servizio a livello Object Model per l'entità <c>Template</c>.
        /// </summary>
        protected ITemplateGateway GatewayService
        {
            get
            {
                return ServiceLocator.GetGatewayFactory().GetTemplateGateway();
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
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza 
        /// <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        public void Delete(
            ITemplate item,
            TemplateDeleteArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("Template");

            GatewayService.Delete(item.ToObjectModel());
        }


        /// <summary>
        /// Persiste un'istanza, <paramref name="item"></paramref>, dell'entità <see cref="TemplateManager.DomainObject.ITemplate"/>>.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate"/></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza, 
        /// <paramref name="item"></paramref>, dell'entità <c>Template</c></param>
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        public void Save(
            ITemplate item,
            TemplateSaveArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("Template");

            ITemplateSaveBuilder builder = DomainServiceLocator.GetBuilderFactory().GetTemplateSaveBuilder();

            //Build del Template
            builder.Build(item);

            GatewayService.Save(item.ToObjectModel());
        }


        /// <summary>
        /// Ritorna un'istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /> in base all'<paramref name="id" /> e
        /// agli argomenti specificati in <paramref name="args" />.
        /// </summary>
        /// <param name="id">id relativo al <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        /// <param name="args">argomenti per la selezione di un'istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /> (<see cref="TemplateManager.DAL.Data.TemplateSelectArgs" />)</param>
        /// <returns>
        /// Istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />; null se non esiste alcun Template con l'<paramref name="id"/> specificato.
        /// </returns>
        /// <exception cref="System.ArgumentException">se <paramref name="id"/> minore o uguale a 0.</exception>
        public ITemplate GetById(
            int id,
            TemplateSelectArgs args = null
        )
        {
            if (id <= 0)
                throw new ArgumentException("id <= 0");
            return GatewayService.GetById(id, args).ToDomainObjectOrNull();
            //return RepositoryService.GetById(id).ToDomainObjectOrNull();
        }


        /// <summary>
        /// Ritorna una lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /> in base criteri di ricerca definiti in <paramref name="criteria" />.
        /// </summary>
        /// <param name="criteria">criteri di ricerca (<see cref="TemplateSearchCriteria" />)</param>
        /// <returns>
        /// lista di istanze dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">criteria</exception>
        public IEnumerable<ITemplate> Search(TemplateSearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            //return GatewayService.Search(criteria).ToDomainObject();
            return GatewayService.Search(criteria).ToDomainObject();
        }

        /// <summary>
        /// Crea una nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplate"/>. 
        /// </summary>
        /// <returns>Nuova istanza per l'entità <see cref="TemplateManager.DomainObject.ITemplate"/>.</returns>
        public ITemplate NewTemplate()
        {
            return ServiceLocator.GetIObjectModelFactory().CreateNewTemplate().ToDomainObject();
        }

        #region Gateway

        /// <summary>
        /// Persiste un'istanza dell'entità <c>Template</c>.
        /// </summary>
        /// <param name="Template">istanza dell'entità <c>Template</c></param>
        /// <param name="args">argomenti che descrivono l'operazione di save per un'istanza dell'entità <c>Template</c></param>
		public ITemplate SaveFromGateway(ITemplate item, TemplateSaveArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("Template");

            ITemplateSaveBuilder builder = DomainServiceLocator.GetBuilderFactory().GetTemplateSaveBuilder();

            //Build del Template
            builder.Build(item);

             item = GatewayService.Save(item.ToObjectModel(), args).ToDomainObject();

            return item;
        }


        /// <summary>
        /// Elimina un'istanza <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="item">istanza dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        /// <param name="args">argomenti che descrivono l'operazione di delete per l'istanza 
        /// <paramref name="item" /> dell'entità <see cref="TemplateManager.DomainObject.ITemplate" /></param>
        public void DeleteFromGateway(
            ITemplate item,
            TemplateDeleteArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException("Template");

            GatewayService.Delete(item.ToObjectModel());
        }


        /// <summary>
        /// Ritorna un'istanza dell'entità <c>Template</c> in base all'id e
        /// agli argomenti specificati in <c>TemplateSelectArgs</c>.
        /// </summary>
        /// <param name="id">id numerico relativo al <c>Template</c></param>
        /// <param name="args">viste relative all'entità <c>Template</c></param>
        /// <returns>Istanza dell'entità <c>Template</c></returns>
        public ITemplate GetByIdFromGateway(int id, TemplateSelectArgs args = null)
        {
            if (id <= 0)
                throw new ArgumentException("id <= 0");

            return GatewayService.GetById(id, args).ToDomainObjectOrNull();
        }

        /// <summary>
        /// Ritorna una lista di istanze dell'entità <c>Template</c> in base ai 
        /// criteri di ricerca definiti in <c>criteria</c>.
        /// </summary>
        /// <param name="criteria">criteri di ricerca e viste relative alle istanze dell'entità <c>Template</c> che si intendono recuperare</param>
        /// <returns>Lista di istanze dell'entità <c>Template</c></returns>
        public IEnumerable<ITemplate> SearchFromGateway(TemplateSearchCriteria criteria)
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
        /// <param name="item"><see cref="TemplateManager.DomainObject.ITemplate" /> da eliminare.</param>
        /// <param name="args">argomenti per la cancellazione.</param>
        /// <returns>
        /// true se il <paramref name="item" /> può essere eliminato, false altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">se <paramref name="item"/> è null.</exception>
        public bool CanDelete(
            ITemplate item,
            TemplateDeleteArgs args = null
        )
        {
            if (item == null)
                throw new ArgumentNullException("Template");


            //return DeleteValidator.Verify(item.ToObjectModel(), args);

            return true;
        }


        /// <summary>
        /// Ritorna true se la <paramref name="item" /> può essere salvata.
        /// </summary>
        /// <param name="item"><see cref="TemplateManager.DomainObject.ITemplate" /> da salvare.</param>
        /// <param name="args">argomenti per il salvataggio.</param>
        /// <returns>
        /// true se la <paramref name="item" /> può essere salvata, false altrimenti.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Template</exception>
        public bool CanSave(ITemplate item, TemplateSaveArgs args = null)
        {
            if (item == null)
                throw new ArgumentNullException
                    (
                    "item: il Template non può essere null",
                    "item: non è di tipo TemplateManager.DomainObject.ITemplate");

            return DomainServiceLocator.GetValidatorsFactory().GetTemplateValidator().Validate(item);
        }


        #endregion

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
