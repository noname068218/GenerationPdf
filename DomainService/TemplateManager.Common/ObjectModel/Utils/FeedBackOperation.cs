using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    [DataContract()]
    public class FeedBackOperation
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC

        public FeedBackOperation()
        {
            Feedback = new BaseApiFeedback();
        }

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC



        /// <summary>
        /// Ritorna o imposta la property Status dell'entità <c>OutputDelete</c>
        /// </summary>
        /// <value>
        /// della property <c>Status</c> .
        /// </value>

        [DataMember(IsRequired = true)]
        public BaseApiFeedback Feedback { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Id dell'entità <c>OutputDelete</c>
        /// </summary>
        /// <value>
        /// della property <c>Clients</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public int? Id { get; set; }


        #endregion
        #endregion

        #endregion
    }
}
