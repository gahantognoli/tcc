using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.ContatosRepresentada;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.ContatosRepresentada
{
    public class ContatoRepresentadaEstaConsistenteValidation : Validator<ContatoRepresentada>
    {
        public ContatoRepresentadaEstaConsistenteValidation()
        {
            var email = new ContatoRepresentadaDevePossuirEmailValidoSpecification();
            this.Add("EmailDuplicado", new Rule<ContatoRepresentada>(email, "Endereço de E-mail inválido!"));
        }
    }
}
