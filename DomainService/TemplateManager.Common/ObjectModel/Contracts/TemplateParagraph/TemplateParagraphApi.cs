using System;
using System.Runtime.Serialization;

namespace TemplateManager.Common.ObjectModel
{
    /// <summary>
    /// Entità di implementazione <see cref="TemplateParagraphApi"/>
    /// </summary>
    /// 
    [DataContract(Name = "TemplateParagraphApi")]
    public class TemplateParagraphApi: BaseModelApi
    {

    #region FIELDS

    #endregion

    #region CONSTRUCTORS

    #endregion

    #region PROPERTIES

        /// <summary>
        /// Ritorna o imposta la property CodeTemplate dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>CodeTemplate</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? CodeTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property NameOfTemplate dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>NameOfTemplate</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? NameOfTemplate { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PositionIndex dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>PositionIndex</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public Int32? PositionIndex { get; set; }


        /// <summary>
        /// Ritorna o imposta la property PresentationInfo dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>PresentationInfo</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? PresentationInfo { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Title dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>Title</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Title { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Subtitle dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>Subtitle</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
        public String? Subtitle { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Paragraph dell'entità (<see cref=ITemplateParagraph/>)
        /// </summary>
        /// <value>
        /// della property <c>Paragraph</c> dell'entità.
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        [DataMember(IsRequired = false)]
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
