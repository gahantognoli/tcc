using System;
using System.Collections.Generic;

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

        public virtual Pedido Pedido { get; set; }
        public ICollection<Parcela> Parcelas { get; set; }
    }
}
