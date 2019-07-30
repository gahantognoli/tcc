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

        public PessoaFisica Adicionar(PessoaFisica pessoaFisica)
        {
            if (!pessoaFisica.EhValido(_pessoaFisicaRepositorio))
                return pessoaFisica;

            return _pessoaFisicaRepositorio.Adicionar(pessoaFisica);
        }

        public PessoaFisica Atualizar(PessoaFisica pessoaFisica)
        {
            if (!pessoaFisica.EstaConsistente())
                return pessoaFisica;

            _pessoaFisicaRepositorio.Atualizar(pessoaFisica);
            return pessoaFisica;
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

        public PessoaFisica ObterPorId(Guid id)
        {
            return _pessoaFisicaRepositorio.ObterPorId(id);
        }

        public IEnumerable<PessoaFisica> ObterPorNome(string nome)
        {
            return _pessoaFisicaRepositorio.ObterPorNome(nome);
        }

        public IEnumerable<PessoaFisica> ObterTodos()
        {
            return _pessoaFisicaRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _pessoaFisicaRepositorio.Remover(id);
        }
    }
}
