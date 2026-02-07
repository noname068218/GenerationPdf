using Microsoft.AspNetCore.Mvc;
using TemplateManager.APIs.Application;
using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;
using System.Threading.Tasks;

namespace TemplateManager.APIsRest.Controllers
{
    [Route("ServiceApi/V1.0/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        /// <summary>
        /// Funzione da richiamare per effettuare il salvataggio di un entità <see cref="TemplateApi"/>. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>un'entita di tipo <see cref="FeedBackOperation"/> /></returns>
        [HttpPost]
        [Route("SaveAsync")]
        public async Task<FeedBackOperation> SaveAsync([FromBody] TemplateApi input)
        {
            return await DomainServiceAPIs.GetTemplateServiceApi().SaveAsync(input);
        }

        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id dell'entita <see cref="TemplateApi"/>.
        /// </summary>
        /// <param name="id">Id numerico associato all'entità</param>
        /// <returns>Istanza dell'entità in base all'id e alle viste specificate</returns>
        [HttpGet]
        [Route("GetByIdAsync")]
        public async Task<OutputTemplateApi> GetByIdAsync(int id)
        {
            return await DomainServiceAPIs.GetTemplateServiceApi().GetByIdAsync(id,new TemplateApiSelectArgs());
        }

        /// <summary>
        /// Elimina un'istanza dell'entità <see cref="TemplateApi"/>. 
        /// </summary>
        /// <param name="id">Id numerico associato all'entità PlatformApi </param>
        [HttpDelete]
        [Route("DeleteAsync")]
        public async Task<FeedBackOperation> DeleteAsync(int id)
        {
            return await DomainServiceAPIs.GetTemplateServiceApi().DeleteAsync(id);
        }


        /// <summary>
        /// Ritorna tutte le istanze dell'entità con le proprietà valorizzate specificate in<c>LoadList</c>.
        /// </summary>
        /// <param name="input"> Entità di tipo <see cref="TemplateApiSearchCriteria"/></param>
        /// <returns>Tutte le istanze dell'entità con le proprietà valorizzate specificate</returns>
        [HttpPost]
        [Route("LoadListAsync")]
        public async Task<OutputTemplateApi> LoadListAsync([FromBody] TemplateApiSearchCriteria searchCriteria)
        {
            return await DomainServiceAPIs.GetTemplateServiceApi().LoadListAsync(searchCriteria);
        }
    }
}
