using TemplateManager.DAL.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Business
{
   public class TemplateManagerValidationException : CoreAppException<ValidationException>
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
        /// <summary>
        /// Crea una nuova eccezione di tipo <c>TemplateManagerValidationException</c>.
        /// </summary>
        /// <param name="code">codice d'errore: ogni tipo di eccezione deve avere un codice d'errore univoco a livello di core.</param>
        /// <param name="msg">messaggio d'errore</param>
        /// <param name="ctx">contesto all'interno del quale è avvenuta l'eccezione</param>
        public TemplateManagerValidationException(ValidationException code, string msg,Type myclassType) :
            base((int)code, code.ToString(), msg, myclassType)
        {

        }


        /// <summary>
        /// Crea una nuova eccezione di tipo <c>TemplateManagerValidationException</c>.
        /// </summary>
        /// <param name="code">codice d'errore: ogni tipo di eccezione deve avere un codice d'errore univoco a livello di core.</param>
        /// <param name="msg">messaggio d'errore</param>
        /// <param name="ctx">contesto all'interno del quale è avvenuta l'eccezione</param>
        /// <param name="innerException"></param>
        public TemplateManagerValidationException(ValidationException code, string msg,Type myclassType, CoreAppExceptionContext ctx, Exception innerException) :
            base((int)code, code.ToString(), msg, myclassType, ctx, innerException)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eVLog"></param>
        public TemplateManagerValidationException(EVLog eVLog) : base(eVLog)
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
