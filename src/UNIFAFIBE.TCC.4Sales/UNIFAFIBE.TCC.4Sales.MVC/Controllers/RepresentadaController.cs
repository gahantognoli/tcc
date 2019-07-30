using System.Collections.Generic;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class RepresentadaController : Controller
    {
        private readonly IRepresentadaAppService _representadaAppService;
        private readonly IEntitySerializationServices<IEnumerable<RepresentadaViewModel>> _serializationColecaoRepresentadaServices;
        private readonly IEntitySerializationServices<RepresentadaViewModel> _serializationRepresentadaService;

        public RepresentadaController(IRepresentadaAppService representadaAppService,
            IEntitySerializationServices<IEnumerable<RepresentadaViewModel>> serializationColecaoRepresentadaServices,
            IEntitySerializationServices<RepresentadaViewModel> serializationRepresentadaService)
        {
            _representadaAppService = representadaAppService;
            _serializationRepresentadaService = serializationRepresentadaService;
            _serializationColecaoRepresentadaServices = serializationColecaoRepresentadaServices;
        }

        public ActionResult Index(string parametro = "", string busca = "")
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;

            return View(SearchByParameter(parametro, busca));
        }
   
        public ActionResult Novo()
        {
            return View();
        }

        private IEnumerable<RepresentadaViewModel> SearchByParameter(string parametro = "", string busca = "")
        {
            IEnumerable<RepresentadaViewModel> representada = new List<RepresentadaViewModel>();

            if (parametro == "cnpj")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    busca = busca.Replace(".", "").Replace("-", "").Replace("/", "");
                    representada = _representadaAppService.ObterPorCnpj(busca);
                    return representada;
                }
            }
            else if (parametro == "nomeFantasia")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    representada = _representadaAppService.ObterPorNomeFantansia(busca);
                    return representada;
                }
            }
            else if (parametro == "razaoSocial")
            {
                if (!string.IsNullOrEmpty(busca))
                {
                    representada = _representadaAppService.ObterPorRazaoSocial(busca);
                    return representada;
                }
            }else
            {
                representada = _representadaAppService.ObterTodos();
                return representada;
            }

            return representada;
        }
    }
}