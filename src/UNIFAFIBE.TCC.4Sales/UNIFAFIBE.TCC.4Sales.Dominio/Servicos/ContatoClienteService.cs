using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class ContatoClienteService : IContatoClienteService
    {
        private readonly IContatoClienteRepositorio _contatoClienteRepositorio;

        public ContatoClienteService(IContatoClienteRepositorio contatoClienteRepositorio)
        {
            _contatoClienteRepositorio = contatoClienteRepositorio;
        }

        public ContatoCliente Adicionar(ContatoCliente contatoCliente)
        {
            if (!contatoCliente.EhValido())
                return contatoCliente;

            return _contatoClienteRepositorio.Adicionar(contatoCliente);
        }

        public ContatoCliente Atualizar(ContatoCliente contatoCliente)
        {
            if (!contatoCliente.EhValido())
                return contatoCliente;

            return _contatoClienteRepositorio.Atualizar(contatoCliente);
        }

        public void Dispose()
        {
            _contatoClienteRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public ContatoCliente ObterPorId(Guid id)
        {
            return _contatoClienteRepositorio.ObterPorId(id);
        }

        public IEnumerable<ContatoCliente> ObterTodos(Guid clienteId)
        {
            return _contatoClienteRepositorio.ObterTodos(clienteId);
        }

        public void Remover(Guid id)
        {
            _contatoClienteRepositorio.Remover(id);
        }
    }
}
