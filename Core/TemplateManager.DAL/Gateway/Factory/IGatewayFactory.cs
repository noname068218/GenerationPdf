
namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// Factory per i gateway.
    /// </summary>
    public interface IGatewayFactory
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

        #region METHODS

        #region PUBLIC

        #region Template 

        /// <summary>
        /// Ritorna un'implementazione concreta del repository relativo all'entità <see cref= TemplateManager.DAL.DomainModel.ITemplateObjectModel/>.
        /// </summary>
        /// <returns>Implementazione concreta del repository relativo all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateObjectModel/>).</returns>
        ITemplateGateway GetTemplateGateway();

        #endregion

        #region TemplateParagraph 

        /// <summary>
        /// Ritorna un'implementazione concreta del repository relativo all'entità <see cref= TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel/>.
        /// </summary>
        /// <returns>Implementazione concreta del repository relativo all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel/>).</returns>
        ITemplateParagraphGateway GetTemplateParagraphGateway();

        #endregion



        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

        #endregion


    }
}
