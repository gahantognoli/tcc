using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {
            ProdutoId = new Guid();
        }

        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal IPI { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal Preco { get; set; }
        public Guid RepresentadaId { get; set; }

        public virtual Representada Representada { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
    }
}