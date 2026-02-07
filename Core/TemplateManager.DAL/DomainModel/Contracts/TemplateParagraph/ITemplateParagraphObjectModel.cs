using System;

namespace TemplateManager.DAL.DomainModel
{
    /// <summary>
    ///Interfaccia per TemplateParagraph di comunicazione tra l'Object Model e il Domain Object. 
    /// </summary>
    /// <typeparam name="TTemplateParagraph"></typeparam>
    public interface ITemplateParagraphObjectModel : ITemplateParagraphAdapter
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Ritorna o imposta la property CodeTemplate dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>CodeTemplate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new Int32 CodeTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property NameOfTemplate dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>NameOfTemplate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String NameOfTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PositionIndex dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>PositionIndex</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new Int32 PositionIndex { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PresentationInfo dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>PresentationInfo</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String PresentationInfo { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Title dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>Title</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Title { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Subtitle dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>Subtitle</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Subtitle { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità <c>TemplateParagraph</c>
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        new String Paragraph { get; set; }



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
