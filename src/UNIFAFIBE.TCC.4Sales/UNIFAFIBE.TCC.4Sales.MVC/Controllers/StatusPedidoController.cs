using System.Collections.Generic;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class StatusPedidoController : Controller
    {
        private readonly IStatusPedidoAppService _statusPedidoAppService;
        private readonly IEntitySerializationServices<IEnumerable<StatusPedidoViewModel>> _entitySerializationServices;

        public StatusPedidoController(IStatusPedidoAppService statusPedidoAppService, 
            IEntitySerializationServices<IEnumerable<StatusPedidoViewModel>> entitySerializationServices)
        {
            _statusPedidoAppService = statusPedidoAppService;
            _entitySerializationServices = entitySerializationServices;
        }

        // GET: StatusPedido
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult Novo(StatusPedidoViewModel statusPedido)
        {
            var statusRetorno = _statusPedidoAppService.Adicionar(statusPedido);
            if(statusRetorno.ValidationResult.IsValid)
            {
                var json = _entitySerializationServices.Serialize(_statusPedidoAppService.ObterTodos());
                return Json(new { statusPedido = json }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { statusPedido = statusRetorno }, JsonRequestBehavior.AllowGet);
        }
    }
}