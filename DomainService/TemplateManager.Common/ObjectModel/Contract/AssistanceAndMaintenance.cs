using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    public class AssistanceAndMaintenance
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
        /// Ritorna o imposta la property OrderIndex dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>OrderIndex</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? PositionIndex { get; set; } = 3;


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Title { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SoftwareName dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>SoftwareName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Definition { get; set; }

        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? AlphaCode { get; set; }

        #endregion

        #endregion

        #endregion

    }
}
