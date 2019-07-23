using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }
        public Guid ClienteId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string InformacoesAdicionais { get; set; }
        public Guid SegmentoId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Segmento Segmento { get; set; }
        public virtual ICollection<ContatoCliente> ContatosCliente { get; set; }
        public virtual ICollection<EnderecoCliente> EnderecosCliente { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        

    }
}
