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
    public class RepresentadaAppService : AppService, IRepresentadaAppService
    {
        private readonly IRepresentadaService _representadaService;

        public RepresentadaAppService(IRepresentadaService representadaService, IUnitOfWork uow)
            : base(uow)
        {
            _representadaService = representadaService;
        }

        public RepresentadaViewModel Adicionar(RepresentadaViewModel representada)
        {
            var representadaRetorno = _representadaService.Adicionar(Mapper.Map<Representada>(representada));

            Commit();
            return Mapper.Map<RepresentadaViewModel>(representadaRetorno);
        }

        public RepresentadaViewModel Atualizar(RepresentadaViewModel representada)
        {
            var representadaRetorno = _representadaService.Atualizar(Mapper.Map<Representada>(representada));

            Commit();
            return Mapper.Map<RepresentadaViewModel>(representadaRetorno);
        }

        public IEnumerable<RepresentadaViewModel> ObterPorCnpj(string cnpj)
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterPorCnpj(cnpj));
        }

        public RepresentadaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<RepresentadaViewModel>(_representadaService.ObterPorId(id));
        }

        public IEnumerable<RepresentadaViewModel> ObterPorNomeFantansia(string nomeFantasia)
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterPorNomeFantansia(nomeFantasia));
        }

        public IEnumerable<RepresentadaViewModel> ObterPorRazaoSocial(string razaoSocial)
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterPorRazaoSocial(razaoSocial));
        }

        public IEnumerable<RepresentadaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _representadaService.Remover(id);
        }
    }
}
