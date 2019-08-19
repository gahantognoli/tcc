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
    public class CondicaoPagamentoAppService : AppService, ICondicaoPagamentoAppService
    {
        private readonly ICondicaoPagamentoService _condicaoPagamentoService;

        public CondicaoPagamentoAppService(ICondicaoPagamentoService condicaoPagamentoService, IUnitOfWork uow)
            : base(uow)
        {
            _condicaoPagamentoService = condicaoPagamentoService;
        }

        public CondicaoPagamentoViewModel Adicionar(CondicaoPagamentoViewModel condicaoPagamento)
        {
            var condicaoPagamentoRetorno = Mapper.Map<CondicaoPagamentoViewModel>
                (_condicaoPagamentoService.Adicionar(Mapper.Map<CondicaoPagamento>(condicaoPagamento)));

            if (condicaoPagamentoRetorno.EhValido())
                Commit();

            return condicaoPagamento;
        }

        public CondicaoPagamentoViewModel Atualizar(CondicaoPagamentoViewModel condicaoPagamento)
        {
            var condicaoPagamentoRetorno = Mapper.Map<CondicaoPagamentoViewModel>
                (_condicaoPagamentoService.Atualizar(Mapper.Map<CondicaoPagamento>(condicaoPagamento)));

            if (condicaoPagamentoRetorno.EhValido())
                Commit();

            return condicaoPagamentoRetorno;
        }

        public void Dispose()
        {
            _condicaoPagamentoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public CondicaoPagamentoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<CondicaoPagamentoViewModel>(_condicaoPagamentoService.ObterPorId(id));
        }

        public IEnumerable<CondicaoPagamentoViewModel> ObterTodos(Guid representadaId)
        {
            return Mapper.Map<IEnumerable<CondicaoPagamentoViewModel>>(_condicaoPagamentoService.ObterTodos(representadaId));
        }

        public void Remover(Guid id)
        {
            _condicaoPagamentoService.Remover(id);
            Commit();
        }
    }
}
