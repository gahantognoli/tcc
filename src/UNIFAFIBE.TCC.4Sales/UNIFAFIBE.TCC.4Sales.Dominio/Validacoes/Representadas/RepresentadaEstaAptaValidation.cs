using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Representadas;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Representadas
{
    public class RepresentadaEstaAptaValidation : Validator<Representada>
    {
        public RepresentadaEstaAptaValidation(IRepresentadaRepositorio representadaRepositorio)
        {
            var cnpj = new RepresentadaDevePossuirCNPJUnicoSpecification(representadaRepositorio);
            var razaoSocial = new RepresentadaDevePossuirRazaoSocialUnicaSpecification(representadaRepositorio);

            this.Add("CNPJDuplicado", new Rule<Representada>(cnpj, "Esse CNPJ já está em uso!"));
            this.Add("RazaoSocialDuplicada", new Rule<Representada>(razaoSocial, "Razão social inválida!"));
        }
    }
}
