using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TemplateManager.Common.ObjectModel
{
    [DataContract()]
    public class BaseHours
    {

        #region DYNAMIC

        #region PROPERTIES
        #region PUBLIC

        /// <summary>
        /// Ritorna o imposta la property Hours dell'entità
        /// </summary>
        /// <value>
        /// della property <c>Hours</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public int Hours { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Minutes dell'entità
        /// </summary>
        /// <value>
        /// della property <c>Minutes</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public int Minutes { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Seconds dell'entità
        /// </summary>
        /// <value>
        /// della property <c>Seconds</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public int Seconds { get; set; }

        /// <summary>
        /// Ritorna o imposta la property Milliseconds dell'entità
        /// </summary>
        /// <value>
        /// della property <c>Milliseconds</c> .
        /// </value>
        [DataMember(IsRequired = false)]
        public int Milliseconds { get; set; }
        #endregion
        #endregion

        #endregion

    }
}
