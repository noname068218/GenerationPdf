using TemplateManager.Application;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;
using TemplateManager.DomainService;
using System;
namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Implementazione a livello Domain Object dell'entità <c>TemplateParagraph</c>.
    /// </summary>
    internal class TemplateParagraph : BasePersistableDomainObject<ITemplateParagraphObjectModel, TemplateParagraphDeleteArgs, TemplateParagraphSaveArgs>, ITemplateParagraph
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
        /// Service relativo all'entità <c>TemplateParagraph</c>.
        /// </summary>
        private ITemplateParagraphWriterService _service;
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        /// <summary>
        /// Costruttore per wrapper un oggetto relativo al TemplateParagraph proveniente dall'Object Model. 
        /// </summary>
        /// <param name="item">istanza di <c>ITemplateParagraphObjectModel</c></param>
        internal TemplateParagraph(ITemplateParagraphObjectModel item)
            : base(item)
        {

        }

        /// <summary>
        /// Crea una nuova istanza del Domain Object TemplateParagraph.
        /// </summary>
        internal TemplateParagraph() { }
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC        

        /// <summary>
        /// Ritorna o imposta la property CodeTemplate dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>CodeTemplate</c> dell'entità TemplateParagraph.
        /// </value>
        public Int32 CodeTemplate { get => WrappedObject.CodeTemplate; set => WrappedObject.CodeTemplate = value; }


        /// <summary>
        /// Ritorna o imposta la property NameOfTemplate dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>NameOfTemplate</c> dell'entità TemplateParagraph.
        /// </value>
        public String NameOfTemplate { get => WrappedObject.NameOfTemplate; set => WrappedObject.NameOfTemplate = value; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>AlphaCode</c> dell'entità TemplateParagraph.
        /// </value>
        public String AlphaCode { get => WrappedObject.AlphaCode; set => WrappedObject.AlphaCode = value; }


        /// <summary>
        /// Ritorna o imposta la property PositionIndex dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>PositionIndex</c> dell'entità TemplateParagraph.
        /// </value>
        public Int32 PositionIndex { get => WrappedObject.PositionIndex; set => WrappedObject.PositionIndex = value; }


        /// <summary>
        /// Ritorna o imposta la property PresentationInfo dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>PresentationInfo</c> dell'entità TemplateParagraph.
        /// </value>
        public String PresentationInfo { get => WrappedObject.PresentationInfo; set => WrappedObject.PresentationInfo = value; }


        /// <summary>
        /// Ritorna o imposta la property Title dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>Title</c> dell'entità TemplateParagraph.
        /// </value>
        public String Title { get => WrappedObject.Title; set => WrappedObject.Title = value; }


        /// <summary>
        /// Ritorna o imposta la property Subtitle dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>Subtitle</c> dell'entità TemplateParagraph.
        /// </value>
        public String Subtitle { get => WrappedObject.Subtitle; set => WrappedObject.Subtitle = value; }


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// <c>Paragraph</c> dell'entità TemplateParagraph.
        /// </value>
        public String Paragraph { get => WrappedObject.Paragraph; set => WrappedObject.Paragraph = value; }







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
        /// Ritorna il service relativo all'entità <c>TemplateParagraph</c>.
        /// </summary>
        internal ITemplateParagraphWriterService Service
        {
            get { return _service ?? (_service = DomainServiceLocator.GetTemplateParagraphService() as ITemplateParagraphWriterService); }
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
        /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateParagraphSaveArgs"/>)</param>
        /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.</exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.TemplateParagraph_Edit + "," + Authorizations.TemplateParagraph_New, TipoVerifica = "OR")]
        public ClientMessage Save(TemplateParagraphSaveArgs args = null)
        {

            if (!CanSave(out ClientMessage msg, args) && !msg.Success)
                throw msg.BuildException(msg.EventLog);

             Service.SaveFromGateway(this, args);

            return msg;
        }

        /// <summary>
        /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateParagraphSaveArgs"/>)</param>
        /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.</exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.TemplateParagraph_Edit + "," + Authorizations.TemplateParagraph_New, TipoVerifica = "OR")]
        public ITemplateParagraph SaveFromGateway(out ClientMessage msg, TemplateParagraphSaveArgs args = null)
        {

            if (!CanSave(out msg, args) && !msg.Success)
                throw msg.BuildException(msg.EventLog);

            return Service.SaveFromGateway(this, args);
        }

        /// <summary>
        /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateParagraphDeleteArgs"/>)</param>
        /// <exception cref="TemplateManager.Business.EntityIsNotDeletableException"></exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.TemplateParagraph_Delete)]      
        public ClientMessage Delete(TemplateParagraphDeleteArgs args = null)
        {
            if (!CanDelete(out ClientMessage msg, args))
                return msg;

            Service.DeleteFromGateway(this, args);

            IsDeleted = true;

            return msg;
        }

        /// <summary>
        /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
        /// </summary>
        /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateParagraphDeleteArgs"/>)</param>
        /// <exception cref="TemplateManager.Business.EntityIsNotDeletableException"></exception>
        //[AuthorizationAttribute(SecurityAction.Demand, Authorization = Authorizations.TemplateParagraph_Delete)]      
        public ClientMessage DeleteFromGateway(TemplateParagraphDeleteArgs args = null)
        {
            if (!CanDelete(out ClientMessage msg, args))
                return msg;

            Service.DeleteFromGateway(this, args);

            IsDeleted = true;

            return msg;
        }


        #region Metodi Can


        /// <summary>
        /// Ritorna true è possibile cancellare la TemplateParagraph corrente.
        /// </summary>
        /// <param name="args">argomenti per la cancellazione</param>
        /// <returns>true è possibile cancellare l'entità, solleva un'eccezione altrimenti.</returns>
        /// <exception cref="InvalidOperationException">non è possibile cancellare l'entità.</exception>
        protected override ClientMessage CanBeDeleted(TemplateParagraphDeleteArgs args = null)
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
        /// Ritorna true è possibile salvare la TemplateParagraph corrente.
        /// </summary>
        /// <param name="args">argomenti per il salvataggio</param>
        /// <returns>true è possibile salvare l'entità, solleva un'eccezione altrimenti.</returns>
        /// <exception cref="InvalidOperationException">non è possibile salvare l'entità.</exception>
        protected override ClientMessage CanBeSaved(TemplateParagraphSaveArgs args = null)
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
        /// Crea una nuova istanza di <see cref="TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel" />.
        /// </summary>
        /// <returns>Nuova istanza di <see cref="TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel" />.</returns>
        protected override ITemplateParagraphObjectModel CreateNew()
        {
            return ServiceLocator.GetIObjectModelFactory().CreateNewTemplateParagraph();
        }
        #endregion
        #endregion

        #endregion

    }
}
