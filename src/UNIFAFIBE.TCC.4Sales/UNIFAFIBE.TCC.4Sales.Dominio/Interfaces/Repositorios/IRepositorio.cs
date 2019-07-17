using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        int SaveChanges();
    }
}
