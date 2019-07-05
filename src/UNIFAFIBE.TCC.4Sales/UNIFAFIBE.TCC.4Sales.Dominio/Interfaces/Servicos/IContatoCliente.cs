using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IContatoCliente
    {
        ContatoCliente Adicionar(ContatoCliente contatoCliente);
        ContatoCliente Atualizar(ContatoCliente contatoCliente);
        void Remover(int id);
        ContatoCliente ObterPorId(int id);
        IEnumerable<ContatoCliente> ObterTodos(int clienteId);
    }
}
