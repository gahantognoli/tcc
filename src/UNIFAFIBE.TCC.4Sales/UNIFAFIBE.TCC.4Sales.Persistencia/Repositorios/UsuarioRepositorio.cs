using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
