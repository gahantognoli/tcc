using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            PedidoId = new Guid();
        }

        public Guid PedidoId { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime DataEmissao { get; set; }
        public string EnderecoEntrega { get; set; }
        public string Contato { get; set; }
        public int QuantidadeTotalItens { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid ClienteId { get; set; }
        public Guid CondicaoPagamentoId { get; set; }
        public Guid TransportadoraId { get; set; }
        public Guid StatusPedidoId { get; set; }
        public Guid TipoPedidoId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual CondicaoPagamento CondicaoPagamento { get; set; }
        public virtual Transportadora Transportadora { get; set; }
        public virtual StatusPedido StatusPedido { get; set; }
        public virtual TipoPedido TipoPedido { get; set; }
        public ICollection<Faturamento> Faturamentos { get; set; }
    }
}
