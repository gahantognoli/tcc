using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Metas
{
    public class MetaDeveSerMaiorQueDoQueZeroSpecification : ISpecification<Meta>
    {
        public bool IsSatisfiedBy(Meta meta)
        {
            return meta.Valor > 0;
        }
    }
}
