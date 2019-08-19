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
    public class MetaAppService : AppService, IMetaAppService
    {
        private readonly IMetaService _metaService;

        public MetaAppService(IMetaService metaService, IUnitOfWork uow)
            : base(uow)
        {
            _metaService = metaService;
        }

        public MetaViewModel Adicionar(MetaViewModel meta)
        {
            var metaRetorno = Mapper.Map<MetaViewModel>(_metaService.Adicionar(Mapper.Map<Meta>(meta)));

            if (metaRetorno.EhValido())
                Commit();
            
            return metaRetorno;
        }

        public MetaViewModel Atualizar(MetaViewModel meta)
        {
            var metaRetorno = Mapper.Map<MetaViewModel>(_metaService.Atualizar(Mapper.Map<Meta>(meta)));

            if (metaRetorno.EhValido())
                Commit();

            return metaRetorno;
        }

        public void Dispose()
        {
            _metaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public MetaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<MetaViewModel>(_metaService.ObterPorId(id));
        }

        public IEnumerable<MetaViewModel> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Mapper.Map<IEnumerable<MetaViewModel>>(_metaService.ObterPorPeriodo(dataInicio, dataFim));
        }

        public IEnumerable<MetaViewModel> ObterTodos(Guid pedidoId)
        {
            return Mapper.Map<IEnumerable<MetaViewModel>>(_metaService.ObterTodos(pedidoId));
        }

        public void Remover(Guid id)
        {
            _metaService.Remover(id);
            Commit();
        }
    }
}
