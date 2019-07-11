﻿using System.Data.Entity.ModelConfiguration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades
{
    class PessoaJuridicaConfig : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfig()
        {
            Property(p => p.CNPJ)
                .HasMaxLength(14)
                .IsFixedLength()
                .IsRequired();

            Property(p => p.RazaoSocial)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.NomeFantasia)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.SUFRAMA)
                .HasMaxLength(20)
                .IsRequired();

            Property(p => p.InscricaoEstadual)
                .HasMaxLength(12)
                .IsFixedLength()
                .IsRequired();

            ToTable("PessoaJuridica");
        }
    }
}