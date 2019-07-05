using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.IPI)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.UnidadeMedida)
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.Preco)
                .HasPrecision(18, 2)
                .IsRequired();

            HasMany(p => p.ItensPedido)
                .WithRequired(p => p.Produto)
                .HasForeignKey(p => p.ProdutoId);

            ToTable("Produtos");
        }
    }
}
