using TemplateManager.Application;
using TemplateManager.DAL.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Messaggio di notifica da inviare al client per comunicare l'esito 
    /// di un'operazione o la possibilità di eseguirla. 
    /// </summary>
    public class ClientMessage
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

        public ClientMessage()
        {
            Stato = StatusCodes.Success;
            Success = true;
        }

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna o imposta lo stato dell'operazione / la possibilità di eseguire l'operazione.
        /// </summary>
        public StatusCodes Stato { get; internal set; }

        /// <summary>
        /// Ritorna o imposta lo stato dell'operazione / la possibilità di eseguire l'operazione.
        /// </summary>
        public bool Success { get; internal set; }


        /// <summary>
        /// Ritorna o imposta l'eccezione relativa allo stato dell'operazione / la possibilità di eseguire l'operazione.
        /// </summary>
        public Exception Exception { get; internal set; }

        /// <summary>
        /// Ritorna o imposta un entità di tipo <see cref="EVLog"/>
        /// </summary>
        public EVLog EventLog { get; internal set; }

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
        /// <summary>
        /// Genera un'eccezione a partire dal messaggio.
        /// </summary>
        /// <returns>Exception se diversa da null; <see cref="System.InvalidOperationException"/> altrimenti.</returns>
        public Exception BuildException(EVLog log)
        {
            Exception = new Exception(log.MessageErrore);

            return new InvalidOperationException(log.MessageErrore);

        }

        /// <summary>
        /// Genera un'eccezione a partire dal messaggio.
        /// </summary>
        /// <returns>Exception se diversa da null; <see cref="System.InvalidOperationException"/> altrimenti.</returns>
        public Exception BuildException(LayerExceptions lLayerExcep, string nameSpaceLayerExceptions, string msgError = null)
        {

            EVLog log = this.EventLog ?? new EVLog { CodeError = (int)lLayerExcep, NameSpaceClassError = nameSpaceLayerExceptions, MessageErrore = msgError };

            Exception = new Exception(log.MessageErrore);

            if (this.Exception != null)
                return this.Exception;
            else
                return new InvalidOperationException(log.MessageErrore);
        }


        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
