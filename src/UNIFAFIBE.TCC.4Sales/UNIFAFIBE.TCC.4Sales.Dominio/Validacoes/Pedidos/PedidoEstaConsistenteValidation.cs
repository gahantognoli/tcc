using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Pedidos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Pedidos
{
    public class PedidoEstaConsistenteValidation : Validator<Pedido>
    {
        public PedidoEstaConsistenteValidation()
        {
            var itens = new PedidoDevePossuirItensSpecification();
            var cliente = new PedidoDevePossuirClienteSpecification();
            var condicaoPagamento = new PedidoDevePossuirCondicaoPagamentoSpecification();
            var representada = new PedidoDevePossuirRepresentadaSpecification();
            var status = new PedidoDevePossuirStatusSpecification();
            var tipoPedido = new PedidoDevePossuirTipoPedidoSpecification();
            var transportadora = new PedidoDevePossuirTransportadoraSpecification();
            var vendedor = new PedidoDevePossuirVendedorSpecification();

            this.Add("PedidoItens", new Rule<Pedido>(itens, "O Pedido não possui nenhum item!"));
            this.Add("ClienteVazio", new Rule<Pedido>(cliente, "O Pedido não possui um Cliente!"));
            this.Add("CondicaoPagamentoVazia", new Rule<Pedido>(condicaoPagamento, "O Pedido não possui uma Condição de Pagamento!"));
            this.Add("RepresentadaVazia", new Rule<Pedido>(representada, "O Pedido não possui uma Representada!"));
            this.Add("StatusVazio", new Rule<Pedido>(status, "O Pedido não possui um Status!"));
            this.Add("TipoVazio", new Rule<Pedido>(tipoPedido, "O Pedido não possui um Tipo!"));
            this.Add("TransportadoraVazia", new Rule<Pedido>(transportadora, "O Pedido não possui uma Transportadora!"));
            this.Add("VendedorVazio", new Rule<Pedido>(vendedor, "O Pedido não possui um Vendedor!"));
        }
    }
}
