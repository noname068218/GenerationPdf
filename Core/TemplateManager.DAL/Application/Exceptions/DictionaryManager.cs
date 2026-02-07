using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.DAL.Application
{
    internal static class DictionaryManager
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES
        public static Dictionary<string, int> ErrorMessage
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { "AncestorsMustBeSavedFirst", 1001},
                    { "CoreApplication", 1002},
                    { "ConfigurationContex", 1003},
                    { "ContexManager", 1004 },
                    { "DomainModel", 1005 },
                    { "Gateway", 1006},
                    { "Repository", 1007},
                    { "CoreBusiness", 1008},
                    { "ArgumentIsNullOrEmpty", 1010},
                    { "MissingRequiredField", 1011},
                    { "InvalidFieldValue", 1012},
                    { "DuplicateEntity", 1013},
                    { "OnAddAction", 1013},
                    { "OnSaveAction", 1014},
                    { "OnCustomAction", 1015},
                    { "OnRemoveAction", 1016}
                };
            }
        }
        #endregion

        #region METHODS

        #region PUBLIC

        #region METODI Members

        #endregion

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

    }
}
