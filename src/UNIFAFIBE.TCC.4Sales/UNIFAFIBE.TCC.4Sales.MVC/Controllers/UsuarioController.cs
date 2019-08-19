using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IEntitySerializationServices<IEnumerable<UsuarioViewModel>> _colecaoSerializationUsuariosService;
        private readonly IEntitySerializationServices<UsuarioViewModel> _serializationUsuariosService;
        private readonly IRepresentadaAppService _representadaAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService, 
            IEntitySerializationServices<IEnumerable<UsuarioViewModel>> colecaoSerializationUsuariosService,
            IEntitySerializationServices<UsuarioViewModel> serializationUsuariosService, 
            IRepresentadaAppService representadaAppService)
        {
            _usuarioAppService = usuarioAppService;
            _colecaoSerializationUsuariosService = colecaoSerializationUsuariosService;
            _serializationUsuariosService = serializationUsuariosService;
            _representadaAppService = representadaAppService;
        }

        // GET: Usuario
        public JsonResult Listar()
        {
            var json = _colecaoSerializationUsuariosService.Serialize(_usuarioAppService.ObterTodos());
            return Json(new { usuario = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {

            PopularViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Novo(UsuarioViewModel usuario, string UsuarioResponsavel, string[] RepresentadaId)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (UsuarioResponsavel != null && UsuarioResponsavel != "false")
                    {
                        usuario.UsuarioResponsavel = true;
                    }

                    if (RepresentadaId != null)
                    {
                        foreach (var item in RepresentadaId)
                        {
                            if (item != "false")
                            {
                                usuario.Representadas.Add(_representadaAppService.ObterPorId(Guid.Parse(item)));
                            }
                        }
                    }

                    var usuarioRetorno = _usuarioAppService.Adicionar(usuario);
                    if (usuarioRetorno.ValidationResult.IsValid)
                    {
                        TempData["CadastradoSucesso"] = "Usuário " + usuario.Nome +
                              " cadastrado com sucesso";
                        return RedirectToAction("Index", "PainelAdministrativo");
                    }
                    usuario.ValidationResult = usuarioRetorno.ValidationResult;
                }
                PopularViewBag();
                return View(usuario);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ActionResult Alterar(Guid id)
        {
            PopularViewBag();
            var usuarioRetorno = _usuarioAppService.ObterPorId(id);
            return View(usuarioRetorno);
        }

        [HttpPost]
        public ActionResult Alterar(UsuarioViewModel usuario, string UsuarioResponsavel, string[] RepresentadaId)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (UsuarioResponsavel != null && UsuarioResponsavel != "false")
                    {
                        usuario.UsuarioResponsavel = true;
                    }

                    if (RepresentadaId != null)
                    {
                        foreach (var item in RepresentadaId)
                        {
                            if (item != "false")
                            {
                                usuario.Representadas.Add(_representadaAppService.ObterPorId(Guid.Parse(item)));
                            }
                        }
                    }

                    var usuarioRetorno = _usuarioAppService.Atualizar(usuario);
                    if (usuarioRetorno.ValidationResult.IsValid)
                    {
                        TempData["AtualizadoSucesso"] = "Usuário " + usuario.Nome +
                              " alterado com sucesso";
                        return RedirectToAction("Index", "PainelAdministrativo");
                    }
                    usuario.ValidationResult = usuarioRetorno.ValidationResult;
                }
                PopularViewBag();
                return View(usuario);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult AlterarSenha(Guid usuarioId, string novaSenha)
        {
            var usuario = _usuarioAppService.AlterarSenha(usuarioId, novaSenha);
            if (usuario.ValidationResult.IsValid)
            {
                return Json(new { validationResult = usuario.ValidationResult }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { validationResult = usuario.ValidationResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Desativar(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioViewModel usuario = _usuarioAppService.ObterPorId((Guid)id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            PopularViewBag();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Desativar(Guid id)
        {
            try
            {
                _usuarioAppService.Desativar(id);
                TempData["DesativadoSucesso"] = "Usuario removido com sucesso";
                return RedirectToAction("Index", "PainelAdministrativo");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ActionResult EditarPerfil(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioViewModel usuario = _usuarioAppService.ObterPorId((Guid)id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            PopularViewBag();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarPerfil(UsuarioViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var usuarioRetorno = _usuarioAppService.EditarPerfil(usuario);
                    if (usuarioRetorno.ValidationResult.IsValid)
                    {
                        TempData["CadastradoSucesso"] = "Usuário " + usuario.Nome +
                              " alterado com sucesso";
                        return RedirectToAction("Index", "Dashboard");
                    }
                    usuario.ValidationResult = usuarioRetorno.ValidationResult;
                }

                PopularViewBag();
                return View(usuario);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public JsonResult SalvarImagem(HttpPostedFileBase fileUpload)
        {
            string fileExtension = fileUpload.ContentType;

            if (VerifyAllowExtensions(fileExtension))
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var hash = new string(Enumerable.Repeat(chars, 24)
                  .Select(s => s[random.Next(s.Length)]).ToArray()).ToLower();

                StringBuilder fileName = new StringBuilder().Append(hash).
                    Append((DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                    DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()
                    + DateTime.Now.Millisecond.ToString()).ToString());
                
                string path = "~/Images/ProfileImages/" +
                    fileName.ToString() + RetornaExtensaoImagem(fileUpload.ContentType);

                fileUpload.SaveAs(Server.MapPath(path));

                return Json(new { caminhoImagem = path }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string erro = "Selecione uma imagem em um formato válido(.jpg, .png, .gif)";
                return Json(new { erro = erro}, JsonRequestBehavior.AllowGet);
            }

        }

        public void PopularViewBag()
        {
            ViewBag.Representadas = _representadaAppService.ObterTodos();
        }

        private bool VerifyAllowExtensions(string fileExtension)
        {
            string[] allowExtensions = new string[] { "image/jpeg", "image/png", "image/gif" };

            if (allowExtensions.ToList().Contains(fileExtension))
            {
                return true;
            }

            return false;
        }

        public string RetornaExtensaoImagem(string contentType)
        {
            var extensao = "";
            switch (contentType)
            {
                case "image/jpeg":
                    extensao = ".jpg";
                    break;
                case "image/png":
                    extensao = ".png";
                    break;
                case "image/gif":
                    extensao = ".gif";
                    break;
            }
            return extensao;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _representadaAppService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}