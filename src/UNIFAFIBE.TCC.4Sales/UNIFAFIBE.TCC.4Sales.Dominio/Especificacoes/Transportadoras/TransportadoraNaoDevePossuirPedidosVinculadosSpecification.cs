using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Transportadoras
{
    class TransportadoraNaoDevePossuirPedidosVinculadosSpecification : ISpecification<Transportadora>
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public TransportadoraNaoDevePossuirPedidosVinculadosSpecification(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }
        public bool IsSatisfiedBy(Transportadora transportadora)
        {
            return _pedidoRepositorio.ObterPorTransportadora(transportadora.TransportadoraId).Count() == 0;
        }
    }
}
