using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface ISegmentoService : IDisposable
    {
        Segmento Adicionar(Segmento segmento);
        Segmento Atualizar(Segmento segmento);
        void Remover(Guid id);
        Segmento ObterPorId(Guid id);
        IEnumerable<Segmento> ObterTodos();
        IEnumerable<Segmento> ObterPorDescricao(string descricao);
    }
}
