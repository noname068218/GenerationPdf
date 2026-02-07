using TemplateManager.Business;

namespace TemplateManager.APIs.Constants.Business.Validators
{
    /// <summary>
    /// Interfaccia per una generica regola di validazione.
    /// </summary>
    /// <typeparam name="TInput">Elemento da validare.</typeparam>
    /// <typeparam name="TValidationArgs">Argomenti a supporto della validazione.</typeparam>
    internal interface IValidationRule<TInput, TFeedback, TValidationArgs>
        where TValidationArgs : IValidationRuleArgs
    {
        /// <summary>
        /// Valida l'item fornito rispetto alla regola definita nel metodo. 
        /// </summary>
        /// <param name="input">elemento da validare.</param>
        /// <param name="args">argomenti per la validazione.</param>
        /// <returns><c>true</c> se l'item è valido, false altrimenti.</returns>
        bool Validate(ref TInput input, ref TFeedback feed, TValidationArgs args);
    }
}
