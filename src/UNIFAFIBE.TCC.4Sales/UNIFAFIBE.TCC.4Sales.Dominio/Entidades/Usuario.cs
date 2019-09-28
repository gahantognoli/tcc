using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Usuarios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            UsuarioId = Guid.NewGuid();
        }
        public Guid UsuarioId { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public bool PrimeiroAcesso { get; set; }
        public string FotoPerfil { get; set; }
        public string AssinaturaEmail { get; set; }
        public bool UsuarioResponsavel { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Representada> Representadas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public bool EhValido(IUsuarioRepositorio usuarioRepositorio)
        {
            if (this.EstaConsistente())
                return this.EstaApto(usuarioRepositorio);
            return false;
        }

        public bool EstaConsistente()
        {
            ValidationResult = new UsuarioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool EstaApto(IUsuarioRepositorio usuarioRepositorio)
        {
            ValidationResult = new UsuarioEstaAptoValidation(usuarioRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
