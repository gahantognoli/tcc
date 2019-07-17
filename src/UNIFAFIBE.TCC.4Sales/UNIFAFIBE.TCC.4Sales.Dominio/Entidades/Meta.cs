using DomainValidation.Validation;
using System;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Metas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Meta
    {
        public Meta()
        {
            MetaId = new Guid();
        }

        public Guid MetaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            return this.EstaConsistente();
        }

        public bool EstaConsistente()
        {
            ValidationResult = new MetaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto()
        {
            return true;
        }
    }
}
