using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.DomainObject
{

    /// <summary>
    /// Enum per indicare lo stato dell'operazione / possibilità di eseguire l'operazione.
    /// </summary>
    public enum StatusCodes
    {
        /// <summary>
        /// Enum per indicare lo stato Success
        /// </summary>
        Success = 200,

        /// <summary>
        /// Enum per indicare lo stato CannotBeExecute
        /// </summary>
        Warning = 202,

        /// <summary>
        /// Enum per indicare lo stato Error
        /// </summary>
        Error = 400,

        CannotNotBeExecute = 406,
        /// <summary>
        /// Enum per indicare lo stato NotFound
        /// </summary>
        NotFound = 404,
    }

    ///// <summary>
    ///// Enum per indicare lo stato dell'operazione / possibilità di eseguire l'operazione.
    ///// </summary>
    //public enum ClientMessageStatus
    //{
    //    /// <summary>
    //    /// Enum per indicare lo stato Success
    //    /// </summary>
    //    Success,

    //    /// <summary>
    //    /// Enum per indicare lo stato Fail
    //    /// </summary>
    //    /// 
    //    Fail,

    //    /// <summary>
    //    /// Enum per indicare lo stato CanBeExecuted
    //    /// </summary>
    //    CanBeExecuted,

    //    /// <summary>
    //    /// Enum per indicare lo stato CannotBeExecute
    //    /// </summary>
    //    CannotBeExecute,

    //    /// <summary>
    //    /// Enum per indicare lo stato Expired
    //    /// </summary>
    //    Expired
    //}
}
