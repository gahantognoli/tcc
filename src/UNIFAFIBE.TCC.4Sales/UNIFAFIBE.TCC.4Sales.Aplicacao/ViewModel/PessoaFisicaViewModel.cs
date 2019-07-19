using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PessoaFisicaViewModel : ClienteViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MinLength(11, ErrorMessage = "Tamanho mínimo de 11 caracteres")]
        [MaxLength(11, ErrorMessage = "Tamanho máximo de 11 caracteres")]
        public string CPF { get; set; }
    }
}
