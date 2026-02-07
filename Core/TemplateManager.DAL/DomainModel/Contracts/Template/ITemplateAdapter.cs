using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateManager.DAL.DomainModel
{
    /// <summary>
    ///Interfaccia per Template di comunicazione tra l'Object Model e il Domain Object. 
    /// </summary>
    public interface ITemplateAdapter : IObjectModel
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Ritorna o imposta la property Code dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Code</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        Int32 Code { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Name dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Name</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        String Name { get; set; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        String AlphaCode { get; set; }


        /// <summary>
        /// Ritorna o imposta la property Description dell'entità <c>Template</c>
        /// </summary>
        /// <value>
        /// della property <c>Description</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        String Description { get; set; }




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
