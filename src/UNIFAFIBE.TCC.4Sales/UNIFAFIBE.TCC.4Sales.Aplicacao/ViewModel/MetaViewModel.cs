using DomainValidation.Validation;
using System;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class MetaViewModel
    {
        public Guid MetaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.Erros.Count() == 0;
        }
    }
}
