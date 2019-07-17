using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Faturamentos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Faturamento
    {
        public Faturamento()
        {
            FaturamentoId = new Guid();
        }
        public Guid FaturamentoId { get; set; }
        public decimal Valor { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime Data { get; set; }
        public string InformacoesAdicionais { get; set; }
        public Guid PedidoId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual ICollection<Parcela> Parcelas { get; set; }

        public bool EhValido()
        {
            return this.EstaConsistente();
        }

        public bool EstaConsistente()
        {
            ValidationResult = new FaturamentoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto()
        {
            return true;
        }
    }
}
