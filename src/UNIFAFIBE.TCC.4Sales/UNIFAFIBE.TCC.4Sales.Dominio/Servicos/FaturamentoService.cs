using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class FaturamentoService : IFaturamentoService
    {
        private readonly IFaturamentoRepositorio _faturamentoRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public FaturamentoService(IFaturamentoRepositorio faturamentoRepositorio,
            IPedidoRepositorio pedidoRepositorio)
        {
            _faturamentoRepositorio = faturamentoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public Faturamento Atualizar(Faturamento faturamento)
        {
            return _faturamentoRepositorio.Atualizar(faturamento);
        }

        public void Dispose()
        {
            _faturamentoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Faturamento Faturar(Faturamento faturamento)
        {
            var fat = _faturamentoRepositorio.Adicionar(faturamento);
            var pedido = _pedidoRepositorio.ObterPorId(fat.PedidoId);

            if (fat.Valor < pedido.ValorTotal)
                pedido.StatusPedido.Descricao = "Parcialmente Faturado";
            else
                pedido.StatusPedido.Descricao = "Faturado";

            _pedidoRepositorio.Atualizar(pedido);

            return fat;
        }

        public Faturamento ObterPorId(int id)
        {
            return _faturamentoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Faturamento> ObterTodos(int pedidoId)
        {
            return _faturamentoRepositorio.ObterTodos(pedidoId);
        }

        public void Remover(int id)
        {
            _faturamentoRepositorio.Remover(id);
        }
    }
}
