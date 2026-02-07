using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Business
{
    /// <summary>
    /// Interfaccia per una generica regola di validazione.
    /// </summary>
    /// <typeparam name="TInput">Elemento da validare.</typeparam>
    /// <typeparam name="TValidationArgs">Argomenti a supporto della validazione.</typeparam>
    public interface IValidationRule<TInput,TValidationArgs>
        where TValidationArgs : IValidationRuleArgs
    {
        /// <summary>
        /// Valida l'item fornito rispetto alla regola definita nel metodo. 
        /// </summary>
        /// <param name="input">elemento da validare.</param>
        /// <param name="args">argomenti per la validazione.</param>
        /// <returns><c>true</c> se l'item è valido, false altrimenti.</returns>
        bool Validate(TInput input,TValidationArgs args = default);
    }
}
