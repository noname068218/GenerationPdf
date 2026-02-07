
using Epy.Standard.ef;
using System;
namespace TemplateManager.DAL.DomainModel
{
    /// <summary>
    /// Entità di implementazione dell'interfaccio <see cref="ITemplateParagraphObjectModel"/>
    /// </summary>
    public class TemplateParagraph : EFDAO<TemplateParagraph>, ITemplateParagraphObjectModel
    {

        #region FIELDS

        private Int32 _CodeTemplate;
        private String _NameOfTemplate;
        private String _AlphaCode;
        private Int32 _PositionIndex;
        private String _PresentationInfo;
        private String _Title;
        private String _Subtitle;
        private String _Paragraph;


        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES


        /// <summary>
        /// Ritorna o imposta la property CodeTemplate dell'entità <c>Int32</c>
        /// </summary>
        /// <value>
        /// della property <c>CodeTemplate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public Int32 CodeTemplate { get => _CodeTemplate; set => _CodeTemplate = value; }


        /// <summary>
        /// Ritorna o imposta la property NameOfTemplate dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>NameOfTemplate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String NameOfTemplate { get => _NameOfTemplate; set => _NameOfTemplate = value; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String AlphaCode { get => _AlphaCode; set => _AlphaCode = value; }


        /// <summary>
        /// Ritorna o imposta la property PositionIndex dell'entità <c>Int32</c>
        /// </summary>
        /// <value>
        /// della property <c>PositionIndex</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public Int32 PositionIndex { get => _PositionIndex; set => _PositionIndex = value; }


        /// <summary>
        /// Ritorna o imposta la property PresentationInfo dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>PresentationInfo</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String PresentationInfo { get => _PresentationInfo; set => _PresentationInfo = value; }


        /// <summary>
        /// Ritorna o imposta la property Title dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>Title</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String Title { get => _Title; set => _Title = value; }


        /// <summary>
        /// Ritorna o imposta la property Subtitle dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>Subtitle</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String Subtitle { get => _Subtitle; set => _Subtitle = value; }


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String Paragraph { get => _Paragraph; set => _Paragraph = value; }




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
