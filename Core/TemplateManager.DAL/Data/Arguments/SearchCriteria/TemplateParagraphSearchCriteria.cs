
using Epy.Standard.Core.Args;
using TemplateManager.DAL.Application;
using System;

namespace TemplateManager.DAL.Data
{
    /// <summary>
    /// Argomenti relativi all'operazione di search per l'entità <see cref="TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel"/>.
    /// Le diverse informazioni di dettaglio disponibili per <see cref="TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel"/> 
    /// sono definite in <see cref="TemplateManager.DAL.TemplateParagraphView"/>.
    /// </summary>
    public class TemplateParagraphSearchCriteria : SearchCriteria<TemplateParagraphView>
    {

    #region FIELDS

    #endregion

    #region CONSTRUCTORS

    #endregion

    #region PROPERTIES
    /// <summary>
    /// Ritorna o imposta la property RowsTop dell'entità <c>Customizations</c>
    /// </summary>
    /// <value>
    /// della property <c>RowsTop</c> .
    /// </value>
    /// <exception cref=System.ArgumentNullException></exception>
    public new Int32? RowsTop { get; set; }
    /// <summary>
    /// Ritorna o imposta la property ValidityEndDate dell'entità <c>Users</c>
    /// </summary>
    /// <value>
    /// della property <c>ValidityEndDate</c> .
    /// </value>
    /// <exception cref=System.ArgumentNullException></exception>
    public Boolean? IncludeSoftDeleted { get; set; }

    /// <summary>
    /// Ritorna o imposta la property ValidityEndDate dell'entità <c>Users</c>
    /// </summary>
    /// <value>
    /// della property <c>ValidityEndDate</c> .
    /// </value>
    /// <exception cref=System.ArgumentNullException></exception>
    public Boolean? IsSoftDelete { get => false; }


        /// <summary>
        /// Ritorna o imposta la property Id dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>Id</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public Int32? Id { get; set; }


        /// <summary>
        /// Ritorna o imposta la property CodeTemplate dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>CodeTemplate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public Int32? CodeTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property NameOfTemplate dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>NameOfTemplate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? NameOfTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PositionIndex dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>PositionIndex</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public Int32? PositionIndex { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PresentationInfo dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>PresentationInfo</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? PresentationInfo { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Title dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>Title</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? Title { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Subtitle dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>Subtitle</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? Subtitle { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? Paragraph { get; set; }




    #endregion

    #region METHODS

    #region PUBLIC

    #region METODI Members

    #endregion

    #endregion

    #region NOT PUBLIC

    #endregion

    #endregion

}
}
