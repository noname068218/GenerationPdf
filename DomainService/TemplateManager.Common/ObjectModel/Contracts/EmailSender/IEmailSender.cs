using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Common.ObjectModel
{
    public interface IEmailSender
    {
       Task<(int? IdEmail, BaseApiFeedback Feedback)> SendAsync(
       string to, string subject, string bodyHtml,
       IEnumerable<string>? cc,
       IEnumerable<string>? bcc,
       IEnumerable<EmailAttachment> attachments,
       CancellationToken ct = default);
    }
}
