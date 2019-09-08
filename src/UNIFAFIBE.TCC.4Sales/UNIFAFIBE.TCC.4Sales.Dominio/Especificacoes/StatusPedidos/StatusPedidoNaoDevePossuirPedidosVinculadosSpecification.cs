using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.StatusPedidos
{
    public class StatusPedidoNaoDevePossuirPedidosVinculadosSpecification : ISpecification<StatusPedido>
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public StatusPedidoNaoDevePossuirPedidosVinculadosSpecification(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public bool IsSatisfiedBy(StatusPedido status)
        {
            return _pedidoRepositorio.ObterPorStatus(status.StatusPedidoId).Count() == 0;
        }
    }
}
