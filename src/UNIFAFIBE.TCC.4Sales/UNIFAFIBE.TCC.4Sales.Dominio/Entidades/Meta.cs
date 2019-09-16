using DomainValidation.Validation;
using System;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Metas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Meta
    {
        public Meta()
        {
            MetaId = Guid.NewGuid();
        }

        public Guid MetaId { get; set; }
        public decimal Valor { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool EhValido(IMetaRepositorio metaRepositorio)
        {
            if (this.EstaConsistente())
                return EstaApto(metaRepositorio);

            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new MetaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IMetaRepositorio metaRepositorio)
        {
            ValidationResult = new MetaEstaAptaValidation(metaRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
