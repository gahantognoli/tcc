using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class UsuarioViewModel
    {
        public Guid UsuarioId { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
        public string FotoPerfil { get; set; }
        public string AssinaturaEmail { get; set; }
        public bool UsuarioResponsavel { get; set; }
        public Guid PerfilId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<UsuarioRepresentadaViewModel> UsuariosRepresentadas { get; set; }
        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

    }
}
