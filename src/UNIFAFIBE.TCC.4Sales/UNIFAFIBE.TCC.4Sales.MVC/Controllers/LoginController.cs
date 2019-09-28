using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.MVC.Models;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public LoginController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                UrlRetorno = returnUrl
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (_usuarioAppService.Logar(login.Username, login.Password))
            {
                var usuario = _usuarioAppService.ObterPorEmail(login.Username);
                if (usuario.PrimeiroAcesso)
                {
                    return RedirectToAction("RedefinirSenha", new { usuarioId = usuario.UsuarioId });
                }
                else
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut("ServerCookie");
                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false },
                        CreateIdentity(usuario));
                    if (!string.IsNullOrWhiteSpace(login.UrlRetorno) || Url.IsLocalUrl(login.UrlRetorno))
                        return Redirect(login.UrlRetorno);
                    else
                        return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                ModelState.AddModelError("Erro", "Usuário ou senha inválidos!");
            }
            return View("Index", login);
        }

        public ActionResult RedefinirSenha(Guid usuarioId)
        {
            if (_usuarioAppService.ObterPorId(usuarioId).PrimeiroAcesso == true)
            {
                ViewBag.UsuarioId = usuarioId;
                return View();
            }
            else
            {
                return Content("Senha já alterada");
            }
        }

        [HttpPost]
        public ActionResult RedefinirSenha(RedefirSenhaViewModel redefirSenhaViewModel)
        {
            if (_usuarioAppService.ObterPorId(redefirSenhaViewModel.UsuarioId).PrimeiroAcesso == true)
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.UsuarioId = redefirSenhaViewModel.UsuarioId;
                    return View(redefirSenhaViewModel);
                }

                if (redefirSenhaViewModel.Senha != redefirSenhaViewModel.ConfirmarSenha)
                {
                    ViewBag.UsuarioId = redefirSenhaViewModel.UsuarioId;
                    ModelState.AddModelError("Erro", "As senha não conferem!");
                    return View(redefirSenhaViewModel);
                }

                _usuarioAppService.AlterarSenha(redefirSenhaViewModel.UsuarioId, redefirSenhaViewModel.Senha);
                _usuarioAppService.AlterarPrimeiroAcesso(redefirSenhaViewModel.UsuarioId);
                return View("Index");
            }
            else
            {
                return Content("Senha já alterada");
            }
        }

        public virtual ActionResult Logoff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut("ServerCookie");
            return RedirectToAction("Index");
        }

        private ClaimsIdentity CreateIdentity(UsuarioViewModel usuario)
        {
            
            ClaimsIdentity identity = new ClaimsIdentity("ServerCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim(ClaimTypes.Sid, usuario.UsuarioId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
            identity.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, usuario.UsuarioResponsavel == true ? "ADM" : string.Empty));

            if (usuario.FotoPerfil == null)
            {
                string imgDefault = "~/assets/img/user-default.png";
                identity.AddClaim(new Claim("FotoPerfil", imgDefault));
            }
            else
            {
                identity.AddClaim(new Claim("FotoPerfil", usuario.FotoPerfil));
            }

            return identity;
        }
    }
}