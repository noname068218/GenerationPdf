using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.DAL
{
    #region MyRegion

    #endregion

    #region View

        #region Template 

        /// <summary>
        /// View relative all'entità <see cref= TemplateManager.DAL.DomainModel.ITemplateObjectModel/>.
        /// </summary>
        /// <returns> Le view relative all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateObjectModel/>).</returns>
        public enum TemplateView
         {
           /// <summary>
           /// View Anagrafica
           /// <summary>
           ViewAnagrafica = 1

         }

        #endregion

        #region TemplateParagraph 

        /// <summary>
        /// View relative all'entità <see cref= TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel/>.
        /// </summary>
        /// <returns> Le view relative all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel/>).</returns>
        public enum TemplateParagraphView
         {
           /// <summary>
           /// View Anagrafica
           /// <summary>
           ViewAnagrafica = 1

         }

        #endregion



       #region Log
    /// <summary>
    /// LoggingLevel
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// Error
        /// </summary>
        Error,
        /// <summary>
        /// Information
        /// </summary>
        Information,
        /// <summary>
        /// Warning
        /// </summary>
        Warning
    }

    /// <summary>
    /// LoggerType
    /// </summary>
    public enum LoggerType
    {
        /// <summary>
        /// Core
        /// </summary>
        Core = 1
    }
    #endregion

    #endregion

}
