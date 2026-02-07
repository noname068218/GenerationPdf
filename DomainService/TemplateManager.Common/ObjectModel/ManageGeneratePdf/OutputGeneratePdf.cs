using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Entità di implementazione <see cref="ActivateNewBrandName"/>
    /// </summary>
    /// 
    [DataContract(Name = "OutputGeneratePdf")]
    public class OutputGeneratePdf
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC

        public OutputGeneratePdf()
        {
            PdfData = [];
            Successfully = false;
        }

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna o imposta la property Status dell'entità <c>Feedback</c>
        /// </summary>
        /// <value>
        /// della property <c>Status</c> .
        /// </value>

        [DataMember(IsRequired = true)]
        public BaseApiFeedback Feedback { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Successfully dell'entità <c>Successfully</c>
        /// </summary>
        /// <value>
        /// della property <c>AdministrativeBlock</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public Byte[]? PdfData { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Successfully dell'entità <c>Successfully</c>
        /// </summary>
        /// <value>
        /// della property <c>AdministrativeBlock</c> .
        /// </value>
        [DataMember(IsRequired = true)]
        public bool Successfully { get; set; }

        #endregion
        #endregion

        #endregion
    }
}
