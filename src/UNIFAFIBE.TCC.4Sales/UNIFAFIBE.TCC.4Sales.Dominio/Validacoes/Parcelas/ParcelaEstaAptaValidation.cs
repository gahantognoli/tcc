using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Parcelas;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Parcelas
{
    public class ParcelaEstaAptaValidation : Validator<Parcela>
    {
        public ParcelaEstaAptaValidation(IFaturamentoRepositorio faturamentoRepositorio)
        {
            var valorTotal = new ParcelaDeveSerMenorDoQueValorDoFaturamentoSpecification(faturamentoRepositorio);
            this.Add("ValorParcelaInvalido", new Rule<Parcela>(valorTotal, "Valor da parcela é maior que o valor do pedido"));
        }
    }
}
