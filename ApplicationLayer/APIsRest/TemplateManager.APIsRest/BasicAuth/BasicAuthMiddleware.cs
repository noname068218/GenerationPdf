using Microsoft.AspNetCore.Identity;
namespace WebApi.Authorization;
using System.Security.Claims;
using TemplateManager.APIs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using UserManager.Common.ObjectModel;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        try
        {
            string? tokenKey = context.Request.Headers["Authorization"];


            if (!userService.DecryptedTokenAsync(tokenKey, out OutputTokenApi? outputTokenApi) || outputTokenApi.TokenApi == null)
                throw new ArgumentException("Invalid token Api Key");

            if (outputTokenApi.TokenApi.IdUser.HasValue)
            {
                TemplateManager.DAL.Application.ApplicationContext.IdUtente = outputTokenApi.TokenApi.IdUser.Value;
                TemplateManager.APIs.BasicAuth.BasicAuthExtension.TokenUser = outputTokenApi.TokenApi;
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, outputTokenApi.TokenApi.EMail)
            };

            if (outputTokenApi.IsValid && outputTokenApi.TokenApi != null)
            {

                if (outputTokenApi.TokenApi.Roles != null && outputTokenApi.TokenApi.Roles.Any())
                {
                    foreach (var role in outputTokenApi.TokenApi.Roles)
                        claims.Add(new Claim(ClaimTypes.Role, role.NameOfRole));
                }

                if (outputTokenApi.TokenApi.Authorizations != null && outputTokenApi.TokenApi.Authorizations.Any())
                {
                    foreach (var authorization in outputTokenApi.TokenApi.Authorizations)
                        claims.Add(new Claim(type: "Authorization", value: authorization.NameOfAuthorization));


                }

                context.Items["TokenApi"] = outputTokenApi;
            }

            // authenticate credentials with user service and attach user to http context
            //context.Items["User"] = await userService.Authenticate(username, password);


            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, CookieAuthenticationDefaults.AuthenticationScheme);
            context.User = principal;

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.
                AllowRefresh = true,

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.
                IsPersistent = true,
                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.
                IssuedUtc = DateTimeOffset.UtcNow,
                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await context.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    authProperties);


            AuthenticateResult.Success(ticket);
        }
        catch (Exception ex)
        {
            AuthenticateResult.Fail($"Authentication failed: {ex.Message}");

        }

        await _next(context);
    }
}