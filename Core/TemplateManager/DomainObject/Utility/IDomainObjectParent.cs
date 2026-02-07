using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Interfaccia impiegata per la validazione Master/Slave.
    /// </summary>
    interface IDomainObjectParent
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Property sottoposta a CAS, invocata da un metodo set di un figli. 
        /// Consente di vincolare la possibilità di editare il figlio 
        /// solo se l'utente corrente ha i permessi per editare il padre.
        /// </summary>
        bool CanUpdateChild { get; }
        #endregion

        #region METHODS
        #endregion

    }
}
