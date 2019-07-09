using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class PerfilRepositorio : Repositorio<Perfil>, IPerfilRepositorio
    {
        public PerfilRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Perfil ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Perfil> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Perfil> ObterPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }
    }
}
