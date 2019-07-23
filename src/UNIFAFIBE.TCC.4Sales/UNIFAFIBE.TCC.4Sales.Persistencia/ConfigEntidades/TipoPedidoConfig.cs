using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class TipoPedidoConfig : EntityTypeConfiguration<TipoPedido>
    {
        public TipoPedidoConfig()
        {
            HasKey(t => t.TipoPedidoId);

            Property(t => t.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.Padrao)
                .IsRequired();

            HasMany(t => t.Pedidos)
                .WithRequired(t => t.TipoPedido)
                .HasForeignKey(t => t.TipoPedidoId);

            Ignore(v => v.ValidationResult);
        }
    }
}
