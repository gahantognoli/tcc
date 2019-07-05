using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class MetaConfig : EntityTypeConfiguration<Meta>
    {
        public MetaConfig()
        {
            HasKey(m => m.MetaId);

            Property(m => m.Valor)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(m => m.DataInicio)
                .IsRequired();

            Property(m => m.DataFim)
                .IsRequired();
        }
    }
}
