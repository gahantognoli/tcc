using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(UNIFAFIBE.TCC._4Sales.MVC.App_Start.Startup))]

namespace UNIFAFIBE.TCC._4Sales.MVC.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions() {
                AuthenticationType = "ServerCookie",
                LoginPath = new PathString("/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "AuthenticationCookie",
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromHours(3),
                LogoutPath = new PathString("/Logoff"),
                CookieSecure = CookieSecureOption.SameAsRequest,
                SlidingExpiration = true
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Sid;
        }
    }
}
