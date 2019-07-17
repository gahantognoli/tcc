using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Faturamentos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Faturamentos
{
    public class FaturamentoEstaConsistenteValidation : Validator<Faturamento>
    {
        public FaturamentoEstaConsistenteValidation()
        {
            var parcelas = new FaturamentoDevePossuirPeloMenosUmaParcelaSpecification();
            var valor = new FaturamentoValorDeveSerMenorQueValorDoPedidoSpecification();
            var valorFaturamento = new FaturamentoValorNaoPodeSerZeroSpecification();
            var statusPedidoFaturamento = new FaturamentoDevePossuirStatusDiferenteDeFaturadoSpecification();
            var valorTotalParcelasFaturamento = new ValorTotalParcelasDeveSerMenorOuIgualAoValorFaturamentoSpecification();

            this.Add("SemParcelas", new Rule<Faturamento>(parcelas, "O Faturamento não possui nenhuma parcela!"));
            this.Add("ValorFaturamentoMaiorQuePedido", new Rule<Faturamento>(valor, "O valor do faturamento não pode ser maior que o valor do pedido!"));
            this.Add("ValorZerado", new Rule<Faturamento>(valorFaturamento, "O valor faturado não pode ser zero!"));
            this.Add("StatusDiferenteDeFaturado", new Rule<Faturamento> (statusPedidoFaturamento, "O Pedido já foi totalmente faturado!"));
            this.Add("ValorTotalParcelasFaturamento", new Rule<Faturamento>(valorTotalParcelasFaturamento, "A Soma das parcelas não pode ultrapassar o valor total do faturamento!"));
        }
    }
}
