
namespace TemplateManager.UI
{


    /// <summary>
    /// Nome delle entita esposte
    /// </summary>
    internal static class ObjectModelOperation
    {
        public const string LicenseManager = "LicenseManager";
        public const string UserManager = "UserManager";
        public const string Template = "Template";
        public const string TemplateParagraph = "TemplateParagraph";
        public const string ManageGeneratePdf = "ManageGeneratePdf";
    }

    internal static class BaseUrlRestApiService
    {
        /// <summary>
        /// 
        /// </summary>
        public const string GetServiceApi = "";
    }

    /// <summary>
    /// Nome delle operazioni eseguibile per entita
    /// </summary>
    internal static class OperationName
    {

        public const string SendMasterLicenseAsync = "SendMasterLicenseAsync";
        public const string ResendMasterLicenseAsync = "ResendMasterLicenseAsync";
        public const string ActivateNewBrandNameAsync = "ActivateNewBrandNameAsync";
        public const string ChangeCompanyNameAsync = "ChangeCompanyNameAsync";
        public const string SendTemporalyLicenseAsync = "SendTemporalyLicenseAsync";
        public const string ResendTemporalyLicenseAsync = "ResendTemporalyLicenseAsync";
        public const string PasswordTemporaryAsync = "PasswordTemporaryAsync";
        public const string CodeVerifyEmailAsync = "CodeVerifyEmailAsync";
        public const string SendPdfByEmailAsync = "SendPdfByEmailAsync";
        public const string GenerateFileOfferAsync = "GenerateFileOfferAsync";
        public const string DownloadFileOfferAsync = "DownloadFileOfferAsync";

    }

}
