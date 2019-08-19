using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IContatoClienteService : IDisposable
    {
        ContatoCliente Adicionar(ContatoCliente contatoCliente);
        ContatoCliente Atualizar(ContatoCliente contatoCliente);
        void Remover(Guid id);
        ContatoCliente ObterPorId(Guid id);
        IEnumerable<ContatoCliente> ObterTodos(Guid clienteId);
    }
}
