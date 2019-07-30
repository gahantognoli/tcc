using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class EnderecoClienteConfig : EntityTypeConfiguration<EnderecoCliente>
    {
        public EnderecoClienteConfig()
        {
            HasKey(e => e.EnderecoClienteId);

            Property(e => e.CEP)
                .HasMaxLength(8)
                .IsFixedLength()
                .IsRequired();

            Property(e => e.Endereco)
                .HasMaxLength(150)
                .IsRequired();

            Property(e => e.Numero)
                .IsRequired();

            Property(e => e.Complemento)
                .HasMaxLength(50);

            Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsRequired();

            Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsRequired();

            Property(e => e.Estado)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired();

            //Ignore(v => v.ValidationResult);

        }
    }
}
