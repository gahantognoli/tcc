using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class ContatoClienteService : IContatoCliente
    {
        private readonly IContatoClienteRepositorio _contatoClienteRepositorio;

        public ContatoClienteService(IContatoClienteRepositorio contatoClienteRepositorio)
        {
            _contatoClienteRepositorio = contatoClienteRepositorio;
        }

        public ContatoCliente Adicionar(ContatoCliente contatoCliente)
        {
            return _contatoClienteRepositorio.Adicionar(contatoCliente);
        }

        public ContatoCliente Atualizar(ContatoCliente contatoCliente)
        {
            return _contatoClienteRepositorio.Atualizar(contatoCliente);
        }

        public ContatoCliente ObterPorId(int id)
        {
            return _contatoClienteRepositorio.ObterPorId(id);
        }

        public IEnumerable<ContatoCliente> ObterTodos(int clienteId)
        {
            return _contatoClienteRepositorio.ObterTodos(clienteId);
        }

        public void Remover(int id)
        {
            _contatoClienteRepositorio.Remover(id);
        }
    }
}
