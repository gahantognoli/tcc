using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class StatusPedidoConfig : EntityTypeConfiguration<StatusPedido>
    {
        public StatusPedidoConfig()
        {
            HasKey(s => s.StatusPedidoId);

            Property(s => s.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            HasMany(s => s.Pedidos)
                .WithRequired(s => s.StatusPedido)
                .HasForeignKey(s => s.StatusPedidoId);
        }
    }
}
