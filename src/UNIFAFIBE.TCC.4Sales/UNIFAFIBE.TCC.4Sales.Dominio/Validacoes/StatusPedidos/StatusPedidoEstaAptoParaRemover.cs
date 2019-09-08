using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.StatusPedidos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.StatusPedidos
{
    public class StatusPedidoEstaAptoParaRemover : Validator<StatusPedido>
    {
        public StatusPedidoEstaAptoParaRemover(IPedidoRepositorio pedidoRepositorio)
        {
            var pedidos = new StatusPedidoNaoDevePossuirPedidosVinculadosSpecification(pedidoRepositorio);

            this.Add("StatusPossuiPedidosVinculados", new Rule<StatusPedido>(pedidos,
                "Esse status possui pedidos vinculados a ele, remova-os e tente novamente."));
        }
    }
}
