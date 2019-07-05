using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class UsuarioRepresentada
    {
        public UsuarioRepresentada()
        {
            UsuarioRepresentadaId = new Guid();
        }
        public Guid UsuarioRepresentadaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid RepresentadaId { get; set; }
        public decimal Comissao { get; set; }
        public decimal ValorMaximoDesconto { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Representada Representada { get; set; }
    }
}
