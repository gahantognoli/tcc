using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PessoaFisicaViewModel : ClienteViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Tamanho deve possuir 14 caracteres")]
        public string CPF { get; set; }
    }
}
