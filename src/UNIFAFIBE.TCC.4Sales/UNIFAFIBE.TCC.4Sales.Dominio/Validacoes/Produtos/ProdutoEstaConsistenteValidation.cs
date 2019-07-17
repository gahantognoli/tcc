using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Produtos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Produtos
{
    public class ProdutoEstaConsistenteValidation : Validator<Produto>
    {
        public ProdutoEstaConsistenteValidation()
        {
            var preco = new ProdutoDevePossuirPrecoMaiorDoQueZeroSpecification();
            this.Add("PrecoInvalido", new Rule<Produto>(preco, "Preço deve ser maior do que zero."));
        }
    }
}
