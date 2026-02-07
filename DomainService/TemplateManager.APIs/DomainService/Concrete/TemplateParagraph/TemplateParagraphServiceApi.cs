
using TemplateManager.APIs.Application;
using TemplateManager.APIs.Business.Builders.Contracts.TemplateParagraph;
using TemplateManager.APIs.Constants;
using TemplateManager.APIs.Constants.Business.Mapping;
using TemplateManager.Application;
using TemplateManager.Common;
using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.DomainService
{
    /// <summary>
    /// Implementazione a livello Domain Object dell'entità <c>DayOfWeek</c>.
    /// </summary>
    internal class TemplateParagraphServiceApi : BaseServiceTemplateParagraph, ITemplateParagraphServiceApi
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES
        private ITemplateParagraphApiBuilder ServiceBuilder { get => DomainServiceAPIs.GetBuilderFactory().GetTemplateParagraphApiBuilder(); }
        #endregion

        #region METHODS

        #region PUBLIC

        /// <summary>
        /// Salva un'istanza dell'entità. 
        /// </summary>
        /// <param name="input">istanza dell'entità.<see cref="ITemplateParagraph"/>/param> 
        /// <param name="tokenAccess"> tokenAccess di validazione</param>
        /// <returns><see cref="FeedBackOperation"/></returns>
        public async Task<FeedBackOperation> SaveAsync(TemplateParagraphApi input, string tokenAccess = null)
        {
            var outup = new FeedBackOperation
            {
                Feedback = new BaseApiFeedback()
            };
            await Task.Run(() =>
            {
                try
                {
                    ITemplateParagraph item = DomainServiceLocator.GetTemplateParagraphService().NewTemplateParagraph();
                    outup.Feedback = ServiceBuilder.Build(ref item, new TemplateParagraphApiBuilderArgs(input));

                    if (outup.Feedback.StatusCode == StatusCodesApi.Success)
                    {
                        BaseApiFeedback feed;
                        item = input.Map(item);
                        item = Save(item, out feed);

                        if (feed.StatusCode == StatusCodesApi.Success)
                            outup.Id = item.Id;

                        outup.Feedback = feed;
                    }

                }
                catch (Exception ex)
                {
                    outup.Feedback.EVLogApi.MessageErrore = ex.Message;
                    if (ex.InnerException != null) outup.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                    outup.Feedback.StatusCode = StatusCodesApi.Error;
                }
            });

            return outup;
        }

        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id.
        /// </summary>
        /// <param name="Id">Id identificativo associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di save sull'istanza dell'entità.</param>
        /// <param name="tokenAccess"> tokenAccess di validazione</param>
        /// <returns></returns>
        public async Task<OutputTemplateParagraphApi> GetByIdAsync(int Id, TemplateParagraphApiSelectArgs args, string tokenAccess = null)
        {
            var outup = new OutputTemplateParagraphApi
            {
                Feedback = new BaseApiFeedback()
            };

            await Task.Run(() =>
            {
                try
                {
                    TemplateParagraphApi item = new();
                    item = GetById(Id, out BaseApiFeedback feed);

                    outup.Feedback = feed;

                    if (item != null)
                        outup.ListTemplateParagraph.Add(item);
                }
                catch (Exception ex)
                {
                    outup.Feedback.EVLogApi.MessageErrore = ex.Message;
                    if (ex.InnerException != null) outup.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                    outup.Feedback.StatusCode = StatusCodesApi.Error;
                }
            });

            return outup;
        }

        /// <summary>
        /// Elimina un'istanza dell'entità. 
        /// </summary>
        /// <param name="Id">Id identificativo associato all'entità</param>
        /// <param name="tokenAccess">tokenAccess di validazione</param>
        /// <returns> entita feedback Operation</returns>
        public async Task<FeedBackOperation> DeleteAsync(int Id, string tokenAccess = null)
        {
            var outup = new FeedBackOperation
            {
                Feedback = new BaseApiFeedback()
            };

            await Task.Run(() =>
            {
                try
                {
                    outup.Feedback = Delete(Id);
                }
                catch (Exception ex)
                {
                    outup.Feedback.EVLogApi.MessageErrore = ex.Message;
                    if (ex.InnerException != null) outup.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                    outup.Feedback.StatusCode = StatusCodesApi.Error;
                }
            });

            return outup;
        }


        /// <summary>
        /// Recupera un'insieme di istanze dell'entità considerata in base ai criteri di ricerca definiti negli <c>args</c>.
        /// </summary>
        /// <param name="searchCriteria">argomenti che descrivono l'operazione di search sulle istanze dell'entità</param>
        /// <param name="tokenAccess">tokenAccess di validazione</param>
        /// <returns></returns>
        public async Task<OutputTemplateParagraphApi> LoadListAsync(TemplateParagraphApiSearchCriteria searchCriteria, string tokenAccess = null)
        {
            var outup = new OutputTemplateParagraphApi
            {
                Feedback = new BaseApiFeedback()
            };

            await Task.Run(() =>
            {
                try
                {
                    outup.ListTemplateParagraph = Search(searchCriteria, out BaseApiFeedback feed);
                    outup.Feedback = feed;
                }
                catch (Exception ex)
                {
                    outup.Feedback.EVLogApi.MessageErrore = ex.Message;
                    if (ex.InnerException != null) outup.Feedback.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                    outup.Feedback.StatusCode = StatusCodesApi.Error;
                }
            });

            return outup;
        }

        #region METODI Members

        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

    }
}
