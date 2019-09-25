using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios
{
    public class SituacaoCarteiraClientes
    {
        public string Cliente { get; set; }
        public int UltimoPedido { get; set; }
        public DateTime DataUltimoPedido { get; set; }
        public decimal ValorUltimoPedido { get; set; }
        public int DiasSemComprar { get; set; }
    }
}
