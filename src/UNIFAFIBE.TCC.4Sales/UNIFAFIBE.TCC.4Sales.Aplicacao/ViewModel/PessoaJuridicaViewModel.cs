using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PessoaJuridicaViewModel : ClienteViewModel
    {
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string RazaoSocial { get; set; }
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

        public string _cnpj;
        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Tamanho deve ser de 18 caracteres")]
        public string CNPJ { get; set; }

    }
}
