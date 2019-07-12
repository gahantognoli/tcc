﻿using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IPessoaJuridicaRepositorio _pessoaJuridicaRepositorio;

        public PessoaJuridicaService(IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            _pessoaJuridicaRepositorio = pessoaJuridicaRepositorio;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            return _pessoaJuridicaRepositorio.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            return _pessoaJuridicaRepositorio.Atualizar(cliente);
        }

        public void Dispose()
        {
            _pessoaJuridicaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PessoaJuridica> ObterPorCPNJ(string cnpj)
        {
            return _pessoaJuridicaRepositorio.ObterPorCPNJ(cnpj);
        }

        public Cliente ObterPorId(int id)
        {
            return _pessoaJuridicaRepositorio.ObterPorId(id);
        }

        public IEnumerable<PessoaJuridica> ObterPorInscricaoEstadual(string inscricaoEstadual)
        {
            return _pessoaJuridicaRepositorio.ObterPorInscricaoEstadual(inscricaoEstadual);
        }

        public IEnumerable<PessoaJuridica> ObterPorNomeFantasia(string nomeFantasia)
        {
            return _pessoaJuridicaRepositorio.ObterPorNomeFantasia(nomeFantasia);
        }

        public IEnumerable<PessoaJuridica> ObterPorRazaoSocial(string razaoSocial)
        {
            return _pessoaJuridicaRepositorio.ObterPorRazaoSocial(razaoSocial);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _pessoaJuridicaRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _pessoaJuridicaRepositorio.Remover(id);
        }
    }
}
