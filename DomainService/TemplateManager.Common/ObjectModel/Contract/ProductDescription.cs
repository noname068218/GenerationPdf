using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    public class ProductDescription
    {

        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC
        public ProductDescription()
        {

        }
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
        public Int32? PositionIndex { get; set; } = 1;


        /// <summary>
        /// Ritorna o imposta la property OrderIndex dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>OrderIndex</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? OrderIndex { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SoftwareName dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>SoftwareName</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? ProductName { get; set; }

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
        /// Ritorna o imposta la property Description dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Description</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Description { get; set; }


        #endregion

        #endregion

        #endregion

    }
}
