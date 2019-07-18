using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PessoaJuridicaViewModel : ClienteViewModel
    {
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        public string SUFRAMA { get; set; }
        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}
