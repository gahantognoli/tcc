using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Metas
{
    public class MetaDevePossuirPeriodoUnicoSpecification : ISpecification<Meta>
    {
        private readonly IMetaRepositorio _metaRepositorio;
        public MetaDevePossuirPeriodoUnicoSpecification(IMetaRepositorio metaRepositorio)
        {
            _metaRepositorio = metaRepositorio;
        }

        public bool IsSatisfiedBy(Meta meta)
        {
            return _metaRepositorio.ObterPorPeriodo(meta.Ano, meta.Mes).Count() == 0;
        }
    }
}
