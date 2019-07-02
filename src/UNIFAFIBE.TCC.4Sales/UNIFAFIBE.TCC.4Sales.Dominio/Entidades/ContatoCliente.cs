using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class ContatoCliente
    {
        public ContatoCliente()
        {
            ContatoClienteId = new Guid();
        }
        public Guid ContatoClienteId { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Guid ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
