
using Epy.Standard.Core.Args;
using System;

namespace TemplateManager.DAL.Data
{
    /// <summary>
    /// Argomenti relativi all'operazione di delete per l'entità <see cref="TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel"/>.
    /// </summary>
    public class TemplateParagraphDeleteArgs : DeleteArgs
    {

    #region FIELDS

    #endregion

    #region CONSTRUCTORS
    public TemplateParagraphDeleteArgs()
    {
        IsSoftDelete = true;
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
        public Boolean IsSoftDelete { get; set; }

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
