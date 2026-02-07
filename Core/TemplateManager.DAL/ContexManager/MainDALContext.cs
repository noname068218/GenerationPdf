using Epy.Standard.ef;
using Microsoft.EntityFrameworkCore;
using TemplateManager.DAL.Application;


namespace TemplateManager.DAL.ContexManager
{
    public class MainDALContext : EFDALContext<MainContext>
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
        private static DbContextOptions ContextOptions { set; get; }
        public static MainContext Context { get; set; }
        #endregion
        #region NOT PUBLIC
        private string ConnectionStringName { set; get; }
        #endregion
        #endregion

        #region CONSTRUCTORS
        #region PUBLIC
        /// <summary>
        /// 
        /// </summary>
        public MainDALContext()
        {
            ContextOptions = ApplicationContext.DbContextOptions;

        }
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
        /// BuildNewDbContext
        /// </summary>
        /// <returns></returns>
        public override MainContext BuildNewDbContext()
        {
            if (Context == null)
            {
                Context = new MainContext(ContextOptions)
                {
                    EnableSoftDelete = ConfigurationService.EnableSoftDelete,
                    IdUtenteAzione = ApplicationContext.IdUtente
                };
            }
            return Context;
        }

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #endregion
    }
}
