using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel.Contract
{
    public class TableAssetOfOffer
    {


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
        /// Ritorna o imposta la property Module dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Module</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String Module { get; set; } = "";


        /// <summary>
        /// Ritorna o imposta la property Price dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Price</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? Price { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Quantity dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Quantity</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? Quantity { get; set; }



        /// <summary>
        /// Ritorna o imposta la property Cannon dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Cannon</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? Cannon { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TotalPrice dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>TotalPrice</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? TotalPrice { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TotalCannon dell'entità (<see cref=AssetLicenseApi/>)
        /// </summary>
        /// <value>
        /// della property <c>TotalCannon</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? TotalCannon { get; set; }


    }
}
