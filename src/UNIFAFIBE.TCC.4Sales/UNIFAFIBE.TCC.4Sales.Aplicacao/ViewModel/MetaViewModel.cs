using System;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class MetaViewModel
    {
        public MetaViewModel()
        {
            MetaId = Guid.NewGuid();
        }

        [Key]
        public Guid MetaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Valor")]
        public decimal Valor { get; set; }
        
        [Display(Name = "Mês")]
        [Required(ErrorMessage = "Preencha o campo Mês")]
        public string Mes { get; set; }

        [Display(Name = "Ano")]
        [Required(ErrorMessage = "Preencha o campo Ano")]
        public string Ano { get; set; }
        
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
