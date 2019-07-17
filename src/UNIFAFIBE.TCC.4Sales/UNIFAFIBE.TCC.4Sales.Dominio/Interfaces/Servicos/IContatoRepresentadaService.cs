using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IContatoRepresentadaService : IDisposable
    {
        ContatoRepresentada Adicionar(ContatoRepresentada contatoRepresentada);
        ContatoRepresentada Atualizar(ContatoRepresentada contatoRepresentada);
        void Remover(Guid id);
        ContatoRepresentada ObterPorId(Guid id);
        IEnumerable<ContatoRepresentada> ObterTodos(Guid representadaId);
    }
}
