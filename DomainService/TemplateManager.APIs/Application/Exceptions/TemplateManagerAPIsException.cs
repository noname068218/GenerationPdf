using TemplateManager.Business;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DAL.Application;
using System;
using System.Runtime.Serialization;

namespace TemplateManager.APIs.Exceptions
{
    /// <summary>
    /// Classe base per le eccezioni utilizzate nel core.
    /// </summary>
    public  class TemplateManagerAPIsException : CoreAppException<ValidationException>
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
        /// 
        /// </summary>
        /// <param name="EVLogApi"></param>
        public TemplateManagerAPIsException(EVLogApi EVLogApi) : base(EVLogApi.TOEVLog())
        {

        }

/// <summary>
/// 
/// </summary>
/// <param name="msg"></param>
/// <param name="EVLogApi"></param>
public TemplateManagerAPIsException(ValidationException errorCode, string msg, Type myClassType) : base((int)errorCode, errorCode.ToString(), msg, myClassType)
        {

        }
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
        public override void GetObjectData(
        SerializationInfo info, StreamingContext Context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
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
