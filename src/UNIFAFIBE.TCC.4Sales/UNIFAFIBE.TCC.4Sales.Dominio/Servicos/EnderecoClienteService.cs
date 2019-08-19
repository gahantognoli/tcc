using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class EnderecoClienteService : IEnderecoClienteService
    {
        private readonly IEnderecoClienteRepositorio _enderecoClienteRepositorio;

        public EnderecoClienteService(IEnderecoClienteRepositorio enderecoClienteRepositorio)
        {
            _enderecoClienteRepositorio = enderecoClienteRepositorio;
        }

        public EnderecoCliente Adicionar(EnderecoCliente enderecoCliente)
        {
            return _enderecoClienteRepositorio.Adicionar(enderecoCliente);
        }

        public EnderecoCliente Atualizar(EnderecoCliente enderecoCliente)
        {
            return _enderecoClienteRepositorio.Atualizar(enderecoCliente);
        }

        public void Dispose()
        {
            _enderecoClienteRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public EnderecoCliente ObterPorId(Guid id)
        {
            return _enderecoClienteRepositorio.ObterPorId(id);
        }

        public IEnumerable<EnderecoCliente> ObterTodos(Guid clienteId)
        {
            return _enderecoClienteRepositorio.ObterTodos(clienteId);
        }

        public void Remover(Guid id)
        {
            _enderecoClienteRepositorio.Remover(id);
        }
    }
}
