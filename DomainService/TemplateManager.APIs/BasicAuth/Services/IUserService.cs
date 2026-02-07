using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Common.ObjectModel;

namespace TemplateManager.APIs
{
    public interface IUserService
    {
        #region EVENTS
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Ritorna un'istanza del service relativo all'entità <see cref= MyEpy.DomainObject.IUsers/> a livello Domain.
        /// </summary>
        /// <returns>istanza del service relativo all'entità (<see cref= MyEpy.DomainObject.IUsers/>) a livello Domain.</returns>
        //protected IMyEpyService ServiceMyEpy { get => DomainServiceAPIs.GetMyEpyService(); }

        #endregion

        #region METHODS

        /// <summary>
        /// DecryptedTokenAsync
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>OutputLoginApi</returns>
        Boolean DecryptedTokenAsync(string? tokenKey, out OutputTokenApi? output);
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>OutputLoginApi</returns>
        Boolean DecryptedTokenAsync(string? tokenKey, out TokenApi? tokenApi);
        #endregion
    }
}
