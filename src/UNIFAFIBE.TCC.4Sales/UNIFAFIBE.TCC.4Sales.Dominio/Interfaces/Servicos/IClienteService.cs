using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Remover(int id);
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
    }
}
