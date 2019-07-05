using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class FaturamentoConfig : EntityTypeConfiguration<Faturamento>
    {
        public FaturamentoConfig()
        {
            HasKey(f => f.FaturamentoId);

            Property(f => f.Valor)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(f => f.NotaFiscal)
                .HasMaxLength(50);

            Property(f => f.Data)
                .IsRequired();

            Property(f => f.InformacoesAdicionais)
                .HasMaxLength(500);

            HasMany(f => f.Parcelas)
                .WithRequired(f => f.Faturamento)
                .HasForeignKey(f => f.FaturamentoId);
        }
    }
}
