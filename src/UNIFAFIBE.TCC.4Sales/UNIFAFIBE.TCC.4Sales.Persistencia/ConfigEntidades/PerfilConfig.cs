using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class PerfilConfig : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfig()
        {
            HasKey(p => p.PerfilId);

            Property(p => p.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            HasMany(p => p.Usuarios)
                .WithRequired(u => u.Perfil)
                .HasForeignKey(u => u.PerfilId);

            //Ignore(v => v.ValidationResult);

            ToTable("Perfis");
        }
    }
}
