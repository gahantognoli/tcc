using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            PedidoId = new Guid();
        }

        [Key]
        public Guid PedidoId { get; set; }
        [Display(Name = "Nº do Pedido")]
        [Required(ErrorMessage = "Preencha o campo Nº do Pedido")]
        public int NumeroPedido { get; set; }
        [Display(Name = "Data Emissão")]
        [Required(ErrorMessage = "Preencha o campo Data de Emissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataEmissao { get; set; }
        [Display(Name = "Endereço Entrega")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo 200 caracteres")]
        public string EnderecoEntrega { get; set; }
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        public string Contato { get; set; }
        [Display(Name = "Quantidade Total de Itens")]
        [Required(ErrorMessage = "Preencha o campo Quantidade Total de Itens")]
        public int QuantidadeTotalItens { get; set; }
        [Display(Name = "Valor Total")]
        [Range(0, 9999999999999999.99)]
        [Required(ErrorMessage = "Preencha o campo Valor Total")]
        public decimal ValorTotal { get; set; }
        [ScaffoldColumn(false)]
        public Guid RepresentadaId { get; set; }
        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }
        [ScaffoldColumn(false)]
        public Guid CondicaoPagamentoId { get; set; }
        [ScaffoldColumn(false)]
        public Guid TransportadoraId { get; set; }
        [ScaffoldColumn(false)]
        public Guid StatusPedidoId { get; set; }
        [ScaffoldColumn(false)]
        public Guid TipoPedidoId { get; set; }
        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
        public virtual CondicaoPagamentoViewModel CondicaoPagamento { get; set; }
        public virtual TransportadoraViewModel Transportadora { get; set; }
        public virtual StatusPedidoViewModel StatusPedido { get; set; }
        public virtual TipoPedidoViewModel TipoPedido { get; set; }
        public virtual RepresentadaViewModel Representada { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual ICollection<FaturamentoViewModel> Faturamentos { get; set; }
        public virtual ICollection<ItemPedidoViewModel> ItensPedido { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
