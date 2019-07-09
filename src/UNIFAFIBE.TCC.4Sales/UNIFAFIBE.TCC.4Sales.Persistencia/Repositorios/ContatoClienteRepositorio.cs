using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class ContatoClienteRepositorio : Repositorio<ContatoCliente>, IContatoClienteRepositorio
    {
        public ContatoClienteRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override ContatoCliente ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ContatoCliente> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContatoCliente> ObterTodos(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
