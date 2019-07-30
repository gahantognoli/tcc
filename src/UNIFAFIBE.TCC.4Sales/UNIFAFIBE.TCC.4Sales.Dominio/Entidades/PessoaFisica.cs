using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.PessoasFisicas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class PessoaFisica : Cliente
    {
        public string Nome { get; set; }
        private string _cpf { get; set; }
        public string CPF
        {
            get
            {
                return _cpf;
            }
            set
            {
                _cpf = value;
            }
        }

        public bool EhValido(IPessoaFisicaRepositorio pessoaFisicaRepositorio)
        {
            if (this.EstaConsistente())
                return this.EstaApto(pessoaFisicaRepositorio);

            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new PessoaFisicaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IPessoaFisicaRepositorio pessoaFisicaRepositorio)
        {
            ValidationResult = new PessoaFisicaEstaAptaValidation(pessoaFisicaRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
