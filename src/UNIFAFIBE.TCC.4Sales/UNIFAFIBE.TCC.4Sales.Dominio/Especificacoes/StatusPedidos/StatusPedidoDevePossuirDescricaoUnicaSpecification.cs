using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.StatusPedidos
{
    public class StatusPedidoDevePossuirDescricaoUnicaSpecification : ISpecification<StatusPedido>
    {
        private readonly IStatusPedidoRepositorio _statusPedidoRepositorio;

        public StatusPedidoDevePossuirDescricaoUnicaSpecification(IStatusPedidoRepositorio statusPedidoRepositorio)
        {
            _statusPedidoRepositorio = statusPedidoRepositorio;
        }

        public bool IsSatisfiedBy(StatusPedido statusPedido)
        {
            return _statusPedidoRepositorio.ObterPorDescricao(statusPedido.Descricao) == null;
        }
    }
}
