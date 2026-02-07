

using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;
using System;

namespace TemplateManager.DomainObject
{

    public interface ITemplate : ITemplateAdapter
    {

    #region EVENTS
    #endregion

    #region PROPERTIES

            /// <summary>
        /// Ritorna o imposta la property Code dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>Code</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new Int32 Code { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Name dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>Name</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Name { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Description dell'entità (<see cref=ITemplate/>)
        /// </summary>
        /// <value>
        /// della property <c>Description</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Description { get; set; }




    #endregion

    #region METHODS

    /// <summary>
    /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
    /// </summary>
    /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateDeleteArgs"/>)</param>
    /// <exception cref="TemplateManager.Business.EntityStateException.EntityIsNotDeletableException"></exception>
    ClientMessage Delete(TemplateDeleteArgs args = null);

    /// <summary>
    /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
    /// </summary>
    /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateDeleteArgs"/>)</param>
    /// <exception cref="TemplateManager.Business.EntityStateException.EntityIsNotDeletableException"></exception>
    ClientMessage DeleteFromGateway(TemplateDeleteArgs args = null);

    /// <summary>
    /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
    /// </summary>
    /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateSaveArgs"/>)</param>
    /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.</exception>
    ClientMessage Save(TemplateSaveArgs args = null);

    /// <summary>
    /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.
    /// </summary>
    /// <param name="msg">messaggio che indica la possibilità di eseguire l'operazione.</param>
    /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateSaveArgs"/>)</param>
    /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplate" />.</exception>
    ITemplate SaveFromGateway(out ClientMessage msg, TemplateSaveArgs args = null);

    #region Metodi Can
    /// <summary>
    /// Ritorna true se il <see cref="TemplateManager.DomainObject.ITemplate" /> può essere eliminato.
    /// </summary>
    /// <param name="msg">messaggio che indica la possibilità di eseguire l'operazione.</param>
    /// <param name="args">argomenti per la cancellazione</param>
    /// <returns>true se il <see cref="TemplateManager.DomainObject.ITemplate" /> può essere eliminato, false altrimenti.</returns>
    bool CanDelete(
        out ClientMessage msg,
        TemplateDeleteArgs args = null
    );

    /// <summary>
    /// Verifica se l'istanza corrente di cliente può essere salvata e quindi
    /// genera un messaggio di notifica, <paramref name="msg" />, per il client.
    /// Inoltre ritorna true se l'istanza può essere salvata,
    /// false altrimenti.
    /// </summary>
    /// <param name="msg">messaggio di notifica per il client</param>
    /// <param name="args">argomenti per il salvataggio</param>
    /// <returns>
    /// true se è possibile procedere con il salvataggio, false altrimenti.
    /// </returns>
    bool CanSave(
        out ClientMessage msg,
        TemplateSaveArgs args = null
    );

    #endregion
    #endregion

}
}
