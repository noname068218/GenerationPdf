using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.DomainService
{
    public interface IOfferTemplateServiceApi
    {
        Task<OutputOfferTemplateApi> GenerateAsync(OfferContract input);
    }
}
