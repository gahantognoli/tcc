using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class CondicaoPagamentoConfig : EntityTypeConfiguration<CondicaoPagamento>
    {
        public CondicaoPagamentoConfig()
        {
            HasKey(c => c.CondicaoPagamentoId);

            Property(c => c.Descricao)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.ValorMinimo)
                .HasPrecision(18, 2);

            HasMany(c => c.Pedidos)
                .WithRequired(c => c.CondicaoPagamento)
                .HasForeignKey(c => c.CondicaoPagamentoId);

            Ignore(v => v.ValidationResult);

            ToTable("CondicoesPagamentos");
        }
    }
}
