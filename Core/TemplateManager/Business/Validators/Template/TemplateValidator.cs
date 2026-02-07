using Epy.Standard.Core.Common;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;
using System;
namespace TemplateManager.Business
{
    internal class TemplateValidator : ITemplateValidator
    {
        /// <summary>
        /// Valida un'istanza dell'entità <c>Template</c>.
        /// </summary>
        /// <param name="Template">istanza dell'entità <see cref="ITemplate"/>.</param>
        /// <param name="args">argomenti aggiuntivi per la validazione.</param>
        public bool Validate(ITemplate input, TemplateValidatorArgs args = null)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

        //if (input.Name.IsNullOrEmptyOrWhiteSpace())
        //    throw new TemplateManagerValidationException(ValidationException.MissingRequiredField,
        //        "Il campo Nome è obbligatorio per l'entità Template",
        //        typeof(TemplateValidator));


        #region Duplicato 

            var items = ServiceLocator.GetGatewayFactory().GetTemplateGateway().Search(new TemplateSearchCriteria()
            {

            });

            var isExist = items != null && items.Any(c => (c.Id != input.Id));

            if (isExist)
                throw new TemplateManagerValidationException(ValidationException.DuplicateEntity,
                    $"L'entità {nameof(Template)} con {nameof(input.Id)} {input.Id} e esiste già.",
                    typeof(TemplateValidator));

        #endregion

        return true;
        }
    }
}
