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
    public class PessoaFisicaAppService : AppService, IPessoaFisicaAppService
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IEnderecoClienteService _enderecoClienteService;
        private readonly IContatoClienteService _contatoClienteService;
        private readonly IPedidoAppService _pedidoAppService;

        public PessoaFisicaAppService(IPessoaFisicaService pessoaFisicaService,
            IEnderecoClienteService enderecoClienteService, IContatoClienteService contatoClienteService,
            IPedidoAppService pedidoAppService, IUnitOfWork uow)
            : base(uow)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _enderecoClienteService = enderecoClienteService;
            _contatoClienteService = contatoClienteService;
            _pedidoAppService = pedidoAppService;
        }

        public PessoaFisicaViewModel Adicionar(PessoaFisicaViewModel cliente)
        {
            cliente.CPF = RemoverMascara(cliente.CPF);
            var pessoaFisicaRetorno = Mapper.Map<PessoaFisicaViewModel>
                (_pessoaFisicaService.Adicionar(Mapper.Map<PessoaFisica>(cliente)));

            if (pessoaFisicaRetorno.EhValido())
                Commit();

            return pessoaFisicaRetorno;
        }

        public PessoaFisicaViewModel Atualizar(PessoaFisicaViewModel cliente)
        {
            cliente.CPF = RemoverMascara(cliente.CPF);
            var pessoaFisicaRetorno = Mapper.Map<PessoaFisicaViewModel>
                (_pessoaFisicaService.Atualizar(Mapper.Map<PessoaFisica>(cliente)));

            if (pessoaFisicaRetorno.EhValido())
                Commit();

            return pessoaFisicaRetorno;
        }

        public void Dispose()
        {
            _contatoClienteService.Dispose();
            _enderecoClienteService.Dispose();
            _pessoaFisicaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PessoaFisicaViewModel> ObterPorCPF(string cpf)
        {
            return Mapper.Map<IEnumerable<PessoaFisicaViewModel>>(_pessoaFisicaService.ObterPorCPF(cpf));
        }

        public PessoaFisicaViewModel ObterPorId(Guid id)
        {
            var pessoaFisica = Mapper.Map<PessoaFisicaViewModel>(_pessoaFisicaService.ObterPorId(id));

            foreach (var item in Mapper.Map<IEnumerable<EnderecoClienteViewModel>>
                (_enderecoClienteService.ObterTodos(id)))
            {
                pessoaFisica.EnderecosCliente.Add(item);
            }

            foreach (var item in Mapper.Map<IEnumerable<ContatoClienteViewModel>>
                (_contatoClienteService.ObterTodos(id)))
            {
                pessoaFisica.ContatosCliente.Add(item);
            }

            return pessoaFisica;
        }

        public IEnumerable<PessoaFisicaViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<PessoaFisicaViewModel>>(_pessoaFisicaService.ObterPorNome(nome));
        }

        public IEnumerable<PessoaFisicaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PessoaFisicaViewModel>>(_pessoaFisicaService.ObterTodos());
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

            _pessoaFisicaService.Remover(id);
            Commit();
        }

        private string RemoverMascara(string cpf)
        {
            return cpf.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty);
        }

    }
}
