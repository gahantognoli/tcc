using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ClienteViewModel
    {
        public Guid ClienteId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string InformacoesAdicionais { get; set; }
        public Guid SegmentoId { get; set; }
    
        public virtual SegmentoViewModel Segmento { get; set; }
        public virtual ICollection<ContatoClienteViewModel> ContatosCliente { get; set; }
        public virtual ICollection<EnderecoClienteViewModel> EnderecosCliente { get; set; }
        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
    }
}
