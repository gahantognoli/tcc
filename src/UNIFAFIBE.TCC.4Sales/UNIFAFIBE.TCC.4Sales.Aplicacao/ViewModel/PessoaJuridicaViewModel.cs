using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class PessoaJuridicaViewModel : ClienteViewModel
    {
        public string RazaoSocial { get; set; }
        public string SUFRAMA { get; set; }
        public string InscricaoEstadual { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}
