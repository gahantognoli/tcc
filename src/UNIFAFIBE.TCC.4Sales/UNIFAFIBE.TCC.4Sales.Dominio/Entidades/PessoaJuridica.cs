using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.PessoasJuridicas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class PessoaJuridica : Cliente
    {
        public string RazaoSocial { get; set; }
        public string SUFRAMA { get; set; }
        public string InscricaoEstadual { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        public bool EhValido(IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            if (this.EstaConsistente())
                return this.EstaApto(pessoaJuridicaRepositorio);

            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new PessoaJuridicaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            ValidationResult = new PessoaJuridicaEstaAptaValidation(pessoaJuridicaRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
