using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Security.Principal;
using UserManager.Common.ObjectModel;

namespace TemplateManager.APIs.BasicAuth
{
    public static class BasicAuthExtension
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

        /// <summary>
        /// Utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        [ThreadStatic]
        private static TokenApi? _TokenUser;

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


        static readonly MemoryCache cacheTokenUser = new(new MemoryCacheOptions { SizeLimit = 512 });
        static readonly MemoryCache cacheTokenAccess = new(new MemoryCacheOptions { SizeLimit = 512 });
        /// <summary>
        /// Ritorna o imposta l'utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        public static String? TokenAccess
        {
            set
            {

                var options = new MemoryCacheEntryOptions().SetSize(1);
                cacheTokenAccess.Set("_TokenAccess_", value, options);
            }
            get { return cacheTokenAccess.Get("_TokenAccess_") as String; }
        }

        /// <summary>
        /// Ritorna o imposta l'utente connesso nel thread dell'applicazione.
        /// E' quello che viene preso per settare l'utente creazione/modifica e cancellazione
        /// </summary>
        /// 
        public static TokenApi? TokenUser
        {
            set
            {

                _TokenUser = value;
            }
            get { return _TokenUser as TokenApi; }
        }

		#endregion
		#region NOT PUBLIC


		#endregion
		#endregion

		#region EVENT HANDLER
		#region PUBLIC
		#endregion
		#region NOT PUBLIC
		#endregion
		#endregion

		#region METHODS
		#region PUBLIC

		/// <summary>
		/// GetRoleIdentityName
		/// </summary>
		/// <returns></returns>
		public static Boolean ValidatePermissions(this IIdentity identity, string authorizations)
		{
			try
			{

                //////Get the current claims principal
                ////List<String> listauthorizations = GetAuthorizationsIdentity(identity);

                //if (listauthorizations == null || String.IsNullOrWhiteSpace(authorizations))
                //	return false;

                //return listauthorizations.Contains(authorizations);
                return true;
            }
			catch (Exception)
			{
				return false;
			}
		}

		#endregion
		#region NOT PUBLIC


		#endregion
		#endregion

		#endregion

	}
}
