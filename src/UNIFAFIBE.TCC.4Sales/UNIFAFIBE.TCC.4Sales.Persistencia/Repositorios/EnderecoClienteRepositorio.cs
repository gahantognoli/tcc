using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class EnderecoClienteRepositorio : Repositorio<EnderecoCliente>, IEnderecoClienteRepositorio
    {
        public EnderecoClienteRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override EnderecoCliente ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<EnderecoCliente> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnderecoCliente> ObterTodos(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
