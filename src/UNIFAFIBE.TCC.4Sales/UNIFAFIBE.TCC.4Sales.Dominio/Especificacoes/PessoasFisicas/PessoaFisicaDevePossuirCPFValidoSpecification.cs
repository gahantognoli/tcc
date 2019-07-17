using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasFisicas
{
    class PessoaFisicaDevePossuirCPFValidoSpecification : ISpecification<PessoaFisica>
    {
        public bool IsSatisfiedBy(PessoaFisica pessoaFisica)
        {
            return this.ValidarCPF(pessoaFisica.CPF);
        }

        public bool ValidarCPF(string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        }
    }
}
