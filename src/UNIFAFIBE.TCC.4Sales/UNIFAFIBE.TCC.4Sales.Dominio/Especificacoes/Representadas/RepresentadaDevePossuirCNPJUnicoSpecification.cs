using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Representadas
{
    public class RepresentadaDevePossuirCNPJUnicoSpecification : ISpecification<Representada>
    {
        private readonly IRepresentadaRepositorio _representadaRepositorio;

        public RepresentadaDevePossuirCNPJUnicoSpecification(IRepresentadaRepositorio representadaRepositorio)
        {
            _representadaRepositorio = representadaRepositorio;
        }

        public bool IsSatisfiedBy(Representada representada)
        {
            return _representadaRepositorio.ObterPorCnpj(representada.CNPJ) == null;
        }
    }
}
