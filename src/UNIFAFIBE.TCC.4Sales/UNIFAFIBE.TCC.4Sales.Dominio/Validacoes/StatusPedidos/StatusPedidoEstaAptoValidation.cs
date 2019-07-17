using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.StatusPedidos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.StatusPedidos
{
    public class StatusPedidoEstaAptoValidation : Validator<StatusPedido>
    {
        public StatusPedidoEstaAptoValidation(IStatusPedidoRepositorio statusPedidoRepositorio)
        {
            var descricao = new StatusPedidoDevePossuirDescricaoUnicaSpecification(statusPedidoRepositorio);

            this.Add("DescricaoDuplicada", new Rule<StatusPedido>(descricao, "Esse status de pedido já está em uso!"));
        }
    }
}
