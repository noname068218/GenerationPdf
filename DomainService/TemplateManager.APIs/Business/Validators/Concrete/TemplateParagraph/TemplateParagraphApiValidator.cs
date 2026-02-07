
using TemplateManager.APIs.Constants;
using TemplateManager.APIs.Exceptions;
using TemplateManager.Application;
using TemplateManager.Business;
using TemplateManager.Common;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.Business
{
    internal class TemplateParagraphApiValidator : ITemplateParagraphApiValidator
    {
        #region DYNAMIC

        #region METHODS
        #region PUBLIC

        /// <summary>
        /// Valida un'istanza dell'entità <c>TemplateParagraph</c>.
        /// </summary>
        /// <param name="input"><see cref="OutputTemplateParagraphApi"/></param>
        /// <param name="feed"><see cref="BaseApiFeedback"/></param>
        /// <param name="args"><see cref="TemplateParagraphValidatorApiArgs"/></param>
        /// <returns></returns>
        public bool Validate(ref ITemplateParagraph output, ref BaseApiFeedback feed, TemplateParagraphApiValidatorArgs args)
        {
            feed = new BaseApiFeedback();
            try
            {
                TemplateParagraphApi input = args.TemplateParagraph;

                ValidatorInput(input);
                ValidatorTemplateParagraphDuplicated(input, out ITemplateParagraph? itemOutPut);

                output = itemOutPut;
            }
            catch (TemplateManagerAPIsException ex)
            {
                if (ex.EVLog != null)
                {
                    feed.EVLogApi.CodeError = ex.EVLog.CodeError;
                    feed.EVLogApi.MessageErrore = ex.EVLog.MessageErrore;
                    feed.EVLogApi.InnerMessageErrore = ex.EVLog.InnerMessageErrore;
                    feed.StatusCode = StatusCodesApi.CannotNotBeExecute;
                }

            }
            catch (Exception ex)
            {
                feed.EVLogApi.MessageErrore = ex.Message;
                if (ex.InnerException != null) feed.EVLogApi.InnerMessageErrore = ex.InnerException.Message;
                feed.StatusCode = StatusCodesApi.Error;
            }

            return feed.StatusCode == StatusCodesApi.Success ? true : false;

        }

        #endregion
        #region NOT PUBLIC
        private static void ValidatorInput(TemplateParagraphApi input)
        {
            if (input == null)
                throw new TemplateManagerAPIsException(ValidationException.ArgumentIsNullOrEmpty,
                    "l'entità di input TemplateParagraphApi è null",
                    typeof(TemplateParagraphApiValidator));

            //if (input.Name.IsNullOrEmptyOrWhiteSpace())
            //    throw new TemplateManagerAPIsException(ValidationException.MissingRequiredField,
            //                       "é obbligatorio valorizzare il campo Name",
            //                       typeof(TemplateParagraphApiValidator));


        }

        private void ValidatorTemplateParagraphDuplicated(TemplateParagraphApi input, out ITemplateParagraph? itemOutPut)
        {

            IEnumerable<ITemplateParagraph>? listItem = DomainServiceLocator.GetTemplateParagraphService()
                .SearchFromGateway(new TemplateParagraphSearchCriteria()
                {
                    Id = input.Id,
                    CodeTemplate = input.CodeTemplate,
                    AlphaCode = input.AlphaCode,
                    PositionIndex = input.PositionIndex

                });

            bool IsExist = listItem != null && listItem.Count() > 1;

            if (IsExist)
                throw new TemplateManagerAPIsException(ValidationException.DuplicateEntity,
                    $"il TemplateParagraph esiste gia",
                    typeof(TemplateParagraphApiValidator));

            itemOutPut = listItem?.FirstOrDefault();
        }
        #endregion
        #endregion

        #endregion

    }
}
