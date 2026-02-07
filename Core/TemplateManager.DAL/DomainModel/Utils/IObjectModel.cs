using System;

namespace TemplateManager.DAL.DomainModel
{
    /// <summary>
    /// Interfaccia generica per la descrizione dell'Object Model
    /// </summary>
    public interface IObjectModel 
    {
        /// <summary>
        /// Ritorna l'Id.
        /// </summary>
        /// <value>
        /// Id.
        /// </value>
        int Id { get; }

        /// <summary>
        /// Ritorna un valore che indica se l'istanza è nuovo.
        /// </summary>
        /// <value>
        ///   <c>true</c> se l'istanza è nuovo; <c>false</c> altrimenti.
        /// </value>
        bool IsNew { get; }

        /// <summary>
        /// Ritorna la data di creazione dell'<c>Entità</c>.
        /// </summary>
        DateTimeOffset? DateCreation { get; }

        /// <summary>
        /// Ritorna la data di modifica dell'<c>Entità</c>.
        /// </summary>
        DateTimeOffset? DateChange { get; }

    }
}
