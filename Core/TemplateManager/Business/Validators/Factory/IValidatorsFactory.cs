
namespace TemplateManager.Business
{
    /// <summary>
    /// Interfaccia della factory per la generazione dei validatori per le entità di TemplateManager.
    /// </summary>
    public interface IValidatorsFactory
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS

        #region Template 

        /// <summary>
        /// Ritorna un'istanza del Validators per <see cref= TemplateManager.DomainObject.ITemplate/>.
        /// </summary>
        /// <returns>L'istanza del Validators per (<see cref= TemplateManager.DomainObject.ITemplate/>).</returns>
        ITemplateValidator GetTemplateValidator();

        #endregion

        #region TemplateParagraph 

        /// <summary>
        /// Ritorna un'istanza del Validators per <see cref= TemplateManager.DomainObject.ITemplateParagraph/>.
        /// </summary>
        /// <returns>L'istanza del Validators per (<see cref= TemplateManager.DomainObject.ITemplateParagraph/>).</returns>
        ITemplateParagraphValidator GetTemplateParagraphValidator();

        #endregion



        #endregion

    }
}
