using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Usuarios
{
    class UsuarioDevePossuirSenhaComPeloMenosOitoCaracteresSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return usuario.Senha.Length >= 8;
        }
    }
}
