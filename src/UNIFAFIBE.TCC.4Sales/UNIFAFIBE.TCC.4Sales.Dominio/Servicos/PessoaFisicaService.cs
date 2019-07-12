using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepositorio _pessoaFisicaRepositorio;
        public PessoaFisicaService(IPessoaFisicaRepositorio pessoaFisicaRepositorio)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            return _pessoaFisicaRepositorio.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return cliente;

            return _pessoaFisicaRepositorio.Atualizar(cliente);
        }

        public void Dispose()
        {
            _pessoaFisicaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PessoaFisica> ObterPorCPF(string cpf)
        {
            return _pessoaFisicaRepositorio.ObterPorCPF(cpf);
        }

        public Cliente ObterPorId(int id)
        {
            return _pessoaFisicaRepositorio.ObterPorId(id);
        }

        public IEnumerable<PessoaFisica> ObterPorNome(string nome)
        {
            return _pessoaFisicaRepositorio.ObterPorNome(nome);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _pessoaFisicaRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _pessoaFisicaRepositorio.Remover(id);
        }
    }
}
