using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    public class EVLogApi
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
        public EVLogApi()
        {
        }

        #endregion
        #region NOT PUBLIC
        #endregion

        #endregion

        #region PROPERTIES
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        #endregion

        /// <summary>
        /// Ritorna o imposta il codice di errore della sottoCategoria 
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        public int CodeError { get; set; }

        /// <summary>
        /// Ritorna o imposta il NameSpaceClassError di errore della sottoCategoria 
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        public string NameSpaceClassError { get; set; }

        /// <summary>
        /// Ritorna o imposta il messaggio di errore della sottocategoria
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        public String MessageErrore { get; set; }

        /// <summary>
        /// Ritorna o imposta il Inner messaggio di errore della sottocategoria
        /// </summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        public String InnerMessageErrore { get; set; }
        

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
