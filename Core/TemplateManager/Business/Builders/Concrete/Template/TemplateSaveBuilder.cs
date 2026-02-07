using System;
using TemplateManager.DomainObject;

namespace TemplateManager.Business
{
    /// <summary>
    /// Implementazione del Builder per la Template
    /// </summary>
    internal class TemplateSaveBuilder : ITemplateSaveBuilder
    {

        #region STATIC
        #region EVENTS
        #region PUBLIC
        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

        #region FIELDS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion

        #region DYNAMIC

        #region EVENTS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region FIELDS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region PROPERTIES
        #region PUBLIC

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC
        /// <summary>
        /// Data un'istanza di Transazione esegue le operazioni necessarie al suo corretto salvataggio.
        /// </summary>
        /// <param name="input">Transazione.</param>
        /// <param name="args">Argomenti per la gestione del builder.</param>
        /// <exception cref="System.ArgumentNullException">Transazione</exception>
        public void Build(ITemplate input, TemplateSaveBuilderArgs args = null)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

        }

        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion

    }
}
