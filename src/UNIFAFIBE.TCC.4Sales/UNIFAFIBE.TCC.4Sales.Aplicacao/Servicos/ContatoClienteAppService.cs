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
    public class ContatoClienteAppService : AppService, IContatoClienteAppService
    {
        private readonly IContatoClienteService _contatoClienteService;

        public ContatoClienteAppService(IContatoClienteService contatoClienteService, IUnitOfWork uow)
            : base(uow)
        {
            _contatoClienteService = contatoClienteService;
        }

        public ContatoClienteViewModel Adicionar(ContatoClienteViewModel contatoCliente)
        {
            var contatoClienteRetorno = Mapper.Map<ContatoClienteViewModel>
                (_contatoClienteService.Adicionar(Mapper.Map<ContatoCliente>(contatoCliente)));

            if (contatoClienteRetorno.EhValido())
                Commit();

            return contatoClienteRetorno;
        }

        public ContatoClienteViewModel Atualizar(ContatoClienteViewModel contatoCliente)
        {
            var contatoClienteRetorno = Mapper.Map<ContatoClienteViewModel>
                (_contatoClienteService.Atualizar(Mapper.Map<ContatoCliente>(contatoCliente)));

            if (contatoClienteRetorno.EhValido())
                Commit();

            return contatoClienteRetorno;
        }

        public void Dispose()
        {
            _contatoClienteService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ContatoClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ContatoClienteViewModel>(_contatoClienteService.ObterPorId(id));
        }

        public IEnumerable<ContatoClienteViewModel> ObterTodos(Guid clienteId)
        {
            return Mapper.Map<IEnumerable<ContatoClienteViewModel>>(_contatoClienteService.ObterTodos(clienteId));
        }

        public void Remover(Guid id)
        {
            _contatoClienteService.Remover(id);
            Commit();
        }
    }
}
