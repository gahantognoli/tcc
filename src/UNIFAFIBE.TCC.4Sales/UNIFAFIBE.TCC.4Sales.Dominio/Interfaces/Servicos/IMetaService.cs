using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IMetaService : IDisposable
    {
        Meta Adicionar(Meta meta);
        Meta Atualizar(Meta meta);
        void Remover(Guid id);
        Meta ObterPorId(Guid id);
        IEnumerable<Meta> ObterTodos();
    }
}
