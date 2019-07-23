using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.TiposPedido
{
    public class TipoPedidoDevePossuirDescricaoUnicaSpecification : ISpecification<TipoPedido>
    {
        private readonly ITipoPedidoRepositorio _tipoPedidoRepositorio;

        public TipoPedidoDevePossuirDescricaoUnicaSpecification(ITipoPedidoRepositorio tipoPedidoRepositorio)
        {
            _tipoPedidoRepositorio = tipoPedidoRepositorio;
        }

        public bool IsSatisfiedBy(TipoPedido tipoPedido)
        {
            return _tipoPedidoRepositorio.ObterPorDescricao(tipoPedido.Descricao).FirstOrDefault() == null;
        }
    }
}
