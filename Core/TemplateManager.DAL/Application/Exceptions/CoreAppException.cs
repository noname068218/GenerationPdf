using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using TemplateManager.DAL.Application;

namespace TemplateManager.DAL.Application
{
    /// <summary>
    /// Classe base per le eccezioni utilizzate nel core.
    /// </summary>
    [Serializable]
    public abstract class CoreAppException<TExceptionEnum> : Exception
        where TExceptionEnum : struct, IConvertible
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
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC

        /// <summary>
        /// Crea una nuova eccezione di tipo <c>BillingCoreException</c>.
        /// </summary>
        /// <param name="errorCode">codice d'errore: ogni tipo di eccezione deve avere un codice d'errore univoco a livello di core.</param>
        /// <param name="msg"></param>
        /// <param name="ctx">contesto all'interno del quale è avvenuta l'eccezione</param>
        protected CoreAppException(Int32 errorCode, String errorCodeName, string msg, Type myType)
            : base(msg)
        {
            this.ErrorCodeName = errorCodeName;
            this.ErrorCode = errorCode;
            this.EVLog = new EVLog { CodeError = this.ErrorCode, MessageErrore = msg, NameSpaceClassError = myType.Namespace };
        }



        /// <summary>
        /// Crea una nuova eccezione di tipo <c>EBillingCoreException</c>.
        /// </summary>
        /// <param name="errorCode">codice d'errore: ogni tipo di eccezione deve avere un codice d'errore univoco a livello di core.</param>
        /// <param name="msg"></param>
        /// <param name="ctx">contesto all'interno del quale è avvenuta l'eccezione</param>
        protected CoreAppException(EVLog eVLog)
            : base(null)
        {
            this.EVLog = eVLog;
        }

        /// <summary>
        /// Crea una nuova eccezione di tipo <c>BillingCoreException</c>.
        /// </summary>
        /// <param name="errorCode">codice d'errore: ogni tipo di eccezione deve avere un codice d'errore univoco a livello di core.</param>
        /// <param name="msg"></param>
        /// <param name="ctx">contesto all'interno del quale è avvenuta l'eccezione</param>
        protected CoreAppException(Int32 errorCode, String errorCodeName, string msg, Type myType, CoreAppExceptionContext ctx)
            : base(msg)
        {
            this.ErrorCodeName = errorCodeName;
            this.ErrorCode = errorCode;
            this.EVLog = new EVLog { CodeError = this.ErrorCode, MessageErrore = msg, NameSpaceClassError = myType.Namespace };
        }

        /// <summary>
        /// Crea una nuova eccezione di tipo <c>EBillingCoreException</c>.
        /// </summary>
        /// <param name="errorCode">codice d'errore: ogni tipo di eccezione deve avere un codice d'errore univoco a livello di core.</param>
        /// <param name="msg"></param>
        /// <param name="ctx">contesto all'interno del quale è avvenuta l'eccezione</param>
        /// <param name="innerException"></param>
        protected CoreAppException(Int32 errorCode, String errorCodeName, string msg, Type myType, CoreAppExceptionContext ctx, Exception innerException)
            : base(msg, innerException)
        {
            this.ErrorCodeName = errorCodeName;
            this.ErrorCode = errorCode;
            this.EVLog = new EVLog { CodeError = this.ErrorCode, MessageErrore = msg, NameSpaceClassError = myType.Namespace, Exception = innerException };
        }


        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna il codice d'errore associato all'eccezione. 
        /// </summary>
        public String ErrorCodeName { get; set; }

        /// <summary>
        /// Ritorna il codice d'errore associato all'eccezione. 
        /// </summary>
        public int ErrorCode { get; set; }


        /// <summary>
        /// Ritorna il contesto in cui si è verifica l'eccezione.
        /// </summary>
        /// <value>
        /// Contesto in cui si è verifica l'eccezione.
        /// </value>
        public CoreAppExceptionContext Context
        {
            get;
            private set;
        }
        /// <summary>
        /// Ritorna il contesto in cui si è verifica l'eccezione.
        /// </summary>
        /// <value>
        /// Contesto in cui si è verifica l'eccezione.
        /// </value>
        public EVLog EVLog
        {
            get;
            set;
        }

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
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="Context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains Contextual information about the source or destination.</param>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        ///   </PermissionSet>
        /// <exception cref="System.ArgumentNullException">info</exception>
        //[SecurityPermission(SecurityAction.LinkDemand,
        //    Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(
        SerializationInfo info, StreamingContext Context)
        {
            if (info == null)
                throw new System.ArgumentNullException(nameof(info));
            info.AddValue("ErrorCode", this.ErrorCode.ToString());
            info.AddValue("Message", this.Message);

            base.GetObjectData(info, Context);
        }
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
