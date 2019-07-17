using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class FaturamentoViewModel
    {
        public Guid FaturamentoId { get; set; }
        public decimal Valor { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime Data { get; set; }
        public string InformacoesAdicionais { get; set; }
        public Guid PedidoId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual PedidoViewModel Pedido { get; set; }
        public virtual ICollection<ParcelaViewModel> Parcelas { get; set; }
    }
}
