using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    [DataContract()]
    public class UrlTemplate
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
        /// Ritorna o imposta la property Id dell'entità <c>OutputDelete</c>
        /// </summary>
        /// <value>
        /// della property <c>Clients</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public int? Code { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Id dell'entità <c>OutputDelete</c>
        /// </summary>
        /// <value>
        /// della property <c>Clients</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public String? Url { get; set; }

        #endregion
        #endregion

        #endregion
    }
}
