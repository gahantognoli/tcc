using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.TiposPedido
{
    public class TipoPedidoNaoDevePossuirPedidosVinculadosSpecification : ISpecification<TipoPedido>
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public TipoPedidoNaoDevePossuirPedidosVinculadosSpecification(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public bool IsSatisfiedBy(TipoPedido tipoPedido)
        {
            return _pedidoRepositorio.ObterPorTipo(tipoPedido.TipoPedidoId).Count() == 0;
        }
    }
}
