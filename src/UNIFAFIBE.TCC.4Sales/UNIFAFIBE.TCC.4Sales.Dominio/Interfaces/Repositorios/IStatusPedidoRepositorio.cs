using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IStatusPedidoRepositorio : IRepositorio<StatusPedido>
    {
        IEnumerable<StatusPedido> ObterPorDescricao(string descricao);
    }
}
