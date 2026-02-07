
namespace TemplateManager.UI
{

    /// <summary>
    /// 
    /// </summary>
    public enum ObjectModelName
    {
        LicenseManager,
        UserManager,
        Template,
        ManageGeneratePdf,
        TemplateParagraph
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ActionOperationName
    {
        SaveAsync,
        DeleteAsync,
        GetByIdAsync,
        LoadListAsync,
        SearchAsync,
        EnableJobAsync,
        SendMasterLicenseAsync,
        ResendMasterLicenseAsync,
        ActivateNewBrandNameAsync,
        ChangeCompanyNameAsync,
        SendTemporalyLicenseAsync,
        ResendTemporalyLicenseAsync,
        PasswordTemporaryAsync,
        CodeVerifyEmailAsync,
        SendPdfByEmailAsync,
        GenerateFileOfferAsync,
        DownloadFileOfferAsync,
    }

    public enum BaseUrlRestApi
    {
        Anagraphic
    }
    /// <summary>
    /// Enum per indicare lo stato dell'operazione / possibilità di eseguire l'operazione.
    /// </summary>
    public enum FeedbackStatus
    {
        Null,
        /// <summary>
        /// Enum per indicare lo stato Success
        /// </summary>
        Success,

        /// <summary>
        /// Enum per indicare lo stato Fail
        /// </summary>
        Error,

        /// <summary>
        /// Enum per indicare lo stato CannotBeExecute
        /// </summary>
        Warning,

        /// <summary>
        /// Enum per indicare che un'entità è stata eliminata
        /// </summary>
        Deleted,

        /// <summary>
        /// Enum per indicare che un'entità è stata ripristinata dall'eliminazione.
        /// </summary>
        Restored,

        /// <summary>
        /// Enum per indicare che un'entità è stata trovata a seguito di una ricerca.
        /// </summary>
        NotFound
    }

}
