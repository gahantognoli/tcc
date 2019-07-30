using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasJuridicas
{
    public class PessoaJuridicaDevePossuirRazaoSocialUnicaSpecification : ISpecification<PessoaJuridica>
    {
        private readonly IPessoaJuridicaRepositorio _pessoaJuridicaRepositorio;

        public PessoaJuridicaDevePossuirRazaoSocialUnicaSpecification(IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            _pessoaJuridicaRepositorio = pessoaJuridicaRepositorio;
        }

        public bool IsSatisfiedBy(PessoaJuridica pessoaJuridica)
        {
            return _pessoaJuridicaRepositorio.ObterPorRazaoSocial(pessoaJuridica.RazaoSocial).FirstOrDefault() == null;
        }
    }
}
