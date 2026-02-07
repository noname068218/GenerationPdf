namespace Middleware.APIsRest
{
    internal static class PathAPIsRestToBeTrace
    {
        internal static List<String> PathToBeTrace
        {
            get => new() {
                "/ServiceApi/V1.0/ManageGeneratePdf/SendPdfByEmailAsync",
                "/ServiceApi/V1.0/ManageGeneratePdf/GenerateFileOfferAsync",
                "/ServiceApi/V1.0/ManageGeneratePdf/DownloadFileOfferAsync",
                "/ServiceApi/V1.0/Template/SaveAsync",
                "/ServiceApi/V1.0/Template/GetByIdAsync",
                "/ServiceApi/V1.0/Template/DeleteAsync",
             };
        }
    }
}
