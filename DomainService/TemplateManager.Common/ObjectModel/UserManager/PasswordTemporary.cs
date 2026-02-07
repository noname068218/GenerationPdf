using System.Runtime.Serialization;


namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Entità di implementazione <see cref="PasswordTemporary"/>
    /// </summary>
    /// 
    [DataContract(Name = "PasswordTemporary")]
    public class PasswordTemporary
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Ritorna o imposta la property EMail dell'entità (<see cref=PasswordTemporary/>)
        /// </summary>
        /// <value>
        /// della property <c>EMail</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? EMail { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Password dell'entità (<see cref=PasswordTemporary/>)
        /// </summary>
        /// <value>
        /// della property <c>Password</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Password { get; set; }

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
