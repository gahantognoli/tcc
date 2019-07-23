using DomainValidation.Validation;
using System;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.ItensPedido;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class ItemPedido
    {
        public ItemPedido()
        {
            ItemPedidoId = Guid.NewGuid();
        }
        public Guid ItemPedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal Subtotal { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }

        public bool EhValido()
        {
            return this.EstaConsistente();
        }

        public bool EstaConsistente()
        {
            ValidationResult = new ItemPedidoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto()
        {
            return true;
        }
    }
}
