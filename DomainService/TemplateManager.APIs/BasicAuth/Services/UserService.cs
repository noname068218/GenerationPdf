using Epy.Standard.Core.Common;
using UserManager.Common.ObjectModel;

namespace TemplateManager.APIs
{
    public class UserService : IUserService
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
        /// Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>OutputLoginApi</returns>
        public Boolean DecryptedTokenAsync(string? tokenKey, out OutputTokenApi? output)
        {
            output = null;

            if (!tokenKey.IsNullOrEmptyOrWhiteSpace())
            {
                output = UserManagerAPIsRest.Plugin.Application.DomainServiceAPIsRest.GetUserManagerAPIsRestService().DecryptedTokenAsync(new InputTokenKey() { TokenKey = tokenKey }).Result;

                if (output != null && output.IsValid && output.TokenApi.IsAuthorized.HasValue && output.TokenApi.IsAuthorized.Value)
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>OutputLoginApi</returns>
        public Boolean DecryptedTokenAsync(string? tokenKey, out TokenApi? tokenApi)
        {
            tokenApi = null;

            if (!tokenKey.IsNullOrEmptyOrWhiteSpace())
            {
                OutputTokenApi output = UserManagerAPIsRest.Plugin.Application.DomainServiceAPIsRest.GetUserManagerAPIsRestService().DecryptedTokenAsync(new InputTokenKey() { TokenKey = tokenKey }).Result;

                if (output != null && output.IsValid && output.TokenApi.IsAuthorized.HasValue && output.TokenApi.IsAuthorized.Value)
                {
                    tokenApi = output.TokenApi;

                    return true;
                }

            }

            return false;
        }
        #endregion

    }

}