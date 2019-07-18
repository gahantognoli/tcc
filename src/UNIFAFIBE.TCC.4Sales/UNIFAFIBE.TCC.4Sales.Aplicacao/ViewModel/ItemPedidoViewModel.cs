using System;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ItemPedidoViewModel
    {
        public Guid ItemPedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal Subtotal { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual PedidoViewModel Pedido { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }

    }
}
