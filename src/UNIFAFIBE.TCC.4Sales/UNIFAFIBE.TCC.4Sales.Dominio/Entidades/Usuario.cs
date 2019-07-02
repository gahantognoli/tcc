using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            UsuarioId = new Guid();
        }
        public Guid UsuarioId { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public string FotoPerfil { get; set; }
        public string AssinaturaEmail { get; set; }
        public int PerfilId { get; set; }

        public virtual Perfil Perfil { get; set; }
        public ICollection<Representada> Representadas { get; set; }
    }
}
