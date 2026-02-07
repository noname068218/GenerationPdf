using TemplateManager.Application;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;
using TemplateManager.DomainService;
using System;
namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Implementazione a livello Domain Object dell'entità <c>Template</c>.
    /// </summary>
    internal class Template : BasePersistableDomainObject<ITemplateObjectModel, TemplateDeleteArgs, TemplateSaveArgs>, ITemplate
    {

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
        /// Service relativo all'entità <c>Template</c>.
        /// </summary>
        private ITemplateWriterService _service;
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        /// <summary>
        /// Costruttore per wrapper un oggetto relativo al Template proveniente dall'Object Model. 
        /// </summary>
        /// <param name="item">istanza di <c>ITemplateObjectModel</c></param>
        internal Template(ITemplateObjectModel item)
            : base(item)
        {

        }

        /// <summary>
        /// Crea una nuova istanza del Domain Object Template.
        /// </summary>
        internal Template() { }
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC        

        /// <summary>
        /// Ritorna o imposta la property Code dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// <c>Code</c> dell'entità Template.
        /// </value>
        public Int32 Code { get => WrappedObject.Code; set => WrappedObject.Code = value; }


        /// <summary>
        /// Ritorna o imposta la property Name dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// <c>Name</c> dell'entità Template.
        /// </value>
        public String Name { get => WrappedObject.Name; set => WrappedObject.Name = value; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// <c>AlphaCode</c> dell'entità Template.
        /// </value>
        public String AlphaCode { get => WrappedObject.AlphaCode; set => WrappedObject.AlphaCode = value; }


        /// <summary>
        /// Ritorna o imposta la property Description dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// <c>Description</c> dell'entità Template.
        /// </value>
        public String Description { get => WrappedObject.Description; set => WrappedObject.Description = value; }







        /// <summary>
        /// Ritorna o imposta il Parent dell'istanza.
        /// </summary>
        public IDomainObjectParent Parent
        {
            get;
            set;
        }


        #endregion
        #region NOT PUBLIC
        /// <summary>
        /// Verifica mediante CAS se il Parent può essere editato dall'utente 
        /// corrente.
        /// </summary>
        private void CheckPermission()
        {
            if (Parent != null)
            {
                var res = Parent.CanUpdateChild;
            }
        }
        /// <summary>
        /// Ritorna il service relativo all'entità <c>Template</c>.
        /// </summary>
        internal ITemplateWriterService Service
        {
            get { return _service ?? (_service = DomainServiceLocator.GetTemplateService() as ITemplateWriterService); }
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
        /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateSaveArgs"/>)</param>
        /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.</exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.Template_Edit + "," + Authorizations.Template_New, TipoVerifica = "OR")]
        public ClientMessage Save(TemplateSaveArgs args = null)
        {

            if (!CanSave(out ClientMessage msg, args) && !msg.Success)
                throw msg.BuildException(msg.EventLog);

             Service.SaveFromGateway(this, args);

            return msg;
        }

        /// <summary>
        /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateSaveArgs"/>)</param>
        /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.</exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.Template_Edit + "," + Authorizations.Template_New, TipoVerifica = "OR")]
        public ITemplate SaveFromGateway(out ClientMessage msg, TemplateSaveArgs args = null)
        {

            if (!CanSave(out msg, args) && !msg.Success)
                throw msg.BuildException(msg.EventLog);

            return Service.SaveFromGateway(this, args);
        }

        /// <summary>
        /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateDeleteArgs"/>)</param>
        /// <exception cref="TemplateManager.Business.EntityIsNotDeletableException"></exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.Template_Delete)]      
        public ClientMessage Delete(TemplateDeleteArgs args = null)
        {
            if (!CanDelete(out ClientMessage msg, args))
                return msg;

            Service.DeleteFromGateway(this, args);

            IsDeleted = true;

            return msg;
        }

        /// <summary>
        /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
        /// </summary>
        /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateDeleteArgs"/>)</param>
        /// <exception cref="TemplateManager.Business.EntityIsNotDeletableException"></exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.Template_Delete)]      
        public ClientMessage DeleteFromGateway(TemplateDeleteArgs args = null)
        {
            if (!CanDelete(out ClientMessage msg, args))
                return msg;

            Service.DeleteFromGateway(this, args);

            IsDeleted = true;

            return msg;
        }


        #region Metodi Can


        /// <summary>
        /// Ritorna true è possibile cancellare la Template corrente.
        /// </summary>
        /// <param name="args">argomenti per la cancellazione</param>
        /// <returns>true è possibile cancellare l'entità, solleva un'eccezione altrimenti.</returns>
        /// <exception cref="InvalidOperationException">non è possibile cancellare l'entità.</exception>
        protected override ClientMessage CanBeDeleted(TemplateDeleteArgs args = null)
        {
            ClientMessage msg = new();
            if (!IsDeleted && Id > 0)
            {
                Service.CanDelete(this, args);
                return msg;
            }

            return msg;
        }

        /// <summary>
        /// Ritorna true è possibile salvare la Template corrente.
        /// </summary>
        /// <param name="args">argomenti per il salvataggio</param>
        /// <returns>true è possibile salvare l'entità, solleva un'eccezione altrimenti.</returns>
        /// <exception cref="InvalidOperationException">non è possibile salvare l'entità.</exception>
        protected override ClientMessage CanBeSaved(TemplateSaveArgs args = null)
        {
            ClientMessage msg = new();

            if (!IsDeleted)
            {
                Service.CanSave(this, args);
                return msg;
            }

            return msg;
        }

        #endregion

        #endregion
        #region NOT PUBLIC
        /// <summary>
        /// Crea una nuova istanza di <see cref="TemplateManager.DAL.DomainModel.ITemplateObjectModel" />.
        /// </summary>
        /// <returns>Nuova istanza di <see cref="TemplateManager.DAL.DomainModel.ITemplateObjectModel" />.</returns>
        protected override ITemplateObjectModel CreateNew()
        {
            return ServiceLocator.GetIObjectModelFactory().CreateNewTemplate();
        }
        #endregion
        #endregion

        #endregion

    }
}
