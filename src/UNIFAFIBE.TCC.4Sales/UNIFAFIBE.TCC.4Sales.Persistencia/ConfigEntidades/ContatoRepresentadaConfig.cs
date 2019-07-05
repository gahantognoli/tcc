using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class ContatoRepresentadaConfig : EntityTypeConfiguration<ContatoRepresentada>
    {
        public ContatoRepresentadaConfig()
        {
            HasKey(c => c.ContatoRepresentadaId);

            Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Cargo)
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            ToTable("ContatosRepresentadas");
        }
    }
}
