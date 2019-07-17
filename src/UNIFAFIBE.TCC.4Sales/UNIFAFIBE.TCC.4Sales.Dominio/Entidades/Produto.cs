using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Produtos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {
            ProdutoId = new Guid();
        }

        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal IPI { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal Preco { get; set; }
        public Guid RepresentadaId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Representada Representada { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
        public bool EhValido()
        {
            return this.EstaConsistente();
        }

        public bool EstaConsistente()
        {
            ValidationResult = new ProdutoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IProdutoRepositorio produtoRepositorio)
        {
            return true;
        }
    }
}