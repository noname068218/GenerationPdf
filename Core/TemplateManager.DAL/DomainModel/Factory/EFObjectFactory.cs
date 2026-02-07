
using TemplateManager.DAL.DomainModel;


namespace TemplateManager.DAL.DomainModel
{
    /// <summary>
    /// Object Model Factory.
    /// </summary>
    internal class EFObjectFactory : IObjectModelFactory
    {

        #region DYNAMIC

        #region EVENTS

        #endregion

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        #endregion


        #region METHODS

        #region Template

        /// <summary>
        /// Crea un'istanza di <c>ITemplateObjectModel</c> (<see cref=" TemplateManager.ObjectModel.ITemplate"/>)
        /// </summary>
        /// <returns>L'istanza di <c>ITemplateObjectModel</c> (<see cref=" TemplateManager.ObjectModel.ITemplate"/>).</returns>
        public ITemplateObjectModel CreateNewTemplate()
         {
           return new Template();
         }

        #endregion

        #region TemplateParagraph

        /// <summary>
        /// Crea un'istanza di <c>ITemplateParagraphObjectModel</c> (<see cref=" TemplateManager.ObjectModel.ITemplateParagraph"/>)
        /// </summary>
        /// <returns>L'istanza di <c>ITemplateParagraphObjectModel</c> (<see cref=" TemplateManager.ObjectModel.ITemplateParagraph"/>).</returns>
        public ITemplateParagraphObjectModel CreateNewTemplateParagraph()
         {
           return new TemplateParagraph();
         }

        #endregion



        #endregion




        #endregion

    }
}
