using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {

        public PedidoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Pedido ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Pedido> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterPorCliente(string cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterPorDataEmissao(DateTime dataEmissao)
        {
            throw new NotImplementedException();
        }

        public Pedido ObterPorNumeroPedido(int numeroPedido)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterPorRepresentada(int representadaId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterPorStatus(int statusId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterPorTipo(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> ObterPorVendedor(string usuario)
        {
            throw new NotImplementedException();
        }
    }
}
