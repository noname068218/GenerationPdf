


namespace TemplateManager.Common.ObjectModel
{
    public class EmailAttachment
    {
        public required string FileName { get; init; }
        public required string ContentType { get; init; }
        public required byte[] Data { get; init; }
    }
}
