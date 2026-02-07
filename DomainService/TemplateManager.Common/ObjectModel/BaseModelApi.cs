
using System;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    [DataContract()]
   public class BaseModelApi
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

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
        /// <summary>
        /// Ritorna o imposta la property Id dell'entità <c>ActivityApi</c>
        /// </summary>
        /// <value>
        /// della property <c>Id</c> .
        /// </value>

        /// 
        [DataMember(IsRequired = false)]
        public int? Id { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TokenProvider dell'entità <c>CompanyServer</c>
        /// </summary>
        /// <value>
        /// della property <c>TokenProvider</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        /// 
        [DataMember(IsRequired = false)]
        public String TokenProvider { get; set; }
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
