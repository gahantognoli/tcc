using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!faturamento.EhValido())
                return faturamento;

            return _faturamentoRepositorio.Atualizar(faturamento);
        }

        public void Dispose()
        {
            _faturamentoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Faturamento Faturar(Faturamento faturamento)
        {
            if (!faturamento.EhValido())
                return faturamento;

            var pedido = _pedidoRepositorio.ObterPorId(faturamento.PedidoId);


            var fat = _faturamentoRepositorio.Adicionar(faturamento);
            var faturamentosPedido = _faturamentoRepositorio.ObterTodos(fat.PedidoId);

            if (faturamentosPedido.Where(f => f.FaturamentoId != fat.FaturamentoId).Count() > 0)
            {
                faturamentosPedido = faturamentosPedido.Where(f => f.FaturamentoId != fat.FaturamentoId);
                var valorTotalFaturamentosPedido = 0.0M;

                foreach (var item in faturamentosPedido)
                {
                    valorTotalFaturamentosPedido += item.Valor;
                }

                // Criar método auxiliar para retornar o status do pedido
                if (valorTotalFaturamentosPedido < pedido.ValorTotal)
                    pedido.StatusPedido.Descricao = "Parcialmente Faturado";
                else
                    pedido.StatusPedido.Descricao = "Faturado";
            }
            else
            {
                if (fat.Valor < pedido.ValorTotal)
                    pedido.StatusPedido.Descricao = "Parcialmente Faturado";
                else
                    pedido.StatusPedido.Descricao = "Faturado";

            }

            _pedidoRepositorio.Atualizar(pedido);

            return fat;
        }

        public Faturamento ObterPorId(Guid id)
        {
            return _faturamentoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Faturamento> ObterTodos(Guid pedidoId)
        {
            return _faturamentoRepositorio.ObterTodos(pedidoId);
        }

        public void Remover(Guid id)
        {
            _faturamentoRepositorio.Remover(id);
        }
    }
}
