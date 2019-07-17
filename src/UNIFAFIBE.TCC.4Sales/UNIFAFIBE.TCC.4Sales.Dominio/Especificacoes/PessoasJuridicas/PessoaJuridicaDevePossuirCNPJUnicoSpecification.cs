using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasJuridicas
{
    public class PessoaJuridicaDevePossuirCNPJUnicoSpecification : ISpecification<PessoaJuridica>
    {
        private readonly IPessoaJuridicaRepositorio _pessoaJuridicaRepositorio;

        public PessoaJuridicaDevePossuirCNPJUnicoSpecification(IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            _pessoaJuridicaRepositorio = pessoaJuridicaRepositorio;
        }

        public bool IsSatisfiedBy(PessoaJuridica pessoaJuridica)
        {
            return _pessoaJuridicaRepositorio.ObterPorCPNJ(pessoaJuridica.CNPJ) == null;
        }
    }
}
