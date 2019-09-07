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
        private readonly IStatusPedidoService _statusPedidoService;
        private readonly IItemPedidoService _itemPedidoService;
        private readonly IParcelaService _parcelaService;

        public FaturamentoAppService(IFaturamentoService faturamentoService,
            IPedidoService pedidoService, IStatusPedidoService statusPedidoService,
            IItemPedidoService itemPedidoService, IParcelaService parcelaService, IUnitOfWork uow)
            : base(uow)
        {
            _faturamentoService = faturamentoService;
            _pedidoService = pedidoService;
            _statusPedidoService = statusPedidoService;
            _itemPedidoService = itemPedidoService;
            _parcelaService = parcelaService;
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
            faturamento.Parcelas.ToList().ForEach(p => p.FaturamentoId = faturamento.FaturamentoId);

            var faturamentoRetorno = _faturamentoService.Faturar(Mapper.Map<Faturamento>(faturamento));

            var valorTotalFaturamento = 0M;
            var faturamentosPedido = _faturamentoService.ObterTodos(faturamento.PedidoId);

            foreach (var item in faturamentosPedido)
            {
                valorTotalFaturamento += item.Valor;
            }

            valorTotalFaturamento += faturamento.Valor;

            if (valorTotalFaturamento < pedido.ValorTotal)
            {
                var statusId = _statusPedidoService.ObterPorDescricao("Parcialmente Faturado")
                    .FirstOrDefault().StatusPedidoId;
                _pedidoService.AlterarStatus(statusId, faturamento.PedidoId);
            }
            else
            {
                var statusId = _statusPedidoService.ObterPorDescricao("Faturado")
                    .FirstOrDefault().StatusPedidoId;
                _pedidoService.AlterarStatus(statusId, faturamento.PedidoId);
            }

            Commit();
            return Mapper.Map<FaturamentoViewModel>(faturamentoRetorno);
        }

        public FaturamentoViewModel ObterPorId(Guid id)
        {
            var faturamento = Mapper.Map<FaturamentoViewModel>(_faturamentoService.ObterPorId(id));
            faturamento.Parcelas = 
                Mapper.Map<IEnumerable<ParcelaViewModel>>(_parcelaService
                .ObterTodos(faturamento.FaturamentoId)).ToList();
            return faturamento;
        }

        public IEnumerable<FaturamentoViewModel> ObterTodos(Guid pedidoId)
        {
            return Mapper.Map<IEnumerable<FaturamentoViewModel>>(_faturamentoService.ObterTodos(pedidoId));
        }

        public decimal ObterTotalFaturamento(Guid pedidoId)
        {
            return _faturamentoService.ObterTotalFaturamento(pedidoId);
        }

        public void Remover(Guid id, Guid pedidoId)
        {
            var pedido = _pedidoService.ObterPorId(pedidoId);

            foreach (var parcela in _parcelaService.ObterTodos(id))
            {
                _parcelaService.Remover(parcela.ParcelaId);
            }

            var valorTotalFaturamento = 0M;
            var faturamentosPedido = _faturamentoService.ObterTodos(pedidoId);

            foreach (var item in faturamentosPedido)
            {
                valorTotalFaturamento += item.Valor;
            }

            var faturamento = _faturamentoService.ObterPorId(id);

            valorTotalFaturamento -= faturamento.Valor;

            if (valorTotalFaturamento <= pedido.ValorTotal && valorTotalFaturamento != 0)
            {
                var statusId = _statusPedidoService.ObterPorDescricao("Parcialmente Faturado")
                    .FirstOrDefault().StatusPedidoId;
                _pedidoService.AlterarStatus(statusId, faturamento.PedidoId);
            }
            else if(valorTotalFaturamento == 0)
            {
                var statusId = _statusPedidoService.ObterPorDescricao("Pedido de Venda Gerado")
                    .FirstOrDefault().StatusPedidoId;
                _pedidoService.AlterarStatus(statusId, faturamento.PedidoId);
            }

            _faturamentoService.Remover(id);
            Commit();
        }

        public void Remover(Guid id)
        {
            _faturamentoService.Remover(id);
            Commit();
        }
    }
}
