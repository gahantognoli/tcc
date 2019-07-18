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
    public class TransportadoraAppService : AppService, ITransportadoraAppService
    {
        private readonly ITransportadoraService _transportadoraService;

        public TransportadoraAppService(ITransportadoraService transportadoraService, IUnitOfWork uow)
            : base(uow)
        {
            _transportadoraService = transportadoraService;
        }

        public TransportadoraViewModel Adicionar(TransportadoraViewModel transportadora)
        {
            var transportadoraRetorno = Mapper.Map<TransportadoraViewModel>
                (_transportadoraService.Adicionar(Mapper.Map<Transportadora>(transportadora)));

            if (transportadoraRetorno.EhValido())
                Commit();
            
            return transportadoraRetorno;
        }

        public TransportadoraViewModel Atualizar(TransportadoraViewModel transportadora)
        {
            var transportadoraRetorno = Mapper.Map<TransportadoraViewModel>
                (_transportadoraService.Atualizar(Mapper.Map<Transportadora>(transportadora)));

            if (transportadoraRetorno.EhValido())
                Commit();

            return transportadoraRetorno;
        }

        public IEnumerable<TransportadoraViewModel> ObterPorCidade(string cidade)
        {
            return Mapper.Map<IEnumerable<TransportadoraViewModel>>(_transportadoraService.ObterPorCidade(cidade));
        }

        public IEnumerable<TransportadoraViewModel> ObterPorEstado(string estado)
        {
            return Mapper.Map<IEnumerable<TransportadoraViewModel>>(_transportadoraService.ObterPorEstado(estado));
        }

        public TransportadoraViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<TransportadoraViewModel>(_transportadoraService.ObterPorId(id));
        }

        public IEnumerable<TransportadoraViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<TransportadoraViewModel>>(_transportadoraService.ObterPorNome(nome));
        }

        public IEnumerable<TransportadoraViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TransportadoraViewModel>>(_transportadoraService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _transportadoraService.Remover(id);
        }
    }
}
