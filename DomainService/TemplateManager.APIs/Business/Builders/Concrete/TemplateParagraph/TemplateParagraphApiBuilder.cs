
using TemplateManager.APIs.Application;
using TemplateManager.APIs.Business.Builders.Contracts.TemplateParagraph;
using TemplateManager.Common;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DomainObject;
using TemplateManager.APIs.Constants;

namespace TemplateManager.APIs.Business.Builders.Concrete.TemplateParagraph
{
    /// <summary>
    /// Implementazione concreta del builder per TemplateParagraph.
    /// Gestisce costruzione e validazione di istanze TemplateParagraph.
    /// </summary>
    internal class TemplateParagraphApiBuilder : ITemplateParagraphApiBuilder
    {
        #region FIELDS

        private ITemplateParagraphApiValidator m_ValidatorOutput =
            DomainServiceAPIs.GetValidatorsFactory().GetTemplateParagraphApiValidator();

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
        /// </summary>
        /// <param name="input"></param>
        /// <param name="args"></param>
        /// <returns> <see cref="BaseApiFeedback"/></returns>
        public BaseApiFeedback Build(ref ITemplateParagraph output, TemplateParagraphApiBuilderArgs args)
        {
            BaseApiFeedback feed = new();

            if (m_ValidatorOutput.Validate(ref output, ref feed, new TemplateParagraphApiValidatorArgs(args.TemplateParagraph)))
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
    }
}
