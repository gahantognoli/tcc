using System.Collections;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class EmailViewModel
    {
        public List<string> Destinatios { get; set; }
        public string Rementente { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Assinatura { get; set; }
        public ArrayList Anexos { get; set; }
    }
}
