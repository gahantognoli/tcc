using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class TransportadoraConfig : EntityTypeConfiguration<Transportadora>
    {
        public TransportadoraConfig()
        {
            HasKey(t => t.TransportadoraId);

            Property(t => t.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.Cidade)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.Estado)
                .IsFixedLength()
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            Property(t => t.InformacoesAdicionais)
                .HasMaxLength(500)
                .IsRequired();

            HasMany(t => t.Pedidos)
                .WithRequired(t => t.Transportadora)
                .HasForeignKey(t => t.TransportadoraId);

            Ignore(v => v.ValidationResult);
        }
    }
}
