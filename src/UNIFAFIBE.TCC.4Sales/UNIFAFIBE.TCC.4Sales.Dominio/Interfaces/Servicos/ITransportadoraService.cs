using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface ITransportadoraService : IDisposable
    {
        Transportadora Adicionar(Transportadora transportadora);
        Transportadora Atualizar(Transportadora transportadora);
        Transportadora Remover(Guid id);
        Transportadora ObterPorId(Guid id);
        IEnumerable<Transportadora> ObterPorNome(string nome);
        IEnumerable<Transportadora> ObterPorCidade(string cidade);
        IEnumerable<Transportadora> ObterPorEstado(string estado);
        IEnumerable<Transportadora> ObterTodos();
    }
}
