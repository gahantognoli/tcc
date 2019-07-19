using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PessoaJuridicaViewModel : ClienteViewModel
    {
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "Preencha o campo SUFRAMA")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo de 20 caracteres")]
        public string SUFRAMA { get; set; }
        [Display(Name = "Inscrição Estadual")]
        [Required(ErrorMessage = "Preencha o campo Inscrição Estadual")]
        [MinLength(12, ErrorMessage = "Tamanho mínimo de 12 caracteres")]
        [MaxLength(12, ErrorMessage = "Tamanho máximo de 12 caracteres")]
        public string InscricaoEstadual { get; set; }
        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MinLength(14, ErrorMessage = "Tamanho mínimo de 14 caracteres")]
        [MaxLength(14, ErrorMessage = "Tamanho máximo de 14 caracteres")]
        public string CNPJ { get; set; }
    }
}
