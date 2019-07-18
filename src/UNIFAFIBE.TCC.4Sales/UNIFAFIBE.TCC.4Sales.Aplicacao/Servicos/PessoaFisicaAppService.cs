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
    public class PessoaFisicaAppService : AppService, IPessoaFisicaAppService
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoaFisicaAppService(IPessoaFisicaService pessoaFisicaService, IUnitOfWork uow)
            : base(uow)
        {
            _pessoaFisicaService = pessoaFisicaService;
        }

        public PessoaFisicaViewModel Adicionar(PessoaFisicaViewModel cliente)
        {
            var pessoaFisicaRetorno = Mapper.Map<PessoaFisicaViewModel>
                (_pessoaFisicaService.Adicionar(Mapper.Map<PessoaFisica>(cliente)));

            if (pessoaFisicaRetorno.EhValido())
                Commit();
            
            return pessoaFisicaRetorno;
        }

        public PessoaFisicaViewModel Atualizar(PessoaFisicaViewModel cliente)
        {
            var pessoaFisicaRetorno = Mapper.Map<PessoaFisicaViewModel>
                (_pessoaFisicaService.Atualizar(Mapper.Map<PessoaFisica>(cliente)));

            if (pessoaFisicaRetorno.EhValido())
                Commit();

            return pessoaFisicaRetorno;
        }

        public IEnumerable<PessoaFisicaViewModel> ObterPorCPF(string cpf)
        {
            return Mapper.Map<IEnumerable<PessoaFisicaViewModel>>(_pessoaFisicaService.ObterPorCPF(cpf));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_pessoaFisicaService.ObterPorId(id));
        }

        public IEnumerable<PessoaFisicaViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<PessoaFisicaViewModel>>(_pessoaFisicaService.ObterPorNome(nome));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_pessoaFisicaService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _pessoaFisicaService.Remover(id);
        }
    }
}
