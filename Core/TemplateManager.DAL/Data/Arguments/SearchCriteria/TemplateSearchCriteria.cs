
using Epy.Standard.Core.Args;
using TemplateManager.DAL.Application;
using System;

namespace TemplateManager.DAL.Data
{
    /// <summary>
    /// Argomenti relativi all'operazione di search per l'entità <see cref="TemplateManager.DAL.DomainModel.ITemplateObjectModel"/>.
    /// Le diverse informazioni di dettaglio disponibili per <see cref="TemplateManager.DAL.DomainModel.ITemplateObjectModel"/> 
    /// sono definite in <see cref="TemplateManager.DAL.TemplateView"/>.
    /// </summary>
    public class TemplateSearchCriteria : SearchCriteria<TemplateView>
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
        /// Ritorna o imposta la property Id dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Id</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public Int32? Id { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Code dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Code</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public Int32? Code { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Name dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Name</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? Name { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Description dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Description</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
         public String? Description { get; set; }




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
