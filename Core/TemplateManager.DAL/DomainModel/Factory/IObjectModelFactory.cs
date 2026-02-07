
namespace TemplateManager.DAL.DomainModel
{
    /// <summary>
    /// Factory per l'object model.
    /// </summary>
    public interface IObjectModelFactory
    {

        #region EVENTS
        #endregion

        #region PROPERTIES
        #endregion

        #region METHODS
        ///Create New istanza

        #region Template 

        /// <summary>
        /// Crea un'istanza di tipo <see cref=" TemplateManager.ObjectModel.ITemplate"/>.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref=" TemplateManager.ObjectModel.ITemplate"/>).</returns>
        ITemplateObjectModel CreateNewTemplate();

        #endregion

        #region TemplateParagraph 

        /// <summary>
        /// Crea un'istanza di tipo <see cref=" TemplateManager.ObjectModel.ITemplateParagraph"/>.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref=" TemplateManager.ObjectModel.ITemplateParagraph"/>).</returns>
        ITemplateParagraphObjectModel CreateNewTemplateParagraph();

        #endregion



        #endregion


    }
}
