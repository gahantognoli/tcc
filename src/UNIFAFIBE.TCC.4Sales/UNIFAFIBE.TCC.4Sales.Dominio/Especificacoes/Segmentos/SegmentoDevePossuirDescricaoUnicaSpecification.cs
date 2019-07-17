using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Segmentos
{
    public class SegmentoDevePossuirDescricaoUnicaSpecification : ISpecification<Segmento>
    {
        private readonly ISegmentoRepositorio _segmentoRepositorio;

        public SegmentoDevePossuirDescricaoUnicaSpecification(ISegmentoRepositorio segmentoRepositorio)
        {
            _segmentoRepositorio = segmentoRepositorio;
        }

        public bool IsSatisfiedBy(Segmento segmento)
        {
            return _segmentoRepositorio.ObterPorDescricao(segmento.Descricao) == null;
        }
    }
}
