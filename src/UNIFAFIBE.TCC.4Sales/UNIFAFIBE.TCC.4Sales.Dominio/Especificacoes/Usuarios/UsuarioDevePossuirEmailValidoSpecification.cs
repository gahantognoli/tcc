using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Usuarios
{
    public class UsuarioDevePossuirEmailValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return Regex.IsMatch(usuario.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
