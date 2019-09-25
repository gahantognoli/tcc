using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios
{
    public class FaturamentoPorPeriodo
    {
        public DateTime DataEmissao { get; set; }
        public int NumeroPedido { get; set; }
        public string RazaoSocial { get; set; }
        public string Cliente { get; set; }
        public string Vendedor { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Faturado { get; set; }
        public decimal NaoFaturado { get; set; }
    }
}
