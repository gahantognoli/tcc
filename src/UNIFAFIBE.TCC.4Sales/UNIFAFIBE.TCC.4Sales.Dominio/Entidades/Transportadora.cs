using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Transportadora
    {
        public Transportadora()
        {
            TransportadoraId = new Guid();
        }
        public Guid TransportadoraId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string InformacoesAdicionais { get; set; }

        public virtual Pedido Pedidos { get; set; }
    }
}
