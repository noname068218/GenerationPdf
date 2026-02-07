

using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;
using System;

namespace TemplateManager.DomainObject
{

    public interface ITemplateParagraph : ITemplateParagraphAdapter
    {

    #region EVENTS
    #endregion

    #region PROPERTIES

            /// <summary>
        /// Ritorna o imposta la property CodeTemplate dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>CodeTemplate</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new Int32 CodeTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property NameOfTemplate dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>NameOfTemplate</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String NameOfTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PositionIndex dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>PositionIndex</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new Int32 PositionIndex { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PresentationInfo dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>PresentationInfo</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String PresentationInfo { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Title dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>Title</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Title { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Subtitle dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>Subtitle</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Subtitle { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Paragraph { get; set; }




    #endregion

    #region METHODS

    /// <summary>
    /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
    /// </summary>
    /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateParagraphDeleteArgs"/>)</param>
    /// <exception cref="TemplateManager.Business.EntityStateException.EntityIsNotDeletableException"></exception>
    ClientMessage Delete(TemplateParagraphDeleteArgs args = null);

    /// <summary>
    /// Elimina l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
    /// </summary>
    /// <param name="args">argomenti per l'eliminazione (<see cref="TemplateManager.DAL.Data.TemplateParagraphDeleteArgs"/>)</param>
    /// <exception cref="TemplateManager.Business.EntityStateException.EntityIsNotDeletableException"></exception>
    ClientMessage DeleteFromGateway(TemplateParagraphDeleteArgs args = null);

    /// <summary>
    /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
    /// </summary>
    /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateParagraphSaveArgs"/>)</param>
    /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.</exception>
    ClientMessage Save(TemplateParagraphSaveArgs args = null);

    /// <summary>
    /// Persiste le modifiche apportate all'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.
    /// </summary>
    /// <param name="msg">messaggio che indica la possibilità di eseguire l'operazione.</param>
    /// <param name="args">argomenti per il salvataggio (<see cref="TemplateManager.DAL.Data.TemplateParagraphSaveArgs"/>)</param>
    /// <exception cref="InvalidOperationException">non è possibile salvare l'istanza corrente dell'entità <see cref="TemplateManager.DomainObject.ITemplateParagraph" />.</exception>
    ITemplateParagraph SaveFromGateway(out ClientMessage msg, TemplateParagraphSaveArgs args = null);

    #region Metodi Can
    /// <summary>
    /// Ritorna true se il <see cref="TemplateManager.DomainObject.ITemplateParagraph" /> può essere eliminato.
    /// </summary>
    /// <param name="msg">messaggio che indica la possibilità di eseguire l'operazione.</param>
    /// <param name="args">argomenti per la cancellazione</param>
    /// <returns>true se il <see cref="TemplateManager.DomainObject.ITemplateParagraph" /> può essere eliminato, false altrimenti.</returns>
    bool CanDelete(
        out ClientMessage msg,
        TemplateParagraphDeleteArgs args = null
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
        TemplateParagraphSaveArgs args = null
    );

    #endregion
    #endregion

}
}
