using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Usuarios
{
    public class UsuarioDevePossuirEmailUnicoSpecification : ISpecification<Usuario>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioDevePossuirEmailUnicoSpecification(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepositorio.ObterPorEmail(usuario.Email) == null;
        }
    }
}
