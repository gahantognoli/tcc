using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Pedidos
{
    public class PedidoDevePossuirNumeroUnicoSpecification : ISpecification<Pedido>
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoDevePossuirNumeroUnicoSpecification(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public bool IsSatisfiedBy(Pedido pedido)
        {
            return _pedidoRepositorio.ObterPorNumeroPedido(pedido.NumeroPedido) == null;
        }
    }
}
