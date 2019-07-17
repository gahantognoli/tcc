using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasFisicas;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.PessoasFisicas
{
    public class PessoaFisicaEstaAptaValidation : Validator<PessoaFisica>
    {
        public PessoaFisicaEstaAptaValidation(IPessoaFisicaRepositorio pessoaFisicaRepositorio)
        {
            var email = new PessoaFisicaDevePossuirCPFUnicoSpecification(pessoaFisicaRepositorio);

            this.Add("EmailDuplicado", new Rule<PessoaFisica>(email, "Endereço de E-mail já está em uso!"));
        }
    }
}
