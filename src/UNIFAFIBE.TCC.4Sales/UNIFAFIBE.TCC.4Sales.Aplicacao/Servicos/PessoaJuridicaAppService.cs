﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IEnderecoClienteService _enderecoClienteService;
        private readonly IContatoClienteService _contatoClienteService;
        private readonly IPedidoAppService _pedidoAppService;


        public PessoaJuridicaAppService(IPessoaJuridicaService pessoaJuridicaService, IUnitOfWork uow,
            IContatoClienteService contatoClienteService, IEnderecoClienteService enderecoClienteService,
            IPedidoAppService pedidoAppService)
            : base(uow)
        {
            _pessoaJuridicaService = pessoaJuridicaService;
            _contatoClienteService = contatoClienteService;
            _enderecoClienteService = enderecoClienteService;
            _pedidoAppService = pedidoAppService;
        }

        public PessoaJuridicaViewModel Adicionar(PessoaJuridicaViewModel cliente)
        {
            cliente.CNPJ = RemoverMascara(cliente.CNPJ);
            var pessoaJuridicaRetorno = Mapper.Map<PessoaJuridicaViewModel>
                (_pessoaJuridicaService.Adicionar(Mapper.Map<PessoaJuridica>(cliente)));
            //_enderecoClienteService.Adicionar(Mapper.Map<EnderecoCliente>(cliente.EnderecosCliente.FirstOrDefault()));
            //_contatoClienteService.Adicionar(Mapper.Map<ContatoCliente>(cliente.ContatosCliente.FirstOrDefault()));

            if (pessoaJuridicaRetorno.EhValido())
                Commit();
            
            return pessoaJuridicaRetorno;
        }

        public PessoaJuridicaViewModel Atualizar(PessoaJuridicaViewModel cliente)
        {
            cliente.CNPJ = RemoverMascara(cliente.CNPJ);
            var pessoaJuridicaRetorno = Mapper.Map<PessoaJuridicaViewModel>
                (_pessoaJuridicaService.Atualizar(Mapper.Map<PessoaJuridica>(cliente)));

            if (pessoaJuridicaRetorno.EhValido())
                Commit();

            return pessoaJuridicaRetorno;
        }

        public void Dispose()
        {
            _contatoClienteService.Dispose();
            _enderecoClienteService.Dispose();
            _pessoaJuridicaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PessoaJuridicaViewModel> ObterPorCPNJ(string cnpj)
        {
            return Mapper.Map<IEnumerable<PessoaJuridicaViewModel>>(_pessoaJuridicaService.ObterPorCPNJ(cnpj));
        }

        public PessoaJuridicaViewModel ObterPorId(Guid id)
        {
            var pessoaJuridica = Mapper.Map<PessoaJuridicaViewModel>(_pessoaJuridicaService.ObterPorId(id));
            foreach (var item in Mapper.Map<IEnumerable<EnderecoClienteViewModel>>(_enderecoClienteService.ObterTodos(id)))
            {
                pessoaJuridica.EnderecosCliente.Add(item);
            }

            foreach (var item in Mapper.Map<IEnumerable<ContatoClienteViewModel>>(_contatoClienteService.ObterTodos(id)))
            {
                pessoaJuridica.ContatosCliente.Add(item);
            }

            return pessoaJuridica;
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

        public IEnumerable<PessoaJuridicaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PessoaJuridicaViewModel>>(_pessoaJuridicaService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            var enderecosCliente = _enderecoClienteService.ObterTodos(id);
            if (enderecosCliente.Count() > 0)
                enderecosCliente.ToList().ForEach(x => _enderecoClienteService.Remover(x.EnderecoClienteId));
            

            var contatosCliente = _contatoClienteService.ObterTodos(id);
            if (contatosCliente.Count() > 0)
                contatosCliente.ToList().ForEach(x => _contatoClienteService.Remover(x.ContatoClienteId));

            var pedidosCliente = _pedidoAppService.ObterPorCliente(id);
            if (pedidosCliente.Count() > 0)
                pedidosCliente.ToList().ForEach(x => _pedidoAppService.Remover(x.PedidoId));

            _pessoaJuridicaService.Remover(id);
            Commit();
        }

        private string RemoverMascara(string cnpj)
        {
            return cnpj.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty);
        }

    }
}
