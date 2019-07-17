using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Representadas
{
    public class RepresentadaDevePossuirEmailValidoSpecification : ISpecification<Representada>
    {
        public bool IsSatisfiedBy(Representada representada)
        {
            return Regex.IsMatch(representada.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
