using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.CondicoesPagamento;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class CondicaoPagamento
    {
        public CondicaoPagamento()
        {
            CondicaoPagamentoId = Guid.NewGuid();
        }
        public Guid CondicaoPagamentoId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMinimo { get; set; }
        public virtual Guid RepresentadaId { get; set; }
        public virtual Representada Representada { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public bool EhValido(ICondicaoPagamentoRepositorio condicaoPagamentoRepositorio)
        {
            return this.EstaApto(condicaoPagamentoRepositorio);
        }

        public bool EstaConsistente()
        {
            return true;
        }

        public bool EstaApto(ICondicaoPagamentoRepositorio condicaoPagamentoRepositorio)
        {
            ValidationResult = new CondicaoPagamentoEstaAptaValidation(condicaoPagamentoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
