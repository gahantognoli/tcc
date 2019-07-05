using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Meta
    {
        public Meta()
        {
            MetaId = new Guid();
        }

        public Guid MetaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
