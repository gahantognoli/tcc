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
    public class SegmentoAppService : AppService, ISegmentoAppService
    {
        private readonly ISegmentoService _segmentoService;

        public SegmentoAppService(ISegmentoService segmentoService, IUnitOfWork uow)
            : base(uow)
        {
            _segmentoService = segmentoService;
        }

        public SegmentoViewModel Adicionar(SegmentoViewModel segmento)
        {
            var segmentoRetorno = Mapper.Map<SegmentoViewModel>
                (_segmentoService.Adicionar(Mapper.Map<Segmento>(segmento)));

            if (segmentoRetorno.EhValido())
                Commit();
            
            return segmentoRetorno;
        }

        public SegmentoViewModel Atualizar(SegmentoViewModel segmento)
        {
            var segmentoRetorno = Mapper.Map<SegmentoViewModel>
                (_segmentoService.Atualizar(Mapper.Map<Segmento>(segmento)));

            if (segmentoRetorno.EhValido())
                Commit();

            return segmentoRetorno;
        }

        public void Dispose()
        {
            _segmentoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SegmentoViewModel> ObterPorDescricao(string descricao)
        {
            return Mapper.Map<IEnumerable<SegmentoViewModel>>(_segmentoService.ObterPorDescricao(descricao));
        }

        public SegmentoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<SegmentoViewModel>(_segmentoService.ObterPorId(id));
        }

        public IEnumerable<SegmentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<SegmentoViewModel>>(_segmentoService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _segmentoService.Remover(id);
            Commit();
        }
    }
}
