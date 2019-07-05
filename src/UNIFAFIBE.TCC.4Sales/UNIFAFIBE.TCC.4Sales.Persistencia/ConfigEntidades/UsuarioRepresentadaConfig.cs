using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class UsuarioRepresentadaConfig : EntityTypeConfiguration<UsuarioRepresentada>
    {
        public UsuarioRepresentadaConfig()
        {
            HasKey(u => u.UsuarioRepresentadaId);

            Property(u => u.Comissao)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(u => u.ValorMaximoDesconto)
                .HasPrecision(18, 2)
                .IsRequired();

            HasRequired(u => u.Usuario)
                .WithMany(u => u.UsuariosRepresentadas)
                .HasForeignKey(u => u.UsuarioId);

            HasRequired(u => u.Representada)
                .WithMany(u => u.UsuariosRepresentadas)
                .HasForeignKey(u => u.RepresentadaId);

            ToTable("UsuariosRepresentadas");
        }
    }
}
