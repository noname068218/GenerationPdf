using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TemplateManager.Common;
using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;
using TemplateManager.UI;
using TemplateManager.UI.ModelView;

namespace TemplateManager.UI.DomainService
{
    /// <summary>
    /// Implementazione a livello Domain Object dell'entità <c>DayOfWeek</c>.
    /// </summary>
    internal class TemplateService : ITemplateService
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        #region PUBLIC

        /// <summary>
        /// Salva un'istanza dell'entità. 
        /// </summary>
        /// <param name="input">istanza dell'entità./param>
        /// <param name="tokenAccess"> tokenAccess di validazione</param>
        /// <returns></returns>
        public FeedBackOperation SaveAsync(TemplateApi input, string tokenAccess)
        {
                 FeedBackOperation feed = new();
                try
                {
                    var settings = new JsonSerializerSettings
                    {
                        DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                    };

                    string wsUrl = ExtensionMethodsUI.LoadUrlRestApi(BaseUrlRestApi.Anagraphic, ObjectModelName.Template, ActionOperationName.SaveAsync);
                    string inputJson = JsonConvert.SerializeObject(input, settings);

                    var _response = ExtensionMethodsUI.PostAPIKeyAuthentication(wsUrl, inputJson, tokenAccess);

                    if (!string.IsNullOrWhiteSpace(_response))
                    {
                        var outputresponseJson = JsonConvert.DeserializeObject<FeedBackOperation>(_response, settings);

                        return outputresponseJson;
                    }
                    else
                        feed.Feedback.StatusCode = StatusCodesApi.Error;
                }
                catch (Exception ex)
                {
                    feed.Feedback.StatusCode = StatusCodesApi.Error;
                
                    if (feed.Feedback.EVLogApi == null)
                        feed.Feedback.EVLogApi = new EVLogApi();

                    feed.Feedback.EVLogApi.MessageErrore = ex.Message;

                    if (ex.InnerException!=null)
                    feed.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                }

                return feed;
        }


        /// <summary>
        /// Ritorna un'istanza dell'entità <see cref="TemplateApi" /> in base all'<paramref name="id" /> e
        /// agli argomenti specificati in <paramref name="args" />.
        /// </summary>
        /// <param name="id">id relativo al <see cref="TemplateApi" /></param>
        /// <returns>
        /// Istanza dell'entità <see cref="OutputTemplateApi" />; null se non esiste alcun TemplateQuantity con l'<paramref name="id"/> specificato.
        /// </returns>
        /// <exception cref="System.ArgumentException">se <paramref name="id"/> minore o uguale a 0.</exception>
        public OutputTemplateApi GetByIdAsync(int id, string tokenAccess)
        {
            OutputTemplateApi outputApi = new();
            try
            {
                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

                string wsUrl = ExtensionMethodsUI.LoadUrlRestApi(BaseUrlRestApi.Anagraphic, ObjectModelName.Template, ActionOperationName.GetByIdAsync);
                string wsUrlInput = $"{wsUrl}?id={id}";

                var _response = ExtensionMethodsUI.GetAPIKeyAuthentication(wsUrlInput, tokenAccess);

                if (!string.IsNullOrWhiteSpace(_response))
                    outputApi = JsonConvert.DeserializeObject<OutputTemplateApi>(_response, settings);

            }
            catch (Exception ex)
            {
                outputApi.Feedback.StatusCode = StatusCodesApi.Error;

                if (outputApi.Feedback.EVLogApi == null)
                    outputApi.Feedback.EVLogApi = new EVLogApi();

                outputApi.Feedback.EVLogApi.MessageErrore = ex.Message;

                if (ex.InnerException != null)
                    outputApi.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }

            return outputApi;
        }


        /// <summary>
        /// Elimina un'istanza dell'entità <see cref="TemplateApi"/> in base all'<paramref name="id"/>.
        /// </summary>
        /// <param name="id">id di un'istanza dell'entità <see cref="TemplateApi"/></param>
        /// <exception cref="System.ArgumentException"> se <paramref name="id"/> non valido</exception>
        public FeedBackOperation DeleteAsync(int id, string tokenAccess)
        {
            FeedBackOperation feed = new();

            try
            {
                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

                string wsUrl = ExtensionMethodsUI.LoadUrlRestApi(BaseUrlRestApi.Anagraphic, ObjectModelName.Template, ActionOperationName.DeleteAsync);
                string wsUrlInput = $"{wsUrl}?id={id}";

                var _response = ExtensionMethodsUI.DeleteAPIKeyAuthentication(wsUrlInput, tokenAccess);

                if (!string.IsNullOrWhiteSpace(_response))
                {
                    var outputresponseJson = JsonConvert.DeserializeObject<FeedBackOperation>(_response, settings);

                    return outputresponseJson;
                }
                else
                    feed.Feedback.StatusCode = StatusCodesApi.Error;
            }
            catch (Exception ex)
            {
                feed.Feedback.StatusCode = StatusCodesApi.Error;

                if (feed.Feedback.EVLogApi == null)
                    feed.Feedback.EVLogApi = new EVLogApi();

                feed.Feedback.EVLogApi.MessageErrore = ex.Message;

                if (ex.InnerException != null)
                    feed.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }

            return feed;
        }

        /// <summary>
        /// Ritorna una lista di istanze dell'entità <see cref="TemplateApi"/>.
        /// </summary>
        /// <returns>
        /// lista di istanze dell'entità <see cref="TemplateApi" />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">criteria</exception>
        public OutputTemplateApi LoadListAsync(TemplateApiSearchCriteria input, string tokenAccess)
        {
            OutputTemplateApi _output = new();
            try
            {
                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

                string wsUrl = ExtensionMethodsUI.LoadUrlRestApi(BaseUrlRestApi.Anagraphic, ObjectModelName.Template, ActionOperationName.LoadListAsync);
                string inputJson = JsonConvert.SerializeObject(input, settings);

                var _response = ExtensionMethodsUI.PostAPIKeyAuthentication(wsUrl, inputJson, tokenAccess);

                if (!string.IsNullOrWhiteSpace(_response))
                    _output = JsonConvert.DeserializeObject<OutputTemplateApi>(_response, settings);
            }
            catch (Exception ex)
            {
                _output.Feedback.StatusCode = StatusCodesApi.Error;

                if (_output.Feedback.EVLogApi == null)
                    _output.Feedback.EVLogApi = new EVLogApi();

                _output.Feedback.EVLogApi.MessageErrore = ex.Message;

                if (ex.InnerException != null)
                    _output.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
            }

            return _output;
        }




        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

    }
}
