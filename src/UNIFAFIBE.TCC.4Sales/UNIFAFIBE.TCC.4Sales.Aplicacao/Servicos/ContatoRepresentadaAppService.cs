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
    public class ContatoRepresentadaAppService : AppService, IContatoRepresentadaAppService
    {
        private readonly IContatoRepresentadaService _contatoRepresentadaService;

        public ContatoRepresentadaAppService(IContatoRepresentadaService contatoRepresentadaService, IUnitOfWork uow)
            : base(uow)
        {
            _contatoRepresentadaService = contatoRepresentadaService;
        }

        public ContatoRepresentadaViewModel Adicionar(ContatoRepresentadaViewModel ContatoRepresentadaViewModel)
        {
            var contatoRepresentadaRetorno = Mapper.Map<ContatoRepresentadaViewModel>
                (_contatoRepresentadaService.Adicionar(Mapper.Map<ContatoRepresentada>(ContatoRepresentadaViewModel)));

            if (contatoRepresentadaRetorno.EhValido())
                Commit();
            
            return contatoRepresentadaRetorno; 
        }

        public ContatoRepresentadaViewModel Atualizar(ContatoRepresentadaViewModel ContatoRepresentadaViewModel)
        {
            var contatoRepresentadaRetorno = Mapper.Map<ContatoRepresentadaViewModel>
                (_contatoRepresentadaService.Atualizar(Mapper.Map<ContatoRepresentada>(ContatoRepresentadaViewModel)));

            if (contatoRepresentadaRetorno.EhValido())
                Commit();

            return contatoRepresentadaRetorno;
        }

        public ContatoRepresentadaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ContatoRepresentadaViewModel>(_contatoRepresentadaService.ObterPorId(id));
        }

        public IEnumerable<ContatoRepresentadaViewModel> ObterTodos(Guid representadaId)
        {
            return Mapper.Map<IEnumerable<ContatoRepresentadaViewModel>>(_contatoRepresentadaService.ObterTodos(representadaId));
        }

        public void Remover(Guid id)
        {
            _contatoRepresentadaService.Remover(id);
        }
    }
}
