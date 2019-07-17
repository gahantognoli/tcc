using DomainValidation.Validation;
using System;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class MetaViewModel
    {
        public Guid MetaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
