using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Comissao
    {
        public Guid ParcelaId { get; set; }
        public DateTime DataPagamento { get; set; }
        public int NumeroPedido { get; set; }
        public string Vendedor { get; set; }
        public string Representada { get; set; }
        public string Cliente { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorComissao { get; set; }
        public decimal PercComissao { get; set; }
        public bool Paga { get; set; }
    }
}
