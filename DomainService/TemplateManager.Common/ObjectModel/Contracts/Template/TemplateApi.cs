using System;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Entità di implementazione <see cref="TemplateApi"/>
    /// </summary>
    /// 
    [DataContract(Name = "TemplateApi")]
    public class TemplateApi: BaseModelApi
    {

    #region FIELDS

    #endregion

    #region CONSTRUCTORS

    #endregion

    #region PROPERTIES

        /// <summary>
        /// Ritorna o imposta la property Code dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>Code</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? Code { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Name dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>Name</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Name { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Description dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>Description</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Description { get; set; }




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
