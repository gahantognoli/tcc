using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace UNIFAFIBE.TCC._4Sales.MVC.Helpers
{
    public static class IdentityExtensionMethods
    {
        public static string GetUserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Name);

            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Sid);

            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserImage(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FotoPerfil");

            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Email);

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}