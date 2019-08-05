using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Produtos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Produtos
{
    public class ProdutoEstaAptoValidation : Validator<Produto>
    {
        public ProdutoEstaAptoValidation(IProdutoRepositorio produtoRepositorio)
        {
            var codigo = new ProdutoDevePossuirCodigoUnicoSpecification(produtoRepositorio);
            this.Add("CodigoDuplicado", new Rule<Produto>(codigo, "Código do produto já cadastrado!"));
        }
    }
}
