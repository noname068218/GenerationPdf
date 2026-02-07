using System;

namespace TemplateManager.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigurationService
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
        private static string _mainConnectionStringKey;
        private static string _IDALContextKey;
        private static bool _enableSoftDelete;
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

        /// <summary>
        /// Ritorna il tipo di delete predefinito (Fisico/Logico) 
        /// </summary>
        public static bool EnableSoftDelete
        {
            get
            {
                return _enableSoftDelete;
            }
            set
            {
                _enableSoftDelete = value;
            }
        }


        /// <summary>
        /// Ritorna o imposta il nome della chiave della connection string associata a .
        /// </summary>
        public static string MainConnectionStringKey
        {
            get
            {
                if (String.IsNullOrEmpty(_mainConnectionStringKey))
                {
                    _mainConnectionStringKey = "TemplateManagerConnectionString";
                }

                return _mainConnectionStringKey;
            }

            internal set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));

                _mainConnectionStringKey = value;
            }
        }

        /// <summary>
        /// Ritorna la chiave di registrazione per l'IDALContext specifico per il DBMS sottostante 
        /// a .
        /// </summary>
        public static string IDALContextKey
        {
            get
            {
                if (String.IsNullOrEmpty(_IDALContextKey))
                {
                    _IDALContextKey = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                }

                return _IDALContextKey;
            }
        }

        /// <summary>
        /// Identificativo associato al Context della UserManager.
        /// </summary>
        public static string UserManagerKey
        {
            get
            {
                return "UserManagerKey";
            }
        }

        #endregion
        #endregion
        #region METHODS
        #region NOT PUBLIC
        #region Private

        #endregion

        #endregion
        #endregion

        #endregion
    }
}
