
using System;
using System.Runtime.Serialization;

namespace TemplateManager.Common.Arguments
{
    /// <summary>
    /// Argomenti relativi all'operazione di search per l'entità Template.
    /// Le diverse informazioni di dettaglio disponibili per Template
    /// sono definite in Template.
    /// </summary>
    /// 
    [DataContract(Namespace = "")]
    public class TemplateApiSearchCriteria 
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Ritorna o imposta la property Id dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Id</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
         public Int32? Id { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Code dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Code</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
         public Int32? Code { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Name dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Name</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
         public String? Name { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
         public String? AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Description dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Description</c> .
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
