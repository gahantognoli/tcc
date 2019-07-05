using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface ITipoPedidoService : IDisposable
    {
        TipoPedido Adicionar(TipoPedido tipoPedido);
        TipoPedido Atualizar(TipoPedido tipoPedido);
        void Remover(int id);
        TipoPedido ObterPorId(int id);
        IEnumerable<TipoPedido> ObterPorDescricao(string tipoPedido);
        IEnumerable<TipoPedido> ObterTodos();
    }
}
