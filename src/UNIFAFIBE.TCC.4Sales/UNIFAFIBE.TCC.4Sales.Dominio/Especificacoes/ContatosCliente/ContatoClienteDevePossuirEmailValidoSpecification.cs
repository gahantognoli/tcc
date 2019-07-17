using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.ContatosCliente
{
    public class ContatoClienteDevePossuirEmailValidoSpecification : ISpecification<ContatoCliente>
    {
        public bool IsSatisfiedBy(ContatoCliente contatoCliente)
        {
            return Regex.IsMatch(contatoCliente.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
