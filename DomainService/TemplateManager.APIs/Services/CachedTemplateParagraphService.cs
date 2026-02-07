using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.APIs.DomainService;
using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.Services
{
    /// <summary>
    /// Wrapper con cache per TemplateParagraphServiceApi.
    /// Riduce query al database per testi statici che cambiano raramente.
    /// </summary>
    public class CachedTemplateParagraphService : ICachedTemplateParagraphService
    {
        #region FIELDS
        private readonly ITemplateParagraphServiceApi _innerService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CachedTemplateParagraphService> _logger;

        // Cache duration: 1 ora (i template cambiano raramente)
        private static readonly TimeSpan CacheDuration = TimeSpan.FromHours(1);

        #endregion

        #region CONSTRUCTORS

        public CachedTemplateParagraphService(
       ITemplateParagraphServiceApi innerService,
       IMemoryCache cache,
       ILogger<CachedTemplateParagraphService> logger)
        {
            _innerService = innerService;
            _cache = cache;
            _logger = logger;
        }

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        #region PUBLIC

        #region LoadListAsync

        public async Task<OutputTemplateParagraphApi> LoadListAsync(TemplateParagraphApiSearchCriteria criteria)
        {
            // Genera una chiave di cache  basata sui criteri di ricerca
            var cacheKey = $"template_paragraph_{criteria.CodeTemplate}_{criteria.AlphaCode}_{criteria.NameOfTemplate}";

            // Prova a recuperare da cache
            if (_cache.TryGetValue<OutputTemplateParagraphApi>(cacheKey, out var cachedResult))
            {
                _logger.LogDebug("Template trovato in cache: {CacheKey}", cacheKey);
                return cachedResult!;
            }

            // Se non in cache, carica da DB
            _logger.LogDebug("Template non in cache, caricamento da DB: {CacheKey}", cacheKey);
            var result = await _innerService.LoadListAsync(criteria);

            // Salva in cache se la query ha successo
            if (result?.ListTemplateParagraph?.Any() == true)
            {
                _cache.Set(cacheKey, result, CacheDuration);
            }

            return result;
        }

        #endregion

        #region METODI Members

        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion
    }
}
