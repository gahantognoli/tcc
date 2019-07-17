using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.TiposPedido;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.TiposPedido
{
    public class TipoPedidoEstaAptoValidation : Validator<TipoPedido>
    {
        public TipoPedidoEstaAptoValidation(ITipoPedidoRepositorio tipoPedidoRepositorio)
        {
            var descricao = new TipoPedidoDevePossuirDescricaoUnicaSpecification(tipoPedidoRepositorio);

            this.Add("DescricaoDuplicada", new Rule<TipoPedido>(descricao, "Esse tipo de pedido já está em uso!"));
        }
    }
}
