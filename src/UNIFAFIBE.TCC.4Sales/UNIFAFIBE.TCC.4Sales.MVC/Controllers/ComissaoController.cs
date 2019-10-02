using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.MVC.Filters;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    [Authorize]
    [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM")]
    public class ComissaoController : Controller
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IEntitySerializationServices<IEnumerable<Comissao>> _entitySerializationServices;

        public ComissaoController(IPedidoAppService pedidoAppService,
            IEntitySerializationServices<IEnumerable<Comissao>> entitySerializationServices)
        {
            _pedidoAppService = pedidoAppService;
            _entitySerializationServices = entitySerializationServices;
        }

        public ActionResult Listar(string mes, string ano)
        {
            int mesInteiro = Convert.ToInt32(mes);
            int anoInteiro = Convert.ToInt32(ano);
            var json = _entitySerializationServices.Serialize(_pedidoAppService.ObterComissoes(mesInteiro, anoInteiro));
            return Json(new { comissoes = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AtualizarPagamento(string parcelaId, bool pago)
        {
            var parcelaIdConvertida = Guid.Parse(parcelaId);
            _pedidoAppService.AtualizarPagamentoComissao(parcelaIdConvertida, pago);
            return Json(new { retorno = true }, JsonRequestBehavior.AllowGet);
        }
    }
}