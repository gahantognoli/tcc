using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasFisicas
{
    public class PessoaFisicaDevePossuirCPFUnicoSpecification : ISpecification<PessoaFisica>
    {
        private readonly IPessoaFisicaRepositorio _pessoaFisicaRepositorio;
        public PessoaFisicaDevePossuirCPFUnicoSpecification(IPessoaFisicaRepositorio pessoaFisicaRepositorio)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
        }

        public bool IsSatisfiedBy(PessoaFisica pessoaFisica)
        {
            return _pessoaFisicaRepositorio.ObterPorCPF(pessoaFisica.CPF) == null;
        }
    }
}
