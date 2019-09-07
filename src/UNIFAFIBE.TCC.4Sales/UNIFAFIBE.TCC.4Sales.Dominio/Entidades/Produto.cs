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
            ProdutoId = Guid.NewGuid();
        }

        public Guid ProdutoId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal IPI { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal Preco { get; set; }
        public Guid RepresentadaId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Representada Representada { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
        public bool EhValido(IProdutoRepositorio produtoRepositorio)
        {
            if (EstaApto(produtoRepositorio))
            {
                return this.EstaConsistente();
            }
            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new ProdutoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IProdutoRepositorio produtoRepositorio)
        {
            ValidationResult = new ProdutoEstaAptoValidation(produtoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaAptoParaRemover(IItemPedidoRepositorio itemPedidoRepositorio)
        {
            ValidationResult = new ProdutoEstaAptoParaRemoverValidation(itemPedidoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}