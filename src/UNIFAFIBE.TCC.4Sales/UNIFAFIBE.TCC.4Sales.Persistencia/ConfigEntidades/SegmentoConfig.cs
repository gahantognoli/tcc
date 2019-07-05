using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class SegmentoConfig : EntityTypeConfiguration<Segmento>
    {
        public SegmentoConfig()
        {
            HasKey(s => s.SegmentoId);

            Property(s => s.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            HasMany(s => s.Clientes)
                .WithRequired(s => s.Segmento)
                .HasForeignKey(s => s.SegmentoId);

            ToTable("Segmentos");
        }
    }
}
