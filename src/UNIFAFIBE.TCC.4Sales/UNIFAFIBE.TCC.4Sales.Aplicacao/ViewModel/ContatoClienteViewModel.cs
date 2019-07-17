using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ContatoClienteViewModel
    {
        public Guid ContatoClienteId { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Guid ClienteId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}
