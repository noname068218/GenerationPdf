
using TemplateManager.APIs.Application;
using TemplateManager.APIs.Business.Validators.Contracts.Template;
using TemplateManager.Common;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DomainObject;
using TemplateManager.APIs.Constants;

namespace TemplateManager.APIs.Business.Builders.Concrete.Template
{
    internal class TemplateApiBuilder : ITemplateApiBuilder
    {
        #region DYNAMIC

        #region EVENTS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region FIELDS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        private ITemplateApiValidator m_ValidatorOutput = DomainServiceAPIs.GetValidatorsFactory().GetTemplateApiValidator();
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC

        /// <summary>
        /// Data un'istanza di Confirm esegue le operazioni necessarie al suo corretto salvataggio
        /// </summary>ч
        /// <param name="input"></param>
        /// <param name="args"></param>
        /// <returns> <see cref="BaseApiFeedback"/></returns>
        public BaseApiFeedback Build(ref ITemplate output, TemplateApiBuilderArgs args)
        {
            BaseApiFeedback feed = new();

            if (m_ValidatorOutput.Validate(ref output, ref feed, new TemplateApiValidatorArgs(args.Template)))
            {
                try
                {

                }
                catch (Exception ex)
                {
                    feed.EVLogApi.MessageErrore = ex.Message;
                    if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                    feed.StatusCode = StatusCodesApi.Error;
                }
            }

            return feed;
        }
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion

    }
}
