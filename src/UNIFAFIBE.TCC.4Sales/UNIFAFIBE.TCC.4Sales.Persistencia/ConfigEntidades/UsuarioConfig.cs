using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.UsuarioId);

            Property(u => u.Senha)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            Property(u => u.FotoPerfil)
                .HasMaxLength(int.MaxValue);

            Property(u => u.AssinaturaEmail)
                .HasMaxLength(500);

            Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(u => u.Ativo)
                .IsRequired();

            Property(u => u.PrimeiroAcesso)
                .IsRequired();

            Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            HasMany(p => p.Pedidos)
                .WithRequired(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId);

            HasMany<Representada>(r => r.Representadas)
                .WithMany(u => u.Usuarios)
                .Map(cs =>
                {
                    cs.MapLeftKey("UsuarioId");
                    cs.MapRightKey("RepresentadaId");
                    cs.ToTable("UsuariosRepresentadas");
                });

            Ignore(v => v.ValidationResult);

            ToTable("Usuarios");
        }
    }
}
