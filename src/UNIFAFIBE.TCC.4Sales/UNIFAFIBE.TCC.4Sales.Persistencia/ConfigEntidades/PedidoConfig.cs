using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class PedidoConfig : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfig()
        {
            HasKey(p => p.PedidoId);

            Property(p => p.NumeroPedido)
                .IsRequired();

            Property(p => p.DataEmissao)
                .IsRequired();

            Property(p => p.EnderecoEntrega)
                .HasMaxLength(200);

            Property(p => p.Contato)
                .HasMaxLength(100);

            Property(p => p.QuantidadeTotalItens)
                .IsRequired();

            Property(p => p.ValorTotal)
                .HasPrecision(18, 2)
                .IsRequired();

            HasMany(p => p.ItensPedido)
                .WithRequired(p => p.Pedido)
                .HasForeignKey(p => p.PedidoId);

            HasMany(p => p.Faturamentos)
                .WithRequired(p => p.Pedido)
                .HasForeignKey(p => p.PedidoId);
        }
    }
}
