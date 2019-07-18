using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ProdutoViewModel
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal IPI { get; set; }
        [Display(Name = "Unidade Medida")]
        public string UnidadeMedida { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public Guid RepresentadaId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual RepresentadaViewModel Representada { get; set; }
        public ICollection<ItemPedidoViewModel> ItensPedido { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.Erros.Count() == 0;
        }
    }
}
