using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class RepresentadaViewModel
    {
        public RepresentadaViewModel()
        {
            RepresentadaId = new Guid();
        }

        [Key]
        public Guid RepresentadaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MinLength(14, ErrorMessage = "Tamanho mínimo de 14 caracteres")]
        [MaxLength(14, ErrorMessage = "Tamanho máximo de 14 caracteres")]
        public string CNPJ { get; set; }
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string NomeFantasia { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }
        [Display(Name = "Comissão")]
        [Required(ErrorMessage = "Preencha o campo Comissão")]
        [Range(0, 9999999999999999.99)]
        public decimal Comissao { get; set; }
        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo de 20 caracteres")]
        public string Telefone { get; set; }
        [DataType(DataType.Upload)]
        public string Foto { get; set; }
        [Display(Name = "Informações Adicionais")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres")]
        public string InformacoesAdicionais { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
        public virtual ICollection<UsuarioRepresentadaViewModel> UsuariosRepresentadas { get; set; }
        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
        public virtual ICollection<CondicaoPagamentoViewModel> CondicoesPagamento { get; set; }
        public virtual ICollection<ContatoRepresentadaViewModel> ContatosRepresentada { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
