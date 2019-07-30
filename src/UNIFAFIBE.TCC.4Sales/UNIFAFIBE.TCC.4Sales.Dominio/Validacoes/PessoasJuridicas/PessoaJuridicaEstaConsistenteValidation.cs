using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasJuridicas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.PessoasJuridicas
{
    public class PessoaJuridicaEstaConsistenteValidation : Validator<PessoaJuridica>
    {
        public PessoaJuridicaEstaConsistenteValidation()
        {
            var cnpj = new PessoaJuridicaDevePossuirCNPJValidoSpecification();

            this.Add("CPNJInvalido", new Rule<PessoaJuridica>(cnpj, "CPNJ informado inválido!"));
        }
    }
}
