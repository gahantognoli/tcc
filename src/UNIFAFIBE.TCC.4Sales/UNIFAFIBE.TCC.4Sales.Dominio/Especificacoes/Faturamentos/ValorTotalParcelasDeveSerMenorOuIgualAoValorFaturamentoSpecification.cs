using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Faturamentos
{
    public class ValorTotalParcelasDeveSerMenorOuIgualAoValorFaturamentoSpecification : ISpecification<Faturamento>
    {
        public bool IsSatisfiedBy(Faturamento faturamento)
        {
            var valorTotalParcelas = 0.0M;

            foreach(var parcela in faturamento.Parcelas)
            {
                valorTotalParcelas += parcela.ValorParcela;
            }

            return valorTotalParcelas <= faturamento.Valor;
        }
    }
}
