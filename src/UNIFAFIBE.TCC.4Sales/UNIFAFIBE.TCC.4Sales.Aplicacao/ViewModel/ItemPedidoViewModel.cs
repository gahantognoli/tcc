using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ValidationResult ValidationResult { get; set; }

        public virtual PedidoViewModel Pedido { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }

    }
}
