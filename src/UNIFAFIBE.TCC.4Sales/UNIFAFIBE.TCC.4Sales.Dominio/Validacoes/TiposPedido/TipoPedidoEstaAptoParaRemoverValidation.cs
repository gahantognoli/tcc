using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.TiposPedido;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.TiposPedido
{
    public class TipoPedidoEstaAptoParaRemoverValidation : Validator<TipoPedido>
    {
        public TipoPedidoEstaAptoParaRemoverValidation(IPedidoRepositorio pedidoRepositorio)
        {
            var pedidos = new TipoPedidoNaoDevePossuirPedidosVinculadosSpecification(pedidoRepositorio);

            this.Add("TipoPedidoPossuiPedidosVinculado", new Rule<TipoPedido>(pedidos,
                "Esse tipo de pedido está vinculado com um ou alguns pedidos, remova-os e tente novamente."));
        }
    }
}
