using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    [DataContract(Name = "OutputTemplateApi")]
    public class OutputTemplateApi
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC

        public OutputTemplateApi()
        {
            Feedback = new BaseApiFeedback();
            ListTemplate = new List<TemplateApi>();
        }

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC



        /// <summary>
        /// Ritorna o imposta la property Feedback dell'entità <c>OutputTemplateApi</c>
        /// </summary>
        /// <value>
        /// della property <c>BaseApiFeedback</c> .
        /// </value>

        [DataMember(IsRequired = true)]
        public BaseApiFeedback Feedback { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TemplateApi dell'entità <c>OutputTemplateApi</c>
        /// </summary>
        /// <value>
        /// della property <c>TemplateApi</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public List<TemplateApi> ListTemplate { get; set; }


        #endregion
        #endregion

        #endregion
    }
}
