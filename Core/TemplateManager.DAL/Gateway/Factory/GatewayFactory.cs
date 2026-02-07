
using TemplateManager.DAL.Data;
using TemplateManager.DAL.Application;
namespace TemplateManager.DAL.Gateway
{
    /// <summary>
    /// Repository Factory.
    /// </summary>
    internal class GatewayFactory : IGatewayFactory
    {


        #region DYNAMIC


        #region METHODS
        #region PUBLIC

        #region Template

        /// <summary>
        /// Ritorna un'implementazione concreta del repository relativo all'entità <see cref= TemplateManager.DAL.DomainModel.ITemplateObjectModel/>.
        /// </summary>
        /// <returns>Implementazione concreta del repository relativo all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateObjectModel/>).</returns>
        public ITemplateGateway GetTemplateGateway()
        {
           return new TemplateGateway(ApplicationContext.GetConnectionString);
        }

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Ritorna un'implementazione concreta del repository relativo all'entità <see cref= TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel/>.
        /// </summary>
        /// <returns>Implementazione concreta del repository relativo all'entità (<see cref= TemplateManager.DAL.DomainModel.ITemplateParagraphObjectModel/>).</returns>
        public ITemplateParagraphGateway GetTemplateParagraphGateway()
        {
           return new TemplateParagraphGateway(ApplicationContext.GetConnectionString);
        }

        #endregion



        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion



    }
}
