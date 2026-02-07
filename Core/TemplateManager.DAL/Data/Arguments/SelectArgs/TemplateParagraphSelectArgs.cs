
using Epy.Standard.Core.Args;
using TemplateManager.DAL.Application;


using System;
namespace TemplateManager.DAL.Data
{
    /// <summary>
    /// Argomenti relativi al recupero di una singola istanza di un'entità di tipo <see cref="TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel"/>.
    /// </summary>
    public class TemplateParagraphSelectArgs : SelectArgs<TemplateParagraphView, TemplateParagraphSelectArgs>
     {

    #region FIELDS

    #endregion

    #region CONSTRUCTORS
    public TemplateParagraphSelectArgs()
    {
        IncludeSoftDeleted = false;
    }
        #endregion

    #region PROPERTIES
    /// <summary>
    /// Ritorna o imposta la property ValidityEndDate dell'entità <c>Users</c>
    /// </summary>
    /// <value>
    /// della property <c>ValidityEndDate</c> .
    /// </value>
    /// <exception cref=System.ArgumentNullException></exception>
        public Boolean? IncludeSoftDeleted { get; set; }

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
