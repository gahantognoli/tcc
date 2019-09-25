using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios
{
    public class VendaPorPeriodo
    {
        public DateTime DataEmissao { get; set; }
        public int NumeroPedido { get; set; }
        public string Cliente { get; set; }
        public string Representada { get; set; }
        public string Vendedor { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
