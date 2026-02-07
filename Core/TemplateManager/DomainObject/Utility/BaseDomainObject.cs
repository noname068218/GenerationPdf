using System;
using TemplateManager.Business;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.DomainModel;

namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Classe base per un DomainObject.
    /// </summary>
    /// <typeparam name="TWrappedObject">Interfaccia dell'oggetto wrappato appartenente all'Object Model.</typeparam>
    public abstract class BaseDomainObject<TWrappedObject> : IObjectModel, IDomainObject<TWrappedObject>
        where TWrappedObject : IObjectModel
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
        private TWrappedObject _wrappedObject;
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="wrappedObject">oggetto da wrappare appartenente all'Object Model.</param>
        protected BaseDomainObject(TWrappedObject wrappedObject)
        {
            if (wrappedObject == null)
                throw new ArgumentNullException();

            WrappedObject = wrappedObject;
        }

        protected BaseDomainObject()
        {
            WrappedObject = CreateNew();

            DomainObjectFactory.DomainObjectTable.Add(WrappedObject, this);
        }

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
        /// <summary>
        /// Oggetto appartenente all'ObjectModel wrappato dal Domain Object.
        /// </summary>
        public TWrappedObject WrappedObject
        {
            get
            {
                return _wrappedObject;
            }

            protected set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _wrappedObject = value;
            }
        }

        /// <summary>
        /// Id associato all'istanza dell'entità.
        /// </summary>
        public virtual int Id
        {
            get { return WrappedObject.Id; }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTimeOffset? DateCreation => WrappedObject.DateCreation;


        /// <summary>
        /// 
        /// </summary>
        public bool IsNew => WrappedObject.IsNew;

        public DateTimeOffset? DateChange => WrappedObject.DateChange;

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
        /// <summary>
        /// Crea una nuova istanza di IObjectModel.
        /// </summary>
        /// <returns>nuova istanza di IObjectModel.</returns>
        protected abstract TWrappedObject CreateNew();

        /// <summary>
        /// Esegue <paramref name="action"/> e restituisce un messaggio contenente l'esito dell'azione.
        /// Se durante l'esecuzione di <paramref name="action"/> si verifica un'eccezione questa viene
        /// inserita nel messaggio.
        /// </summary>
        /// <param name="action">Azione da eseguire.</param>
        /// <param name="msg">Messaggio.</param>
        /// <returns><c>true</c> se l'azione <paramref name="action"/> è andata a buon fine; <c>false</c> altrimenti.</returns>
        protected bool PerformActionAndReturnWithMessage(Func<ClientMessage> action, out ClientMessage msg)
        {
            bool success;
            msg = new ClientMessage();
            try
            {
                msg = action();
                success = msg.Success;
            }
            catch (TemplateManagerValidationException ex)
            {
                msg.EventLog = ex.EVLog;
                msg.BuildException(ex.EVLog);
                success = false;
            }
            catch (Exception e)
            {
                msg.Exception = e;
                msg.BuildException(LayerExceptions.CoreDomainObject, "TemplateManager.DomainObject.BaseDomainObject");
                success = false;
            }

            msg.Stato = (success ? StatusCodes.Success : StatusCodes.CannotNotBeExecute);
            msg.Success = success;
            return success;
        }


        #endregion
        #endregion

        #endregion
    }
}
