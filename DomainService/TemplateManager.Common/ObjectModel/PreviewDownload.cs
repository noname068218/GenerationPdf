using System;
using System.Runtime.Serialization;
namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Entità di implementazione <see cref="InputGeneratePdf"/>
    /// </summary>
    /// 
    [DataContract(Name = "InputGeneratePdf")]
    public class PreviewDownload
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC



        /// <summary>
        /// Ritorna o imposta la property AdministrativeBlock dell'entità <c>CodeTelematicApi</c>
        /// </summary>
        ///  /// Ritorna o imposta la property VATNumber dell'entità <c>CodeTelematicApi</c>
        /// </summary>
        /// <value>
        /// della property <c>VATNumber</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public String? Url { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AdministrativeBlock dell'entità <c>CodeTelematicApi</c>
        /// </summary>
        ///  /// Ritorna o imposta la property VATNumber dell'entità <c>CodeTelematicApi</c>
        /// </summary>
        /// <value>
        /// della property <c>VATNumber</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public String? FileName { get; set; }

        #endregion
        #endregion

        #endregion
    }
}
