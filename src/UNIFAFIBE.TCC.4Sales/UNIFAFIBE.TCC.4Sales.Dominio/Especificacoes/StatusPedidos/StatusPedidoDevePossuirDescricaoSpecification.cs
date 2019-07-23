using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.StatusPedidos
{
    public class StatusPedidoDevePossuirDescricaoSpecification : ISpecification<StatusPedido>
    {
        public bool IsSatisfiedBy(StatusPedido statusPedido)
        {
            return !string.IsNullOrEmpty(statusPedido.Descricao.Trim());
        }
    }
}
