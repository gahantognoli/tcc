using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Segmentos
{
    public class SegmentoDevePossuirDescricaoSpecification : ISpecification<Segmento>
    {
        public bool IsSatisfiedBy(Segmento segmento)
        {
            return !string.IsNullOrEmpty(segmento.Descricao.Trim());
        }
    }
}
