using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class FaturamentoAppService : AppService, IFaturamentoAppService
    {
        private readonly IFaturamentoService _faturamentoService;
        private readonly IPedidoService _pedidoService;

        public FaturamentoAppService(IFaturamentoService faturamentoService,
            IPedidoService pedidoService,
            IUnitOfWork uow)
            : base(uow)
        {
            _faturamentoService = faturamentoService;
            _pedidoService = pedidoService;
        }

        public FaturamentoViewModel Atualizar(FaturamentoViewModel faturamento)
        {
            var faturamentoRetorno = Mapper.Map<FaturamentoViewModel>
                (_faturamentoService.Atualizar(Mapper.Map<Faturamento>(faturamento)));

            if (faturamentoRetorno.EhValido())
                Commit();
            
            return faturamentoRetorno;
        }

        public void Dispose()
        {
            _faturamentoService.Dispose();
            _pedidoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public FaturamentoViewModel Faturar(FaturamentoViewModel faturamento)
        {
            var pedido = _pedidoService.ObterPorId(faturamento.PedidoId);


            var faturamentoRetorno = _faturamentoService.Faturar(Mapper.Map<Faturamento>(faturamento));
            var faturamentosPedido = _faturamentoService.ObterTodos(faturamentoRetorno.PedidoId);

            if (faturamentoRetorno.EhValido())
            {

                if (faturamentosPedido.Where(f => f.FaturamentoId != faturamentoRetorno.FaturamentoId).Count() > 0)
                {
                    faturamentosPedido = faturamentosPedido.Where(f => f.FaturamentoId != faturamentoRetorno.FaturamentoId);
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

                    _pedidoService.Atualizar(pedido);
                }
                else
                {
                    if (faturamentoRetorno.Valor < pedido.ValorTotal)
                        pedido.StatusPedido.Descricao = "Parcialmente Faturado";
                    else
                        pedido.StatusPedido.Descricao = "Faturado";

                    _pedidoService.Atualizar(pedido);
                }



                Commit();
            }

            return Mapper.Map<FaturamentoViewModel>(faturamentoRetorno);
        }

        public FaturamentoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<FaturamentoViewModel>(_faturamentoService.ObterPorId(id));
        }

        public IEnumerable<FaturamentoViewModel> ObterTodos(Guid pedidoId)
        {
            return Mapper.Map<IEnumerable<FaturamentoViewModel>>(_faturamentoService.ObterTodos(pedidoId));
        }

        public decimal ObterTotalFaturamento(Guid pedidoId)
        {
            return _faturamentoService.ObterTotalFaturamento(pedidoId);
        }

        public void Remover(Guid id)
        {
            _faturamentoService.Remover(id);
            Commit();
        }
    }
}
