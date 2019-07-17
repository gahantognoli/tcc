using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Pedidos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Pedidos
{
    public class PedidoEstaAptoValidation : Validator<Pedido>
    {
        public PedidoEstaAptoValidation(IPedidoRepositorio pedidoRepositorio)
        {
            var numeroPedido = new PedidoDevePossuirNumeroUnicoSpecification(pedidoRepositorio);
            this.Add("PedidoDuplicado", new Rule<Pedido>(numeroPedido, "Numero de pedido já foi utilizado!"));
        }
    }
}
