using System;

namespace TemplateManager.APIs.DomainService
{
    /// <summary>
    /// Classe di utilità per l'analisi e la gestione delle condizioni di pagamento.
    /// Contiene metodi per la scomposizione delle stringhe delle condizioni di pagamento e la sostituzione dei segnaposto.
    /// </summary>
    public static class ParsePayment
    {
        /// <summary>
        /// Sostituisce il segnaposto {{DoubleTimeOffer}} in modo sequenziale (nell'ordine di apparizione).
        /// La prima occorrenza viene sostituita con beforePart, la seconda e le successive con afterPart.
        /// Questo permette di usare il segnaposto {{DoubleTimeOffer}} più volte nel template del DB.
        /// 
        /// ALGORITMO DI FUNZIONAMENTO:
        /// 1. Si cerca la prima occorrenza di {{DoubleTimeOffer}} nel testo
        /// 2. La si sostituisce con beforePart (la prima parte prima di "/")
        /// 3. Si cerca la prossima occorrenza di {{DoubleTimeOffer}} dopo la precedente
        /// 4. La si sostituisce con afterPart (la seconda parte dopo "/")
        /// 5. Ripetere per tutte le occorrenze successive (tutte sostituite con afterPart)
        /// </summary>
        /// <param name="html">Contenuto HTML con segnaposti {{DoubleTimeOffer}}</param>
        /// <param name="beforePart">Valore con cui sostituire la prima occorrenza (prima della "/")</param>
        /// <param name="afterPart">Valore con cui sostituire la seconda e le successive occorrenze (dopola "/")</param>
        /// <returns>HTML con i segnaposto {{DoubleTimeOffer}} sostituiti sequenzialmente</returns>
        public static string ReplaceDoubleTimeOfferSequentially(string html, string beforePart, string afterPart)
        {
            const string placeholder = "{{DoubleTimeOffer}}";
            var result = html;
            var searchIndex = 0;
            var occurrenceNumber = 0;


            while (true)
            {

                var placeholderIndex = result.IndexOf(placeholder, searchIndex, StringComparison.OrdinalIgnoreCase);


                if (placeholderIndex == -1)
                    break;

                var replacement = occurrenceNumber == 0 ? beforePart : afterPart;


                result = result.Remove(placeholderIndex, placeholder.Length);


                result = result.Insert(placeholderIndex, replacement);


                searchIndex = placeholderIndex + replacement.Length;

                occurrenceNumber++;
            }

            return result;
        }

        /// <summary>
        /// Analizza la stringa delle condizioni di pagamento ed estrae le parti "prima" e "dopo" formattate in HTML.
        /// Se la stringa contiene "/" - viene divisa in due parti, ognuna formattata col tag &lt;strong&gt;.
        /// Se non c'è il carattere "/", si usa lo stesso valore per entrambe le parti (formattato sempre col tag &lt;strong&gt;).    
        /// </summary>
        /// <param name="paymentConditions">Stringa delle condizioni di pagamento dal modello (ad esempio, "B.B. 25% ORD/75% 30 GG D.F.F.M.")</param>
        /// <returns>Tupla che contiene le parti "prima" e "dopo" formattate</returns>
        public static (string beforePart, string afterPart) ParsePaymentConditions(string? paymentConditions)
        {

            const string defaultFormatted = "";


            if (string.IsNullOrWhiteSpace(paymentConditions))
            {
                return (defaultFormatted, defaultFormatted);
            }


            var trimmed = paymentConditions.Trim();


            if (!trimmed.Contains('/'))
            {

                var formatted = $"<strong style=\"color:#1e3a5f;\">{trimmed}</strong>";
                return (formatted, formatted);
            }


            var parts = trimmed.Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);


            if (parts.Length == 0)
            {
                return (defaultFormatted, defaultFormatted);
            }


            var beforePart = parts[0].Trim();
            var formattedBefore = $"<strong style=\"color:#1e3a5f;\">{beforePart}</strong>";


            if (parts.Length > 1)
            {

                var afterPart = parts[1].Trim();
                var formattedAfter = $"<strong style=\"color:#1e3a5f;\">{afterPart}</strong>";
                return (formattedBefore, formattedAfter);
            }


            return (formattedBefore, defaultFormatted);
        }
    }
}
