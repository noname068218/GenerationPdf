
using TemplateManager.APIs.Constants.Business.Mapping;
using TemplateManager.Application;
using TemplateManager.Common;
using TemplateManager.Common.Arguments;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.DomainService
{

    internal abstract class BaseServiceTemplate : BaseServiceExtension
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        #region PUBLIC

        #region METODI Members

        /// <summary>
        /// Inserimento dell'entità <see cref="ITemplate"/>
        /// </summary>
        /// <param name="input">istanza dell'entità.</param>
        /// <param name="feed">istanza dell'entità.<see cref="BaseApiFeedback"/> </param>
        internal static ITemplate Save(ITemplate item, out BaseApiFeedback feed)
        {
            feed = new BaseApiFeedback
            {
                StatusCode = StatusCodesApi.Success
            };
            try
            {
                if (item.CanSave(out ClientMessage msg))
                    item = item.SaveFromGateway(out msg);
                else
                {
                    if (msg.EventLog == null)
                        throw msg.Exception;

                    feed.EVLogApi = msg.EventLog.TOEVLogApi();
                    feed.StatusCode = msg.Stato.TOStatusCodesApi();
                }

                return item;
            }
            catch (Exception ex)
            {
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;

                return null;
            }
        }

        /// <summary>
        /// Inserimento dell'entità <see cref="ITemplate"/>
        /// </summary>
        /// <param name="input">istanza dell'entità.</param>
        /// <param name="feed">istanza dell'entità.<see cref="BaseApiFeedback"/> </param>
        internal static ITemplate Inset(TemplateApi input, out BaseApiFeedback feed)
        {
            feed = new BaseApiFeedback
            {
                StatusCode = StatusCodesApi.Success
            };
            try
            {
                ITemplate item = input.Map();

                if (item.CanSave(out ClientMessage msg))
                    item = item.SaveFromGateway(out msg);
                else
                {
                    if (msg.EventLog == null)
                        throw msg.Exception;

                    feed.EVLogApi = msg.EventLog.TOEVLogApi();
                    feed.StatusCode = msg.Stato.TOStatusCodesApi();
                }

                return item;
            }
            catch (Exception ex)
            {
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;

                return null;
            }
        }

        /// <summary>
        /// Aggiorna dell'entità <see cref="ITemplate"/>
        /// </summary>
        /// <param name="input">istanza dell'entità.</param>
        /// <param name="feed">istanza dell'entità.<see cref="BaseApiFeedback"/> </param>
        internal static ITemplate Update(TemplateApi input, out BaseApiFeedback feed)
        {
            feed = new BaseApiFeedback();
            try
            {
                ClientMessage msg = null;

                ITemplate item = DomainServiceLocator.GetTemplateService().GetById(input.Id.Value);
                if (item == null)
                {
                    feed.EVLogApi.MessageErrore = "Item not found";
                    feed.StatusCode = StatusCodesApi.NotFound;
                }
                else
                {
                    item = input.Map(item);

                    if (item.CanSave(out msg))
                        item = item.SaveFromGateway(out msg);
                    else
                    {
                        if (msg.EventLog == null)
                            throw msg.Exception;

                        feed.EVLogApi = msg.EventLog.TOEVLogApi();
                        feed.StatusCode = msg.Stato.TOStatusCodesApi();
                    }
                }

                return item;
            }
            catch (Exception ex)
            {
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;

                return null;
            }
        }


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id e alle viste specificate negli <c>args</c>.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="feed"></param>
        /// <returns></returns>
        internal static TemplateApi GetById(int Id, out BaseApiFeedback feed)
        {
            feed = new BaseApiFeedback();
            try
            {
                ITemplate item = DomainServiceLocator.GetTemplateService().GetByIdFromGateway(Id);

                if (item == null)
                {
                    feed.EVLogApi.MessageErrore = "Item not found";
                    feed.StatusCode = StatusCodesApi.NotFound;
                }

                return item.Map();
            }
            catch (Exception ex)
            {
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;

                return null;
            }
        }

        /// <summary>
        /// Elimina un'istanza dell'entità in base all'id e alle viste specificate negli <c>args</c>.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="feed"></param>
        /// <returns></returns>
        internal static BaseApiFeedback Delete(int Id)
        {
            BaseApiFeedback feed = new();
            try
            {
                ITemplate item = DomainServiceLocator.GetTemplateService().GetByIdFromGateway(Id);

                if (item != null)
                    item.DeleteFromGateway();
                else
                {
                    feed.EVLogApi.MessageErrore = "Item not found";
                    feed.StatusCode = StatusCodesApi.NotFound;
                }

            }
            catch (Exception ex)
            {
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;
            }
            return feed;
        }


        /// <summary>
        /// Recupera un'insieme di istanze dell'entità considerata in base ai criteri di ricerca definiti negli <c>args</c>.
        /// </summary>
        /// <param name="searchCriteria">argomenti che descrivono l'operazione di search sulle istanze dell'entità</param>
        /// <param name="tokenAccess">tokenAccess di validazione</param>
        /// <returns></returns>
        internal static List<TemplateApi> Search(TemplateApiSearchCriteria searchCriteria, out BaseApiFeedback feed)
        {
            feed = new BaseApiFeedback();
            try
            {
                TemplateSearchCriteria _innersearch = searchCriteria.Map();
                var items = DomainServiceLocator.GetTemplateService().SearchFromGateway(_innersearch);

                if (items == null)
                {
                    feed.EVLogApi.MessageErrore = "Item not found";
                    feed.StatusCode = StatusCodesApi.NotFound;
                }
                return items.Map();
            }
            catch (Exception ex)
            {
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;

                return null;
            }
        }

        #endregion

        #endregion

        #region NOT PUBLIC


        #endregion

        #endregion

    }
}
