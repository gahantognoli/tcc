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
    public class ParcelaAppService : AppService, IParcelaAppService
    {
        private readonly IParcelaService _parcelaService;

        public ParcelaAppService(IParcelaService parcelaService, IUnitOfWork uow)
            : base(uow)
        {
            _parcelaService = parcelaService;
        }

        public ParcelaViewModel Adicionar(ParcelaViewModel parcela)
        {
            var parcelaRetorno = _parcelaService.Adicionar(Mapper.Map<Parcela>(parcela));

            Commit();
            return Mapper.Map<ParcelaViewModel>(parcelaRetorno);
        }

        public ParcelaViewModel Atualizar(ParcelaViewModel parcela)
        {
            var parcelaRetorno = _parcelaService.Atualizar(Mapper.Map<Parcela>(parcela));

            Commit();
            return Mapper.Map<ParcelaViewModel>(parcelaRetorno);
        }

        public decimal CalcularComissao(decimal valorFaturamento, decimal comissao, int numParcela)
        {
            return _parcelaService.CalcularComissao(valorFaturamento, comissao, numParcela);
        }

        public ParcelaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ParcelaViewModel>(_parcelaService.ObterPorId(id));
        }

        public IEnumerable<ParcelaViewModel> ObterTodos(Guid faturamentoId)
        {
            return Mapper.Map<IEnumerable<ParcelaViewModel>>(_parcelaService.ObterTodos(faturamentoId));
        }

        public void Remover(Guid parcelaId)
        {
            _parcelaService.Remover(parcelaId);
        }
    }
}
