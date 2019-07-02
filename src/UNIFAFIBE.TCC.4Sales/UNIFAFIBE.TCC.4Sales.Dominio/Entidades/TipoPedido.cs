using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class TipoPedido
    {
        public TipoPedido()
        {
            TipoPedidoId = new Guid();
        }
        public Guid TipoPedidoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}