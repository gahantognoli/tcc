using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Parcela
    {
        public Parcela()
        {
            ParcelaId = new Guid();
        }
        public Guid ParcelaId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorComissao { get; set; }
        public DateTime DataPamento { get; set; }
        public Guid FaturamentoId { get; set; }

        public virtual Faturamento Faturamento { get; set; }
    }
}
