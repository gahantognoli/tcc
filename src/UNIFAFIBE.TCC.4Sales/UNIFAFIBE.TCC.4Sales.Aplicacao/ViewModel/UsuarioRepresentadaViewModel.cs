using System;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class UsuarioRepresentadaViewModel
    {
        public Guid UsuarioRepresentadaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid RepresentadaId { get; set; }
        public decimal Comissao { get; set; }
        public decimal ValorMaximoDesconto { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual RepresentadaViewModel Representada { get; set; }
    }
}
