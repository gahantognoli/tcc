using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Produtos
{
    public class ProdutoDevePossuirPrecoMaiorDoQueZeroSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto produto)
        {
            return produto.Preco > 0;
        }
    }
}
