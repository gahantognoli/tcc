using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Usuarios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Usuarios
{
    public class UsuarioEstaConsistenteValidation : Validator<Usuario>
    {
        public UsuarioEstaConsistenteValidation()
        {
            var email = new UsuarioDevePossuirEmailValidoSpecification();
            var senha = new UsuarioDevePossuirSenhaComPeloMenosOitoCaracteresSpecification();

            this.Add("EmailInvalido", new Rule<Usuario>(email, "Endereço de E-mail inválido!"));
            this.Add("SenhaFraca", new Rule<Usuario>(senha, "Senha deve possui pelo menos 8 caracteres!"));
        }
    }
}
