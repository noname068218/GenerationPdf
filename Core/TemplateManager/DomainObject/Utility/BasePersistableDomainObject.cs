using System;
using Epy.Standard.Core.Args;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.DomainModel;

namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Classe per un Domain Object che supporta la persistenza.
    /// </summary>
    internal abstract class BasePersistableDomainObject<TWrappedObject, TDeleteArgs, TSaveArgs> : BaseDomainObject<TWrappedObject>
        where TWrappedObject : IObjectModel
        where TDeleteArgs : DeleteArgs
        where TSaveArgs : SaveArgs
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

        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="wrappedObject">oggetto da wrappare appartenente all'Object Model.</param>
        protected BasePersistableDomainObject(TWrappedObject wrappedObject)
            :
            base(wrappedObject)
        {

        }

        protected BasePersistableDomainObject()
        {

        }

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
        /// <summary>
        /// Ritorna <c>true</c> se l'istanza dell'entità è stata eliminata.
        /// </summary>
        /// <value>
        /// <c>true</c> se l'istanza dell'entità è stata eliminata, <c>false</c> altrimenti.
        /// </value>
        public virtual bool IsDeleted
        {
            get;
            protected set;
        }

        /// <summary>
        /// Data di creazione della Risorsa
        /// </summary>
        public new virtual DateTimeOffset? DateCreation
        {
            get
            {
                var objectModel = WrappedObject as IObjectModel;
                if (objectModel != null)
                    return objectModel.DateCreation;
                return null;
            }
        }

        #endregion
        #region NOT PUBLIC
        /// <summary>
        /// Ritorna true è possibile modificare proprietà dell'entità.
        /// </summary>
        /// <returns>true è possibile modificare proprietà dell'entità, solleva un'eccezione altrimenti.</returns>
        /// <exception cref="InvalidOperationException">non è possibile modificare le proprietà dell'entità.</exception>
        protected virtual bool CanBeUpdated
        {
            get
            {
                if (!IsDeleted)
                    return true;

                throw new InvalidOperationException("Non è possibile modificare l'entità");
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
        /// Verifica se l'istanza dell'entità può essere eliminata, 
        /// chiamando il metodo CanBeDeleted, e quindi 
        /// genera un messaggio di notifica per il client. 
        /// Inoltra ritorna true se l'istanza può essere eliminata, 
        /// false altrimenti. 
        /// </summary>
        /// <param name="msg">messaggio di notifica per il client</param>
        /// <param name="args">argomenti per l'eliminazione</param>
        /// <returns>true se è possibile procedere con l'eliminazione, false altrimenti.</returns>
        public virtual bool CanDelete(
            out ClientMessage msg,
            TDeleteArgs args = null
        )
        {
            return PerformActionAndReturnWithMessage(
                () => CanBeDeleted(args),
                out msg
            );
        }

        /// <summary>
        /// Verifica se l'istanza dell'entità può essere eliminata, 
        /// chiamando il metodo CanBeSaved, e quindi 
        /// genera un messaggio di notifica per il client. 
        /// Inoltra ritorna true se l'istanza può essere salvata, 
        /// false altrimenti. 
        /// </summary>
        /// <param name="msg">messaggio di notifica per il client</param>
        /// <param name="args">argomenti per il salvataggio</param>
        /// <returns>true se è possibile procedere con il salvataggio, false altrimenti.</returns>
        public virtual bool CanSave(
            out ClientMessage msg,
            TSaveArgs args = null
        )
        {
            return PerformActionAndReturnWithMessage(
                () => CanBeSaved(args),
                out msg
            );
        }
        #endregion

        #region NOT PUBLIC



        /// <summary>
        /// Ritorna true è possibile cancellare l'entità.
        /// </summary>
        /// <param name="args">argomenti per la cancellazione</param>
        /// <returns>true è possibile cancellare l'entità, solleva un'eccezione altrimenti.</returns>
        /// <exception cref="InvalidOperationException">non è possibile cancellare l'entità.</exception>
        protected virtual ClientMessage CanBeDeleted(TDeleteArgs args = null)
        {
            ClientMessage msg = new();
            if (!IsDeleted && Id > 0)
                return msg;

            throw msg.BuildException(LayerExceptions.CoreDomainObject, "TemplateManager.DomainObject.BasePersistableDomainObject", "Non è possibile cancellare l'entità");
        }

        /// <summary>
        /// Ritorna true è possibile salvare l'entità.
        /// </summary>
        /// <param name="args">argomenti per il salvataggio</param>
        /// <returns>true è possibile salvare l'entità, solleva un'eccezione altrimenti.</returns>
        /// <exception cref="InvalidOperationException">non è possibile salvare l'entità.</exception>
        protected virtual ClientMessage CanBeSaved(TSaveArgs args = null)
        {
            ClientMessage msg = new();

            if (!IsDeleted)
                return msg;

            throw msg.BuildException(LayerExceptions.CoreDomainObject, "TemplateManager.DomainObject.BasePersistableDomainObject", "Non è possibile salvare l'entità");
        }
        #endregion

        #endregion

        #endregion

    }
}
