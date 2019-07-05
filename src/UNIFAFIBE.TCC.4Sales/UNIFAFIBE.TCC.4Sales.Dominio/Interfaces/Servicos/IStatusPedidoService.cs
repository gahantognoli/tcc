using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IStatusPedidoService : IDisposable
    {
        StatusPedido Adicionar(StatusPedido statusPedido);
        StatusPedido Atualizar(StatusPedido statusPedido);
        void Remover(int id);
        StatusPedido ObterPorId(int id);
        IEnumerable<StatusPedido> ObterPorDescricao(string descricao);
        IEnumerable<StatusPedido> ObterTodos();
    }
}
