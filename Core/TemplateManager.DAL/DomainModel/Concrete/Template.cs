
using Epy.Standard.ef;
using System;
namespace TemplateManager.DAL.DomainModel
{
    /// <summary>
    /// Entità di implementazione dell'interfaccio <see cref="ITemplateObjectModel"/>
    /// </summary>
    public class Template : EFDAO<Template>, ITemplateObjectModel
    {

        #region FIELDS

        private Int32 _Code;
        private String _Name;
        private String _AlphaCode;
        private String _Description;


        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES


        /// <summary>
        /// Ritorna o imposta la property Code dell'entità <c>Int32</c>
        /// </summary>
        /// <value>
        /// della property <c>Code</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public Int32 Code { get => _Code; set => _Code = value; }


        /// <summary>
        /// Ritorna o imposta la property Name dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>Name</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String Name { get => _Name; set => _Name = value; }


        /// <summary>
        /// Ritorna o imposta la property AlphaCode dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>AlphaCode</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String AlphaCode { get => _AlphaCode; set => _AlphaCode = value; }


        /// <summary>
        /// Ritorna o imposta la property Description dell'entità <c>String</c>
        /// </summary>
        /// <value>
        /// della property <c>Description</c> .
        /// </value>
        /// <exception cref=System.ArgumentNullException></exception>
        public String Description { get => _Description; set => _Description = value; }




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
