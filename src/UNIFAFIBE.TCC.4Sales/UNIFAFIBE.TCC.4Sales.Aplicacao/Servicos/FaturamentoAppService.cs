using AutoMapper;
using System;
using System.Collections.Generic;
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

        public FaturamentoAppService(IFaturamentoService faturamentoService, IUnitOfWork uow)
            : base(uow)
        {
            _faturamentoService = faturamentoService;
        }

        public FaturamentoViewModel Atualizar(FaturamentoViewModel faturamento)
        {
            var faturamentoRetorno = _faturamentoService.Atualizar(Mapper.Map<Faturamento>(faturamento));

            Commit();
            return Mapper.Map<FaturamentoViewModel>(faturamentoRetorno);
        }

        public FaturamentoViewModel Faturar(FaturamentoViewModel faturamento)
        {
            var faturamentoRetorno = _faturamentoService.Faturar(Mapper.Map<Faturamento>(faturamento));

            Commit();
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

        public void Remover(Guid id)
        {
            _faturamentoService.Remover(id);
        }
    }
}
