
using FluentValidation;
using TemplateManager.Common.ObjectModel;

namespace TemplateManager.APIs.Constants
{
    /// <summary>
    /// Validator per OfferContract usando FluentValidation.
    /// Simile a Zod in TypeScript - garantisce che i dati siano corretti prima di generare PDF.
    /// </summary>
    public class OfferContractValidator : AbstractValidator<OfferContract>
    {
        public OfferContractValidator()
        {
            // CodeOffer - obbligatorio
            RuleFor(x => x.CodeOffer)
                .NotEmpty()
                .WithMessage("Il codice offerta è obbligatorio")
                .MaximumLength(50)
                .WithMessage("Il codice offerta non può superare 50 caratteri");

            // CompanyName - obbligatorio
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Il nome azienda è obbligatorio")
                .MaximumLength(200)
                .WithMessage("Il nome azienda non può superare 200 caratteri");

            // Customer - obbligatorio
            RuleFor(x => x.Customer)
                .NotEmpty()
                .WithMessage("Il nome cliente è obbligatorio")
                .MaximumLength(200)
                .WithMessage("Il nome cliente non può superare 200 caratteri");

            // Email - opzionale ma se presente deve essere valida
            When(x => !string.IsNullOrWhiteSpace(x.EmailCustomer), () =>
            {
                RuleFor(x => x.EmailCustomer)
                    .EmailAddress()
                    .WithMessage("Email non valida");
            });

            // DateOffer - obbligatorio e non futuro
            RuleFor(x => x.DateOffer)
                .NotNull()
                .WithMessage("La data offerta è obbligatoria")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("La data offerta non può essere nel futuro");

            // AlphaCode - obbligatorio e solo IT o EN
            RuleFor(x => x.AlphaCode)
                .NotEmpty()
                .WithMessage("Il codice lingua è obbligatorio")
                .Must(code => code == "IT" || code == "EN")
                .WithMessage("Il codice lingua deve essere IT o EN");

            // CodeTemplate - obbligatorio e positivo
            RuleFor(x => x.CodeTemplate)
                .NotNull()
                .WithMessage("Il codice template è obbligatorio")
                .GreaterThan(0)
                .WithMessage("Il codice template deve essere maggiore di 0");
        }
    }
}
