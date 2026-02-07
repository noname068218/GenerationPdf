
using TemplateManager.APIs.Business.Validators.Contracts.Template;
using TemplateManager.APIs.Constants;
using TemplateManager.APIs.Exceptions;
using TemplateManager.Application;
using TemplateManager.Business;
using TemplateManager.Common;
using TemplateManager.Common.ObjectModel;
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;

namespace TemplateManager.APIs.Business.Validators.Concrete.Template
{
    internal class TemplateApiValidator : ITemplateApiValidator
    {
        #region DYNAMIC

        #region METHODS
        #region PUBLIC

        /// <summary>
        /// Valida un'istanza dell'entità <c>Template</c>.
        /// </summary>
        /// <param name="input"><see cref="OutputTemplateApi"/></param>
        /// <param name="feed"><see cref="BaseApiFeedback"/></param>
        /// <param name="args"><see cref="TemplateValidatorApiArgs"/></param>
        /// <returns></returns>
        public bool Validate(ref ITemplate output, ref BaseApiFeedback feed, TemplateApiValidatorArgs args)
        {
            feed = new BaseApiFeedback();
            try
            {
                TemplateApi input = args.Template;

                ValidatorInput(input);
                ValidatorTemplateDuplicated(input, out ITemplate? itemOutPut);

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
        private static void ValidatorInput(TemplateApi input)
        {
            if (input == null)
                throw new TemplateManagerAPIsException(ValidationException.ArgumentIsNullOrEmpty,
                    "l'entità di input TemplateApi è null",
                    typeof(TemplateApiValidator));

            //if (input.Name.IsNullOrEmptyOrWhiteSpace())
            //    throw new TemplateManagerAPIsException(ValidationException.MissingRequiredField,
            //                       "é obbligatorio valorizzare il campo Name",
            //                       typeof(TemplateApiValidator));


        }

        private void ValidatorTemplateDuplicated(TemplateApi input, out ITemplate? itemOutPut)
        {

            IEnumerable<ITemplate>? listItem = DomainServiceLocator.GetTemplateService()
                .SearchFromGateway(new TemplateSearchCriteria()
                {
                    Id = input.Id,
                });

            bool IsExist = listItem != null && listItem.Count() > 1;

            if (IsExist)
                throw new TemplateManagerAPIsException(ValidationException.DuplicateEntity,
                    $"il Template esiste gia",
                    typeof(TemplateApiValidator));

            itemOutPut = listItem?.FirstOrDefault();
        }
        #endregion
        #endregion

        #endregion

    }
}
