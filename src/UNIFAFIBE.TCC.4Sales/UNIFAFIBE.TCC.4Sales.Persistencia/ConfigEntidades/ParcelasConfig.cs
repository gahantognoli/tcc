using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class ParcelasConfig : EntityTypeConfiguration<Parcela>
    {
        public ParcelasConfig()
        {
            HasKey(p => p.ParcelaId);

            Property(p => p.NumeroParcela)
                .IsRequired();

            Property(p => p.ValorParcela)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.ValorComissao)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.DataPamento)
                .IsRequired();
        }
    }
}
