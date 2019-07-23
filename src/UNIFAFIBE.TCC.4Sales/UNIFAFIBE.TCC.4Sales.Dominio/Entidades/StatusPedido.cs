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
            StatusPedidoId = Guid.NewGuid();
        }
        public Guid StatusPedidoId { get; set; }
        public string Descricao { get; set; }
        public bool Padrao { get; set; } = false;
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public bool EhValido(IStatusPedidoRepositorio statusPedidoRepositorio)
        {
            if(this.EstaConsistente())
                return this.EstaApto(statusPedidoRepositorio);
            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new StatusPedidoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IStatusPedidoRepositorio statusPedidoRepositorio)
        {
            ValidationResult = new StatusPedidoEstaAptoValidation(statusPedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }

    }
}