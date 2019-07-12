using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class TipoPedido
    {
        public TipoPedido()
        {
            TipoPedidoId = new Guid();
        }
        public Guid TipoPedidoId { get; set; }
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