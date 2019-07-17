using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasFisicas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.PessoasFisicas
{
    public class PessoaFisicaEstaConsistenteValidation : Validator<PessoaFisica>
    {
        public PessoaFisicaEstaConsistenteValidation()
        {
            var cpf = new PessoaFisicaDevePossuirCPFValidoSpecification();
            this.Add("CPFInvalido", new Rule<PessoaFisica>(cpf, "CPF inválido"));
        }
    }
}
