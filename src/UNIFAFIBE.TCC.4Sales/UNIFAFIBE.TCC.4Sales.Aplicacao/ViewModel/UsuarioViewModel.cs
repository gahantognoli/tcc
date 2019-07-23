﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            UsuarioId = Guid.NewGuid();
        }

        [Key]
        public Guid UsuarioId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MaxLength(int.MaxValue, ErrorMessage = "Tamanho máximo excedido")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string Nome { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo de 20 caracteres")]
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
        [Display(Name = "Foto Perfil")]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Selecione uma foto de perfil")]
        public string FotoPerfil { get; set; }
        [Display(Name = "Assinatura E-mail")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres")]
        public string AssinaturaEmail { get; set; }
        [Display(Name = "Responsável pelo sistema")]
        public bool UsuarioResponsavel { get; set; }
        [ScaffoldColumn(false)]
        public Guid PerfilId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<UsuarioRepresentadaViewModel> UsuariosRepresentadas { get; set; }
        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }

    }
}
