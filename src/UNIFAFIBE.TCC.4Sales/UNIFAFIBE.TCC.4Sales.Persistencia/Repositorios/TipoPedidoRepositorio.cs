using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class TipoPedidoRepositorio : Repositorio<TipoPedido>, ITipoPedidoRepositorio
    {
        public TipoPedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override TipoPedido ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TipoPedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoPedido> ObterPorDescricao(string tipoPedido)
        {
            throw new NotImplementedException();
        }
    }
}
