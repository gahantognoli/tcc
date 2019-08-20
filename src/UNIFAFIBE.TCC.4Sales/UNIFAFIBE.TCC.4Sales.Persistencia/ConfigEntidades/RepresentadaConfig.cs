using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class RepresentadaConfig : EntityTypeConfiguration<Representada>
    {
        public RepresentadaConfig()
        {
            HasKey(r => r.RepresentadaId);

            Property(r => r.RazaoSocial)
                .HasMaxLength(150)
                .IsRequired();

            //Property(r => r.NomeFantasia)
            //    .HasMaxLength(100)
            //    .IsRequired();

            Property(r => r.Telefone)
                .HasMaxLength(20);

            Property(r => r.Email)
                .HasMaxLength(100);

            Property(r => r.Comissao)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(r => r.CNPJ)
                .HasMaxLength(14)
                .IsFixedLength()
                .IsRequired();

            Property(r => r.InformacoesAdicionais)
                .HasMaxLength(500);

            Property(r => r.Foto)
                .HasMaxLength(int.MaxValue);

            /* HasMany(u => u.UsuarioRepresentadas)
                 .WithRequired(u => u.Representada)
                 .HasForeignKey(u => u.RepresentadaId);*/

            HasMany(u => u.Pedidos)
                .WithRequired(u => u.Representada)
                .HasForeignKey(u => u.RepresentadaId);

            HasMany(u => u.Produtos)
                .WithRequired(u => u.Representada)
                .HasForeignKey(u => u.RepresentadaId);

            HasMany(u => u.ContatosRepresentada)
               .WithRequired(u => u.Representada)
               .HasForeignKey(u => u.RepresentadaId);

            HasMany(u => u.CondicoesPagamento)
              .WithRequired(u => u.Representada)
              .HasForeignKey(u => u.RepresentadaId);

            Ignore(v => v.ValidationResult);

            ToTable("Representadas");
        }
    }
}
