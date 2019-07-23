using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.TiposPedido
{
    public class TipoPedidoDevePossuirDescricaoSpecification : ISpecification<TipoPedido>
    {
        public bool IsSatisfiedBy(TipoPedido tipoPedido)
        {
            return !string.IsNullOrEmpty(tipoPedido.Descricao.Trim());
        }
    }
}
