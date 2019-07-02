using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class ContatoRepresentada
    {
        public ContatoRepresentada()
        {
            ContatoRepresentadaId = new Guid();
        }
        public Guid ContatoRepresentadaId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public Guid RepresentadaId { get; set; }

        public virtual Representada Representada { get; set; }
    }
}
