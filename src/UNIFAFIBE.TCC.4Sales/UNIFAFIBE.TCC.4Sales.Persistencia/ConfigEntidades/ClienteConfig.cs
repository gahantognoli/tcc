using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.InformacoesAdicionais)
                .HasMaxLength(500);

            HasMany(c => c.EnderecosCliente)
                .WithRequired(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId);

            HasMany(c => c.ContatosCliente)
                .WithRequired(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId);

            HasMany(p => p.Pedidos)
               .WithRequired(p => p.Cliente)
               .HasForeignKey(p => p.ClienteId);

            Ignore(v => v.ValidationResult);

            ToTable("Clientes");
        }
    }
}
