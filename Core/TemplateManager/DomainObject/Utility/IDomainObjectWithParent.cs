using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.DomainObject
{
    /// <summary>
    /// Interfaccia che consente di specificare un parent di 
    /// un'istanza.
    /// </summary>
    interface IDomainObjectWithParent
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Ritorna o imposta il Parent dell'istanza.
        /// </summary>
        IDomainObjectParent Parent { get; set; }
        #endregion

        #region METHODS
        #endregion

    }
}
