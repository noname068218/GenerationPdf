using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.Services
{
    public interface ICachedTemplateParagraphService
    {
        Task<OutputTemplateParagraphApi> LoadListAsync(TemplateParagraphApiSearchCriteria criteria);
    }
}
