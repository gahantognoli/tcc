using System.Collections;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Email
    {
        public Email()
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
