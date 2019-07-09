using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class StatusPedidoRepositorio : Repositorio<StatusPedido>, IStatusPedidoRepositorio
    {
        public StatusPedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override StatusPedido ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<StatusPedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusPedido> ObterPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }
    }
}
