using DomainValidation.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class MetaViewModel
    {
        public MetaViewModel()
        {
            MetaId = new Guid();
        }

        [Key]
        public Guid MetaId { get; set; }
        [Range(0, 9999999999999999.99)]
        [Required(ErrorMessage = "Preencha o campo Valor")]
        public decimal Valor { get; set; }
        [Display(Name = "Data Início")]
        [Required(ErrorMessage = "Preencha o campo Data Início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data Fim")]
        [Required(ErrorMessage = "Preencha o campo Data Fim")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataFim { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
