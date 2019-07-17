using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.TiposPedido;

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

        public bool EhValido(ITipoPedidoRepositorio tipoPedidoRepositorio)
        {
            return this.EstaApto(tipoPedidoRepositorio);
        }

        public bool EstaConsistente()
        {
            return true;
        }

        public bool EstaApto(ITipoPedidoRepositorio tipoPedidoRepositorio)
        {
            ValidationResult = new TipoPedidoEstaAptoValidation(tipoPedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }

    }
}