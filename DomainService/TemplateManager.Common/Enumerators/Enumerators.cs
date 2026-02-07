
namespace TemplateManager.Common
{

    /// <summary>
    /// Enum per indicare lo stato dell'operazione / possibilità di eseguire l'operazione.
    /// </summary>
    public enum StatusCodesApi
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

}
