using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class SegmentoViewModel
    {
        public Guid SegmentoId { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<ClienteViewModel> Clientes { get; set; }


        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
