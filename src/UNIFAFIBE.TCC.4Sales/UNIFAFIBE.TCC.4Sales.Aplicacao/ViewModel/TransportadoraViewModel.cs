using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class TransportadoraViewModel
    {
        public TransportadoraViewModel()
        {
            TransportadoraId = new Guid();
        }

        [Key]
        public Guid TransportadoraId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MinLength(2, ErrorMessage = "Tamanho mínimo de 2 caracteres")]
        [MaxLength(2, ErrorMessage = "Tamanho máximo de 2 caracteres")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo de 20 caracteres")]
        public string Telefone { get; set; }
        [Display(Name = "Informações Adicionais")]
        [Required(ErrorMessage = "Preencha o campo Informações Adicionais")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres")]
        public string InformacoesAdicionais { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
