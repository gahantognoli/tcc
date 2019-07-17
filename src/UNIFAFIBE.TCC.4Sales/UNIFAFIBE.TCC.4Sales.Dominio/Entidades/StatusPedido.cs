using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.StatusPedidos;

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

        public bool EhValido(IStatusPedidoRepositorio statusPedidoRepositorio)
        {
            return this.EstaApto(statusPedidoRepositorio);
        }

        public bool EstaConsistente()
        {
            return true;
        }

        public bool EstaApto(IStatusPedidoRepositorio statusPedidoRepositorio)
        {
            ValidationResult = new StatusPedidoEstaAptoValidation(statusPedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }

    }
}