using System;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Messaggio di notifica da inviare al client per comunicare l'esito 
    /// di un'operazione o la possibilità di eseguirla. 
    /// </summary>
    ///
    [DataContract(Namespace = "",Name = "Feedback")]
    public class BaseApiFeedback
    {

        #region DYNAMIC

        #region EVENTS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region FIELDS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        StatusCodesApi _StatusCode;
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC

        #endregion
        #region NOT PUBLIC
        public BaseApiFeedback()
        {
            EVLogApi = new EVLogApi();
            StatusCode = StatusCodesApi.Success;
        }
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna o imposta lo StatusCode dell'operazione / la possibilità di eseguire l'operazione.
        /// </summary>
        /// 
        [DataMember(IsRequired = true)]
        public StatusCodesApi StatusCode { 
            get {return _StatusCode;}
            set {
                _StatusCode = value;
                Status = value.ToString();
            } }

        /// <summary>
        /// Ritorna o imposta lo stato dell'operazione / la possibilità di eseguire l'operazione.
        /// </summary>
        /// 
        [DataMember(IsRequired = true)]
        public String Status { get; set; }



        /// <summary>
        /// Ritorna o imposta i messaggi per il MessaggiErrore che comunica 
        /// l'esito / la possibilità di eseguire l'operazione.
        /// </summary>
        /// 
        [DataMember(IsRequired = false)]
        public EVLogApi EVLogApi { get; set; }



        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion
    }
}
