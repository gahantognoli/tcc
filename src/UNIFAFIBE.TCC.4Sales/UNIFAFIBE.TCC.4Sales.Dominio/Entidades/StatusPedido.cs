using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class StatusPedido
    {
        public StatusPedido()
        {
            StatusPedidoId = new Guid();
        }
        public Guid StatusPedidoId { get; set; }
        public string Descricao { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public bool EhValido()
        {
            //ValidationResult = new UsuarioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}