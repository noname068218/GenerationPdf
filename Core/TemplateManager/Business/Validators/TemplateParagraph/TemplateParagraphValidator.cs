using Epy.Standard.Core.Common;
using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DomainObject;
using System;
namespace TemplateManager.Business
{
    internal class TemplateParagraphValidator : ITemplateParagraphValidator
    {
        /// <summary>
        /// Valida un'istanza dell'entità <c>TemplateParagraph</c>.
        /// </summary>
        /// <param name="TemplateParagraph">istanza dell'entità <see cref="ITemplateParagraph"/>.</param>
        /// <param name="args">argomenti aggiuntivi per la validazione.</param>
        public bool Validate(ITemplateParagraph input, TemplateParagraphValidatorArgs args = null)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

        //if (input.Name.IsNullOrEmptyOrWhiteSpace())
        //    throw new TemplateManagerValidationException(ValidationException.MissingRequiredField,
        //        "Il campo Nome è obbligatorio per l'entità TemplateParagraph",
        //        typeof(TemplateParagraphValidator));


        #region Duplicato 

            var items = ServiceLocator.GetGatewayFactory().GetTemplateParagraphGateway().Search(new TemplateParagraphSearchCriteria()
            {
                Id = input.Id,
                CodeTemplate = input.CodeTemplate,
                AlphaCode = input.AlphaCode,
                PositionIndex = input.PositionIndex
               

            });

            var isExist = items != null && items.Any(c => (c.Id != input.Id));

            if (isExist)
                throw new TemplateManagerValidationException(ValidationException.DuplicateEntity,
                    $"L'entità {nameof(TemplateParagraph)} con {nameof(input.Id)} {input.Id} e esiste già.",
                    typeof(TemplateParagraphValidator));

        #endregion

        return true;
        }
    }
}
