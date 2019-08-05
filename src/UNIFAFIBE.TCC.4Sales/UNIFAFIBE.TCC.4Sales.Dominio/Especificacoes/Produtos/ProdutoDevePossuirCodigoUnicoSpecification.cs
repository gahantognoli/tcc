using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Produtos
{
    public class ProdutoDevePossuirCodigoUnicoSpecification : ISpecification<Produto>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoDevePossuirCodigoUnicoSpecification(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public bool IsSatisfiedBy(Produto produto)
        {
            return _produtoRepositorio.ObterPorCodigo(produto.Codigo, produto.RepresentadaId) == null;
        }
    }
}
