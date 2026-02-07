
using Epy.Standard.Core.Args;
using TemplateManager.DAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// Interfaccia che descrive un repository per una generic entità.
    /// </summary>
    /// <typeparam name="TIDAO">Interfaccia dell'entità.</typeparam>
    /// <typeparam name="TDeleteArgs">Argomenti che descrivono l'operazione di delete su un'istanza dell'entità.</typeparam>
    /// <typeparam name="TSelectArgs">Argomenti che descrivono l'operazione di select su un'istanza dell'entità.</typeparam>
    /// <typeparam name="TSearchCriteria">Argomenti che descrivono l'operazione di search sulle istanze dell'entità.</typeparam>
    /// <typeparam name="TSaveArgs">Argomenti che descrivono l'operazione di save su un'istanza dell'entità.</typeparam>
    /// <typeparam name="TView">Tipo che descrive le viste associate all'entità.</typeparam>
    public interface IDAOGateway<TIDAO, TDeleteArgs, TSelectArgs, TSearchCriteria, TSaveArgs, TView>
        where TIDAO : IObjectModel
        where TDeleteArgs : DeleteArgs
        where TSelectArgs : SelectArgs<TView, TSelectArgs>
        where TSearchCriteria : SearchCriteria<TView>
        where TSaveArgs : SaveArgs
        where TView : struct, IConvertible
    {
        /// <summary>
        /// Salva un'istanza dell'entità. 
        /// </summary>
        /// <param name="item">istanza dell'entità.</param>
        /// <param name="args">argomenti che descrivono l'operazione di save sull'istanza dell'entità.</param>
        TIDAO Save(
            TIDAO item,
            TSaveArgs args = null
            );


        /// <summary>
        /// Recupera un'istanza dell'entità in base all'id e alle viste specificate negli <c>args</c>.
        /// </summary>
        /// <param name="id">Id numerico associato all'entità</param>
        /// <param name="args">argomenti che descrivono l'operazione di select su un'istanza dell'entità</param>
        TIDAO GetById(
            int id,
            TSelectArgs args = null
            );

        /// <summary>
        /// Elimina un'istanza dell'entità. 
        /// </summary>
        /// <param name="item">istanza dell'entità.</param>
        /// <param name="args">argomenti che descrivono l'operazione di delete sull'istanza dell'entità.</param>
        void Delete(
            TIDAO item,
            TDeleteArgs args = null
            );


        /// <summary>
        /// Recupera un'insieme di istanze dell'entità considerata in base ai criteri di ricerca definiti negli <c>args</c>.
        /// </summary>
        /// <param name="criteria">argomenti che descrivono l'operazione di search sulle istanze dell'entità</param>
        /// <returns>Insieme di instanze dell'entità considerata.</returns>
        IEnumerable<TIDAO> Search(
            TSearchCriteria criteria
            );


    }
}
