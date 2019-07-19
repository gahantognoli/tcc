using System;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class UsuarioRepresentadaViewModel
    {
        public UsuarioRepresentadaViewModel()
        {
            UsuarioRepresentadaId = new Guid();
        }

        [Key]
        public Guid UsuarioRepresentadaId { get; set; }
        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }
        [ScaffoldColumn(false)]
        public Guid RepresentadaId { get; set; }
        [Display(Name = "Comissão")]
        [Range(0, 9999999999999999.99)]
        [Required(ErrorMessage = "Preencha o campo Comissão")]
        public decimal Comissao { get; set; }
        [Display(Name = "Valor máximo de desconto")]
        [Required(ErrorMessage = "Preencha o campo Valor Máximo de Desconto")]
        [Range(0, 9999999999999999.99)]
        public decimal ValorMaximoDesconto { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual RepresentadaViewModel Representada { get; set; }
    }
}
