using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class ContatoRepresentadaRepositorio : Repositorio<ContatoRepresentada>, IContatoRepresentadaRepositorio
    {
        public ContatoRepresentadaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override ContatoRepresentada ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ContatoRepresentada> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContatoRepresentada> ObterTodos(int representadaId)
        {
            throw new NotImplementedException();
        }
    }
}
