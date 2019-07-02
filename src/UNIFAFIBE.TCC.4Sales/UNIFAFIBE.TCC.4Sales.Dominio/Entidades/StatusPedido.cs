using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class StatusPedido
    {
        public StatusPedido()
        {
            StatusPedidoId = new Guid();
        }
        public Guid StatusPedidoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}