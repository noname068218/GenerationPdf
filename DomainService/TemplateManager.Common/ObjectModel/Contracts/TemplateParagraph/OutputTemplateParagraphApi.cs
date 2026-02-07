using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    [DataContract(Name = "OutputTemplateParagraphApi")]
    public class OutputTemplateParagraphApi
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC

        public OutputTemplateParagraphApi()
        {
            Feedback = new BaseApiFeedback();
            ListTemplateParagraph = new List<TemplateParagraphApi>();
        }

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC



        /// <summary>
        /// Ritorna o imposta la property Feedback dell'entità <c>OutputTemplateParagraphApi</c>
        /// </summary>
        /// <value>
        /// della property <c>BaseApiFeedback</c> .
        /// </value>

        [DataMember(IsRequired = true)]
        public BaseApiFeedback Feedback { get; set; }

        /// <summary>
        /// Ritorna o imposta la property TemplateParagraphApi dell'entità <c>OutputTemplateParagraphApi</c>
        /// </summary>
        /// <value>
        /// della property <c>TemplateParagraphApi</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public List<TemplateParagraphApi> ListTemplateParagraph { get; set; }


        #endregion
        #endregion

        #endregion
    }
}
