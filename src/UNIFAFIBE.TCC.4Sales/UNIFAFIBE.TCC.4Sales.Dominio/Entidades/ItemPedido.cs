using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class ItemPedido
    {
        public ItemPedido()
        {
            ItemPedidoId = new Guid();
        }
        public Guid ItemPedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal Subtotal { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
