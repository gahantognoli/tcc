using DomainValidation.Validation;
using System;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Parcelas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Parcela
    {
        public Parcela()
        {
            ParcelaId = Guid.NewGuid();
        }
        public Guid ParcelaId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorComissao { get; set; }
        public DateTime DataPagamento { get; set; }
        public Guid FaturamentoId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual Faturamento Faturamento { get; set; }

        public bool EhValido(IFaturamentoRepositorio faturamentoRepositorio)
        {
            return this.EstaApto(faturamentoRepositorio);
        }

        public bool EstaConsistente()
        {
            return true;
        }

        public bool EstaApto(IFaturamentoRepositorio faturamentoRepositorio)
        {
            ValidationResult = new ParcelaEstaAptaValidation(faturamentoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
