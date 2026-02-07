using TemplateManager.DAL.Application;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;


namespace TemplateManager.Application
{
    /// <summary>
    /// Classe base per le eccezioni utilizzate nel core.
    /// </summary>
    public class TemplateManagerException : CoreAppException<LayerExceptions>
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
        /// <param name="eVLog"></param>
        public TemplateManagerException(EVLog eVLog ) : base(eVLog)
        {

        }

/// <summary>
/// 
/// </summary>
/// <param name="msg"></param>
/// <param name="eVLog"></param>
public TemplateManagerException(LayerExceptions errorCode, string msg, Type myClassType) : base((int)errorCode, errorCode.ToString(), msg, myClassType)
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

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

    }
}
