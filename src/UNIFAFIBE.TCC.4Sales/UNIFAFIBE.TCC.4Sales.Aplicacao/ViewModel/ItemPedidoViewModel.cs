using System;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ItemPedidoViewModel
    {
        public ItemPedidoViewModel()
        {
            ItemPedidoId = Guid.NewGuid();
        }

        [Key]
        public Guid ItemPedidoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Quantidade")]
        public int Quantidade { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal Desconto { get; set; }
        [Range(0, 9999999999999999.99)]
        [Required(ErrorMessage = "Preencha o campo Subtotal")]
        public decimal Subtotal { get; set; }
        [ScaffoldColumn(false)]
        public Guid PedidoId { get; set; }
        [ScaffoldColumn(false)]
        public Guid ProdutoId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual PedidoViewModel Pedido { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }

    }
}
