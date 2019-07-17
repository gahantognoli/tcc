using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    public class PessoaFisicaConfig : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfig()
        {
            Property(p => p.CPF)
                 .HasMaxLength(11)
                 .IsFixedLength()
                 .IsRequired();

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            //Ignore(v => v.ValidationResult);

            ToTable("PessoaFisica");
        }
    }
}
