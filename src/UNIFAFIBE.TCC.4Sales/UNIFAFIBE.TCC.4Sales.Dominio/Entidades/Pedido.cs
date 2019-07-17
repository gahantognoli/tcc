using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Pedidos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            PedidoId = new Guid();
        }

        public Guid PedidoId { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime DataEmissao { get; set; }
        public string EnderecoEntrega { get; set; }
        public string Contato { get; set; }
        public int QuantidadeTotalItens { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid RepresentadaId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid CondicaoPagamentoId { get; set; }
        public Guid TransportadoraId { get; set; }
        public Guid StatusPedidoId { get; set; }
        public Guid TipoPedidoId { get; set; }
        public Guid UsuarioId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual CondicaoPagamento CondicaoPagamento { get; set; }
        public virtual Transportadora Transportadora { get; set; }
        public virtual StatusPedido StatusPedido { get; set; }
        public virtual TipoPedido TipoPedido { get; set; }
        public virtual Representada Representada { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Faturamento> Faturamentos { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public bool EhValido(IPedidoRepositorio pedidoRepositorio)
        {
            if (this.EstaConsistente())
                return this.EstaApto(pedidoRepositorio);

            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new PedidoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IPedidoRepositorio pedidoRepositorio)
        {
            ValidationResult = new PedidoEstaAptoValidation(pedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
