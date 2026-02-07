using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Entità di implementazione <see cref="CodeVerifyEmail"/>
    /// </summary>
    /// 
    [DataContract(Name = "CodeVerifyEmail")]
    public class CodeVerifyEmail
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Ritorna o imposta la property EMail dell'entità (<see cref=CodeVerifyEmail/>)
        /// </summary>
        /// <value>
        /// della property <c>EMail</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? EMail { get; set; }

        /// <summary>
        /// Ritorna o imposta la property CodeVerify dell'entità (<see cref=CodeVerifyEmail/>)
        /// </summary>
        /// <value>
        /// della property <c>CodeVerify</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? CodeVerify { get; set; }

        #endregion

        #region METHODS

        #region PUBLIC

        #region METODI Members

        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

    }
}
