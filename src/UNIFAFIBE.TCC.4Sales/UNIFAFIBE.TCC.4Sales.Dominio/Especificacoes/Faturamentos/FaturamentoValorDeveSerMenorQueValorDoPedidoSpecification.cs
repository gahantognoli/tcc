using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Faturamentos
{
    public class FaturamentoValorDeveSerMenorQueValorDoPedidoSpecification : ISpecification<Faturamento>
    {
        public bool IsSatisfiedBy(Faturamento faturamento)
        {
            return  faturamento.Valor <= faturamento.Pedido.ValorTotal;
        }
    }
}
