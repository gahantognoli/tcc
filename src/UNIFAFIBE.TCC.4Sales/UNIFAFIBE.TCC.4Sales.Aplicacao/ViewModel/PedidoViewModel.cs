using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PedidoViewModel
    {
        public Guid PedidoId { get; set; }
        [Display(Name = "Número Pedido")]
        public int NumeroPedido { get; set; }
        [Display(Name = "Data Emissão")]
        public DateTime DataEmissao { get; set; }
        [Display(Name = "Endereço Entrega")]
        public string EnderecoEntrega { get; set; }
        public string Contato { get; set; }
        [Display(Name = "Quantidade Total de Itens")]
        public int QuantidadeTotalItens { get; set; }
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }
        public Guid RepresentadaId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid CondicaoPagamentoId { get; set; }
        public Guid TransportadoraId { get; set; }
        public Guid StatusPedidoId { get; set; }
        public Guid TipoPedidoId { get; set; }
        public Guid UsuarioId { get; set; }
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
            return this.ValidationResult.Erros.Count() == 0;
        }
    }
}
