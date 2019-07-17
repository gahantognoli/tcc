using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.ContatosRepresentada
{
    public class ContatoRepresentadaDevePossuirEmailValidoSpecification : ISpecification<ContatoRepresentada>
    {
        public bool IsSatisfiedBy(ContatoRepresentada contatoRepresentada)
        {
            return Regex.IsMatch(contatoRepresentada.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
