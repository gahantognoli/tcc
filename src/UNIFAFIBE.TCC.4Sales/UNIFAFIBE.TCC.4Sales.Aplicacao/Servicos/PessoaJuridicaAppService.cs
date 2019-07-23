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
    public class PessoaJuridicaAppService : AppService, IPessoaJuridicaAppService
    {
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public PessoaJuridicaAppService(IPessoaJuridicaService pessoaJuridicaService, IUnitOfWork uow)
            : base(uow)
        {
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        public PessoaJuridicaViewModel Adicionar(PessoaJuridicaViewModel cliente)
        {
            var pessoaJuridicaRetorno = Mapper.Map<PessoaJuridicaViewModel>
                (_pessoaJuridicaService.Adicionar(Mapper.Map<PessoaJuridica>(cliente)));

            if (pessoaJuridicaRetorno.EhValido())
                Commit();
            
            return pessoaJuridicaRetorno;
        }

        public PessoaJuridicaViewModel Atualizar(PessoaJuridicaViewModel cliente)
        {
            var pessoaJuridicaRetorno = Mapper.Map<PessoaJuridicaViewModel>
                (_pessoaJuridicaService.Adicionar(Mapper.Map<PessoaJuridica>(cliente)));

            if (pessoaJuridicaRetorno.EhValido())
                Commit();

            return pessoaJuridicaRetorno;
        }

        public IEnumerable<PessoaJuridicaViewModel> ObterPorCPNJ(string cnpj)
        {
            return Mapper.Map<IEnumerable<PessoaJuridicaViewModel>>(_pessoaJuridicaService.ObterPorCPNJ(cnpj));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_pessoaJuridicaService.ObterPorId(id));
        }

        public IEnumerable<PessoaJuridicaViewModel> ObterPorInscricaoEstadual(string inscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaJuridicaViewModel> ObterPorNomeFantasia(string nomeFantasia)
        {
            return Mapper.Map<IEnumerable<PessoaJuridicaViewModel>>(_pessoaJuridicaService.ObterPorNomeFantasia(nomeFantasia));
        }

        public IEnumerable<PessoaJuridicaViewModel> ObterPorRazaoSocial(string razaoSocial)
        {
            return Mapper.Map<IEnumerable<PessoaJuridicaViewModel>>(_pessoaJuridicaService.ObterPorRazaoSocial(razaoSocial));
        }

        public void Remover(Guid id)
        {
            _pessoaJuridicaService.Remover(id);
            Commit();
        }
    }
}
