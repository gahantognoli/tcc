using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class FaturamentoViewModel
    {
        public Guid FaturamentoId { get; set; }
        public decimal Valor { get; set; }
        [Display(Name = "Nota Fisal")]
        public string NotaFiscal { get; set; }
        public DateTime Data { get; set; }
        [Display(Name = "Informações Adiionais")]
        public string InformacoesAdicionais { get; set; }
        public Guid PedidoId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual PedidoViewModel Pedido { get; set; }
        public virtual ICollection<ParcelaViewModel> Parcelas { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.Erros.Count() == 0;
        }
    }
}
