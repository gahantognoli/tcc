using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class UsuarioViewModel
    {
        public Guid UsuarioId { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
        [Display(Name = "Foto Perfil")]
        public string FotoPerfil { get; set; }
        [Display(Name = "Assinatura E-mail")]
        public string AssinaturaEmail { get; set; }
        [Display(Name = "Responsável pelo sistema")]
        public bool UsuarioResponsavel { get; set; }
        public Guid PerfilId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<UsuarioRepresentadaViewModel> UsuariosRepresentadas { get; set; }
        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.Erros.Count() == 0;
        }

    }
}
