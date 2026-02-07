using TemplateManager.DAL.Application;
using TemplateManager.DAL.Data;
using TemplateManager.DAL.DomainModel;

namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// interface Gateway per l'entità <see cref="TemplateManager.DAL.Gateway.ITemplateGateway"/>.
    /// </summary>	
    public interface ITemplateGateway :
        IDAOGateway<ITemplateObjectModel, TemplateDeleteArgs, TemplateSelectArgs, TemplateSearchCriteria, TemplateSaveArgs, TemplateView>
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

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

        #endregion


    }
}
