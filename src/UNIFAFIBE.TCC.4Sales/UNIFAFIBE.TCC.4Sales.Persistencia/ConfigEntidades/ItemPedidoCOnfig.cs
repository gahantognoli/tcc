using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    class ItemPedidoConfig : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoConfig()
        {
            HasKey(i => i.ItemPedidoId);

            Property(i => i.Quantidade)
                .IsRequired();

            Property(i => i.Desconto)
                .HasPrecision(18, 2);

            Property(i => i.Subtotal)
                .HasPrecision(18, 2)
                .IsRequired();

        }
    }
}
