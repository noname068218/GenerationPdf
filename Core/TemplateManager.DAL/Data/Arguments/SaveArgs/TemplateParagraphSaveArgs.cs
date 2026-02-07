
using Epy.Standard.Core.Args;

namespace TemplateManager.DAL.Data
{
    /// <summary>
    /// Argomenti relativi all'operazione di update per l'entità <see cref="TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel"/>.
    /// </summary>
    public class TemplateParagraphSaveArgs : SaveArgs
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Ritorna o imposta la property ValidityEndDate dell'entità <c>Users</c>
        /// </summary>
        /// <value>
        /// della property <c>ValidityEndDate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public Boolean DisabilitySoftDeleted  { get; set; }

        /// <summary>
        /// Ritorna o imposta la property ValidityEndDate dell'entità <c>Users</c>
        /// </summary>
        /// <value>
        /// della property <c>ValidityEndDate</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public Boolean IsSoftDelete { get => false; }

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
