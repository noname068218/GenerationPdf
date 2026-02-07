using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Messaggio di notifica da inviare al client per comunicare l'esito 
    /// di un'operazione o la possibilità di eseguirla. 
    /// </summary>
    ///
    [DataContract(Namespace = "", Name = "UrlTemplateManager")]
    public class UrlTemplateManager
    {
        #region DYNAMIC

        #region CONSTRUCTORS
        #region PUBLIC

        public UrlTemplateManager()
        {
            ManagerUrlTemplate = [];
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
        public List<UrlTemplate> ManagerUrlTemplate { get; set; }


        #endregion
        #endregion

        #endregion
    }
}
