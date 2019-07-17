using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.ItensPedido
{
    public class ItemPedidoQuantidadeDeveSerMaiorQueZero : ISpecification<ItemPedido>
    {
        public bool IsSatisfiedBy(ItemPedido itemPedido)
        {
            return itemPedido.Quantidade > 0;
        }
    }
}
