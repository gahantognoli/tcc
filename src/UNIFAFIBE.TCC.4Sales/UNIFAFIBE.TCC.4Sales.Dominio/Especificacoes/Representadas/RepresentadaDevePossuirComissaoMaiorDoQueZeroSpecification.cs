using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Representadas
{
    public class RepresentadaDevePossuirComissaoMaiorDoQueZeroSpecification : ISpecification<Representada>
    {
        public bool IsSatisfiedBy(Representada representada)
        {
            return representada.Comissao > 0 && representada.Comissao <= 100;
        }
    }
}
