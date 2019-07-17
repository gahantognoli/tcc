using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IContatoClienteAppService
    {
        ContatoClienteViewModel Adicionar(ContatoClienteViewModel contatoCliente);
        ContatoClienteViewModel Atualizar(ContatoClienteViewModel contatoCliente);
        void Remover(Guid id);
        ContatoClienteViewModel ObterPorId(Guid id);
        IEnumerable<ContatoClienteViewModel> ObterTodos(Guid clienteId);
    }
}
