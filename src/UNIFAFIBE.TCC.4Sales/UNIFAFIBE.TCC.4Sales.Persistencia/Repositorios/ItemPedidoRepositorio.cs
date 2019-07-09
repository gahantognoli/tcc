using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class ItemPedidoRepositorio : Repositorio<ItemPedido>, IItemPedidoRepositorio
    {
        public ItemPedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override ItemPedido ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ItemPedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemPedido> ObterTodos(int pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
