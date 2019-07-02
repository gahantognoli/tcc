using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Perfil
    {
        public Perfil()
        {
            PerfilId = new Guid();
        }

        public Guid PerfilId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}