using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Segmento
    {
        public Segmento()
        {
            SegmentoId = new Guid();
        }
        public Guid SegmentoId { get; set; }
        public string Descricao { get; set; }
    }
}
