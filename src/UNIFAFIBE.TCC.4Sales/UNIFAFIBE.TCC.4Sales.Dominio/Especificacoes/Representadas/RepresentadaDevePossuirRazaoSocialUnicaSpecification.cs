using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Representadas
{
    public class RepresentadaDevePossuirRazaoSocialUnicaSpecification : ISpecification<Representada>
    {
        private readonly IRepresentadaRepositorio _representadaRepositorio;

        public RepresentadaDevePossuirRazaoSocialUnicaSpecification(IRepresentadaRepositorio representadaRepositorio)
        {
            _representadaRepositorio = representadaRepositorio;
        }

        public bool IsSatisfiedBy(Representada representada)
        {
            return _representadaRepositorio.ObterPorRazaoSocial(representada.RazaoSocial) == null;
        }
    }
}
