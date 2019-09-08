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
            TipoPedidoId = Guid.NewGuid();
        }
        public Guid TipoPedidoId { get; set; }
        public string Descricao { get; set; }
        public bool Padrao { get; set; } = false;
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public bool EhValido(ITipoPedidoRepositorio tipoPedidoRepositorio)
        {
            if(this.EstaConsistente())
                return this.EstaApto(tipoPedidoRepositorio);
            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new TipoPedidoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(ITipoPedidoRepositorio tipoPedidoRepositorio)
        {
            ValidationResult = new TipoPedidoEstaAptoValidation(tipoPedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaAptoParaRemover(IPedidoRepositorio pedidoRepositorio)
        {
            ValidationResult = new TipoPedidoEstaAptoParaRemoverValidation(pedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }

    }
}