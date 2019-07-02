using System;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = new Guid();
        }
        public Guid ClienteId { get; set; }
        public string RazaoSocial { get; set; }
        public string SUFRAMA { get; set; }
        public string InscricaoEstadual { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public char Tipo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Guid SegmentoId { get; set; }

        public virtual Segmento Segmento { get; set; }

        public virtual ContatoCliente ContatosCliente { get; set; }
        public virtual EnderecoCliente EnderecosCliente { get; set; }
        public virtual Pedido Pedidos { get; set; }
    }
}
