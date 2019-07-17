using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Representadas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Representadas
{
    public class RepresentadaEstaConsistenteValidation : Validator<Representada>
    {
        public RepresentadaEstaConsistenteValidation()
        {
            var email = new RepresentadaDevePossuirEmailValidoSpecification();
            var cnpj = new RepresentadaDevePossuirCNPJValidoSpecification();
            var comissao = new RepresentadaDevePossuirComissaoMaiorDoQueZeroSpecification();

            this.Add("EmailInvalido", new Rule<Representada>(email, "Endereço de E-mail inválido!"));
            this.Add("CPNJInvalido", new Rule<Representada>(cnpj, "CNPJ inválido!"));
            this.Add("ComissaoInvalida", new Rule<Representada>(comissao, "Comissão inválida. O valor deve " +
                "estar entre 0 e 100%"));
        }
    }
}
