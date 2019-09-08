using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Transportadoras;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Transportadora
    {
        public Transportadora()
        {
            TransportadoraId = Guid.NewGuid();
        }
        public Guid TransportadoraId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string InformacoesAdicionais { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public bool EstaAptaParaRemover(IPedidoRepositorio pedidoRepositorio)
        {
            ValidationResult = new TransportadoraEstaAptaParaRemoverValidation(pedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
