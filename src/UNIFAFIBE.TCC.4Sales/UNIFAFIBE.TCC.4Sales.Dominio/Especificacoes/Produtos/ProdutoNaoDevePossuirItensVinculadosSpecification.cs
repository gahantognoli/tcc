using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Produtos
{
    public class ProdutoNaoDevePossuirItensVinculadosSpecification : ISpecification<Produto>
    {
        private readonly IItemPedidoRepositorio _itemPedidoRepositorio;
        public ProdutoNaoDevePossuirItensVinculadosSpecification(IItemPedidoRepositorio itemPedidoRepositorio)
        {
            _itemPedidoRepositorio = itemPedidoRepositorio;
        }

        public bool IsSatisfiedBy(Produto produto)
        {
            return _itemPedidoRepositorio.ObterPorProduto(produto.ProdutoId).Count() == 0;
        }
    }
}
