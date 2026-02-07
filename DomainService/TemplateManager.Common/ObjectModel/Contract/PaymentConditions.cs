using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    public class PaymentConditions
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
        /// Ritorna o imposta la property PositionIndex dell'entità (<see cref=TemplateManager.Common/>)
        /// </summary>
        /// <value>
        /// della property <c>PositionIndex</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? PositionIndex { get; set; } = 7;


        /// <summary>
        /// Ritorna o imposta la property Title dell'entità (<see cref=TemplateApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Title</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Title { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Definition dell'entità (<see cref=TemplateApi/>)
        /// </summary>
        /// <value>
        /// della property <c>Definition</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Definition { get; set; }

        /// <summary>
        /// Ritorna o imposta la property DoubleTimeOffer dell'entità (<see cref=TemplateApi/>)
        /// </summary>
        /// <value>
        /// della property <c>DoubleTimeOffer</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? DoubleTimeOffer { get; set; }

        /// <summary>
        /// Ritorna o imposta la property SingleTimeOffer dell'entità (<see cref=TemplateApi/>)
        /// </summary>
        /// <value>
        /// della property <c>SingleTimeOffer</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? SingleTimeOffer { get; set; }

        /// <summary>
        /// Ritorna o imposta la property FooterDate dell'entità (<see cref=TemplateApi/>)
        /// </summary>
        /// <value>
        /// della property <c>FooterDate</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? FooterDate { get; set; }
        #endregion

        #endregion
        #endregion

    }
}
