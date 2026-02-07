using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Factory per l'object model.
    /// </summary>
    public class UserOperation
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


        #endregion

        #endregion

        #region CONSTRUCTORS

        #region PUBLIC

        #endregion

        #region NOT PUBLIC
        #endregion

        #endregion

        #region PROPERTIES

        #region PUBLIC
        #endregion

        #region NOT PUBLIC
        /// <summary>
        /// Ritorna o imposta l'utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        public int IdUserAction { get; set; }


        /// <summary>
        /// Ritorna o imposta l'utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        public String UserNameAction { get; set; }
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
