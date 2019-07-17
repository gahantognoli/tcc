using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ProdutoViewModel
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal IPI { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal Preco { get; set; }
        public Guid RepresentadaId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual RepresentadaViewModel Representada { get; set; }
        public ICollection<ItemPedidoViewModel> ItensPedido { get; set; }
    }
}
