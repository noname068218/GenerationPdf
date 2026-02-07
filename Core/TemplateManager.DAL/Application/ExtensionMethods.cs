using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.DAL.Application;
namespace TemplateManager.DAL
{
  public static  class ExtensionMethods
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
        ///// <summary>
        ///// Ritorna un'istanza del service relativo all'entità a livello Object Model.
        ///// </summary>
        ///// <returns>istanza del service relativo all'entità a livello Object Model.</returns>
        public static IServiceLocatorFactory GetServiceLocatore()
        {
            return ServiceLocatorFactory.Instance;
        }

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

        #region Builders

        #endregion


        #endregion
        #region NOT PUBLIC

        #endregion
        #endregion

        #endregion

    }
}
