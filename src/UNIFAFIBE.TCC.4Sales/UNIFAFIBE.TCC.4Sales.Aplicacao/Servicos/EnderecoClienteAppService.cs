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
    public class EnderecoClienteAppService : AppService, IEnderecoClienteAppService
    {
        private readonly IEnderecoClienteService _enderecoClienteService;

        public EnderecoClienteAppService(IEnderecoClienteService enderecoClienteService, IUnitOfWork uow)
            : base(uow)
        {
            _enderecoClienteService = enderecoClienteService;
        }

        public EnderecoClienteViewModel Adicionar(EnderecoClienteViewModel enderecoCliente)
        {
            var enderecoClienteRetorno = Mapper.Map<EnderecoClienteViewModel>
                (_enderecoClienteService.Adicionar(Mapper.Map<EnderecoCliente>(enderecoCliente)));

            if (enderecoClienteRetorno.EhValido())
                Commit();
            
            return enderecoClienteRetorno;
        }

        public EnderecoClienteViewModel Atualizar(EnderecoClienteViewModel enderecoCliente)
        {
            var enderecoClienteRetorno = Mapper.Map<EnderecoClienteViewModel>
                (_enderecoClienteService.Atualizar(Mapper.Map<EnderecoCliente>(enderecoCliente)));

            if (enderecoClienteRetorno.EhValido())
                Commit();

            return enderecoClienteRetorno;
        }

        public EnderecoClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<EnderecoClienteViewModel>(_enderecoClienteService.ObterPorId(id));
        }

        public IEnumerable<EnderecoClienteViewModel> ObterTodos(Guid clienteId)
        {
            return Mapper.Map<IEnumerable<EnderecoClienteViewModel>>(_enderecoClienteService.ObterTodos(clienteId));
        }

        public void Remover(Guid id)
        {
            _enderecoClienteService.Remover(id);
        }
    }
}
