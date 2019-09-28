using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UNIFAFIBE.TCC._4Sales.MVC.Models
{
    public class RedefirSenhaViewModel
    {
        [HiddenInput]
        public Guid UsuarioId { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Confirme sua senha")]
        public string ConfirmarSenha { get; set; }
    }
}