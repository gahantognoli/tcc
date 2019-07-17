using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class SegmentoViewModel
    {
        public Guid SegmentoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ClienteViewModel> Clientes { get; set; }
    }
}
