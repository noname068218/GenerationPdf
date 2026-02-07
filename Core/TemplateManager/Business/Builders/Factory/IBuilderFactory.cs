namespace TemplateManager.Business
{
    /// <summary>
    /// Interfaccia del factory per la creazione di builder per le entità diTemplateManager.
    /// Un builder si occupa di eseguire un'operazione su un'istanza dell'entità.
    /// </summary>
    internal interface IBuilderFactory
    {
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

        #region Template 

        /// <summary>
        /// Ritorna un'istanza del Builder per <see cref= TemplateManager.DomainObject.ITemplate/>.
        /// </summary>
        /// <returns>L'istanza del Builder per (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        ITemplateSaveBuilder GetTemplateSaveBuilder();

        #endregion

        #region TemplateParagraph 

        /// <summary>
        /// Ritorna un'istanza del Builder per <see cref= TemplateManager.DomainObject.ITemplateParagraph/>.
        /// </summary>
        /// <returns>L'istanza del Builder per (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        ITemplateParagraphSaveBuilder GetTemplateParagraphSaveBuilder();

        #endregion



        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion
    }
}
