using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class EmailViewModel
    {
        public EmailViewModel()
        {
            Destinatios = new List<string>();
        }

        public List<string> Destinatios { get; set; }
        public string Rementente { get; set; } = "contato.4sales@gmail.com";
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Assinatura { get; set; }
        public ArrayList Anexos { get; set; }
    }
}
