using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Helpers
{
    public static class ClaimsExtensionMethod
    {
        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);
            return claim.Value;
        }

        public static void RemoveClaims(IEnumerable<Claim> claims, ClaimsIdentity identity)
        {
            foreach (var claim in claims)
            {
                identity.RemoveClaim(claim);
            }
        }

        public static void UpdateImageClaim(this IPrincipal currentPrincipal, Guid id,
            IUsuarioAppService usuarioAppService)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            identity.RemoveClaim(identity.FindFirst(c => c.Type == "FotoPerfil"));

            var usuario = usuarioAppService.ObterPorId(id);

            if (usuario.FotoPerfil == null)
            {
                string imgDefault = "~/assets/img/user-default.png";
                identity.AddClaim(new Claim("FotoPerfil", imgDefault));
            }
            else
            {
                identity.AddClaim(new Claim("FotoPerfil", usuario.FotoPerfil));
            }

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true });
        }
    }
}