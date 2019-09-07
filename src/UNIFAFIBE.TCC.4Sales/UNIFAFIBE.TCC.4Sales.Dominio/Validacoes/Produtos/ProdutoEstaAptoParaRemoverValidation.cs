using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Produtos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Produtos
{
    public class ProdutoEstaAptoParaRemoverValidation : Validator<Produto>
    {
        public ProdutoEstaAptoParaRemoverValidation(IItemPedidoRepositorio itemPedidoRepositorio)
        {
            var itemPedido = new ProdutoNaoDevePossuirItensVinculadosSpecification(itemPedidoRepositorio);

            this.Add("produtoPossuiItensPedidoVinculados", new Rule<Produto>(itemPedido, "Esse produto está vinculado a um ou mais pedidos, " +
                "remova-os e tente novamente"));
        }
    }
}
