using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common.ObjectModel.Contract;

namespace TemplateManager.Common.ObjectModel
{
    public class AssetOfOfferCosts
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
        /// Ritorna o imposta la property OrderIndex dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>OrderIndex</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? PositionIndex { get; set; } = 4;


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Title { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TableAssetOfOffer dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>TableAssetOfOffer</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public List<TableAssetOfOffer>? TableAssetOfOffer { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Year dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>Year</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? Year { get; set; }



        /// <summary>
        /// Ritorna o imposta la property DiscountTitle dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>DiscountTitle</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public string? DiscountTitle { get; set; }


        /// <summary>
        /// Ritorna o imposta la property TotalPriceScount dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>TotalPriceScount</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? TotalPriceScount { get; set; }


        /// <summary>
        /// Ritorna o imposta la property TotalCannonScount dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>TotalCannonScount</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? TotalCannonScount { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TotalListPrice  dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>TotalListPrice </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? TotalListPrice { get; set; }

        /// <summary>
        /// Ritorna o imposta la property DiscountedListPrice  dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>DiscountedListPrice </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? DiscountedListPrice { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TotalAnnualFee   dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>TotalAnnualFee  </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? TotalAnnualFee { get; set; }

        /// <summary>
        /// Ritorna o imposta la property DiscountOnAnnualFee   dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>DiscountOnAnnualFee  </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Decimal? DiscountOnAnnualFee { get; set; }

        /// <summary>
        /// Ritorna o imposta la property ListPriceDiscountPercentage   dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>ListPriceDiscountPercentage  </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? ListPriceDiscountPercentage { get; set; }

        /// <summary>
        /// Ritorna o imposta la property AnnualFeeDiscountPercentage   dell'entità (<see cref=AssetOfOfferCosts/>)
        /// </summary>
        /// <value>
        /// della property <c>AnnualFeeDiscountPercentage  </c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? AnnualFeeDiscountPercentage { get; set; }

        #endregion

        #endregion

        #endregion

    }
}
