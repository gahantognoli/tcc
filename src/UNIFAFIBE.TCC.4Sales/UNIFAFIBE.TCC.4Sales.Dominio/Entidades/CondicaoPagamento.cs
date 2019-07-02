using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class CondicaoPagamento
    {
        public CondicaoPagamento()
        {
            CondicaoPagamentoId = new Guid();
        }
        public Guid CondicaoPagamentoId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMinimo { get; set; }
        public virtual Guid RepresentadaId { get; set; }
        public virtual Representada Representada { get; set; }
    }
}
