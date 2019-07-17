using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Usuarios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Usuarios
{
    public class UsuarioEstaAptoValidation : Validator<Usuario>
    {
        public UsuarioEstaAptoValidation(IUsuarioRepositorio usuarioRepositorio)
        {
            var email = new UsuarioDevePossuirEmailUnicoSpecification(usuarioRepositorio);
            this.Add("EmailDuplicado", new Rule<Usuario>(email, "Esse e-mail já está em uso!"));
        }
    }
}
