using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasJuridicas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.PessoasJuridicas
{
    public class PessoaJuridicaEstaConsistenteValidation : Validator<PessoaJuridica>
    {
        public PessoaJuridicaEstaConsistenteValidation()
        {
            var email = new PessoaJuridicaDevePossuirCNPJValidoSpecification();

            this.Add("EmailInvalido", new Rule<PessoaJuridica>(email, "Endereço de E-mail inválido!"));
        }
    }
}
