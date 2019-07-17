using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.ContatosCliente;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.ContatosCliente
{
    public class ContatoClienteEstaConsistenteValidation : Validator<ContatoCliente>
    {
        public ContatoClienteEstaConsistenteValidation()
        {
            var email = new ContatoClienteDevePossuirEmailValidoSpecification();
            this.Add("EmailInvalido", new Rule<ContatoCliente>(email, "Endereço de E-mail inválido!"));
        }
    }
}
