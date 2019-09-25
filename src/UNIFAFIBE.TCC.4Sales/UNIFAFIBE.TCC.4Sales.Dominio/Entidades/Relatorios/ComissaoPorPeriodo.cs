using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios
{
    public class ComissaoPorPeriodo
    {
        public DateTime DataPagamento { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime DataFaturamento { get; set; }
        public string Representada { get; set; }
        public string Cliente { get; set; }
        public decimal ValorPedido { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorComissao { get; set; }
        public decimal Comissao { get; set; }
        public string Paga { get; set; }
    }
}
