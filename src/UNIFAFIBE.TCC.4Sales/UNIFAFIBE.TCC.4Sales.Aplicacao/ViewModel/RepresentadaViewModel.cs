using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class RepresentadaViewModel
    {
        public RepresentadaViewModel()
        {
            RepresentadaId = Guid.NewGuid();
            CondicoesPagamento = new List<CondicaoPagamentoViewModel>();
            ContatosRepresentada = new List<ContatoRepresentadaViewModel>();
        }

        [Key]
        public Guid RepresentadaId { get; set; }
        private string _cnpj;
        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Tamanho deve ser de 18 caracteres")]
        public string CNPJ
        {
            get
            {
                return _cnpj;
            }
            set
            {
                _cnpj = value.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty);
            }
        }
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome Fantasia")]
        //[Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string NomeFantasia { get; set; }
        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um Email válido")]
        public string Email { get; set; }
        [Display(Name = "Comissão")]
        [Required(ErrorMessage = "Preencha o campo Comissão")]
        [Range(0.01, 100)]
        public decimal Comissao { get; set; }

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
        public virtual ICollection<UsuarioViewModel> Usuarios { get; set; }
        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
        public virtual ICollection<CondicaoPagamentoViewModel> CondicoesPagamento { get; set; }
        public virtual ICollection<ContatoRepresentadaViewModel> ContatosRepresentada { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
