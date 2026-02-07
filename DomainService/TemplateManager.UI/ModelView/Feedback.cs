using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.UI.ModelView
{
    /// <summary>
    /// Messaggio di notifica da inviare al client per comunicare l'esito 
    /// di un'operazione o la possibilità di eseguirla. 
    /// </summary>
    public class Feedback
    {

        #region STATIC

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
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
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
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        public Feedback()
        {
            Stato = FeedbackStatus.Null;
            MessaggioList = new List<string>();
        }
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC
        /// <summary>
        /// Ritorna o imposta lo stato dell'operazione / la possibilità di eseguire l'operazione.
        /// </summary>
        public FeedbackStatus Stato { get; set; }

        public List<string> MessaggioList { get; set; }

        /// <summary>
        /// Ritorna o imposta l'eccezione relativa allo stato dell'operazione / la possibilità di eseguire l'operazione.
        /// </summary>
        public Exception Exception { get; set; }
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
