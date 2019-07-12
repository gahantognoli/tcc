using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class RepresentadaService : IRepresentadaService
    {
        private readonly IRepresentadaRepositorio _representadaRepositorio;

        public RepresentadaService(IRepresentadaRepositorio representadaRepositorio)
        {
            _representadaRepositorio = representadaRepositorio;
        }

        public Representada Adicionar(Representada representada)
        {
            if (!representada.EhValido())
                return representada;

            return _representadaRepositorio.Adicionar(representada);
        }

        public Representada Atualizar(Representada representada)
        {
            if (!representada.EhValido())
                return representada;

            return _representadaRepositorio.Adicionar(representada);
        }

        public void Dispose()
        {
            _representadaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Representada> ObterPorCnpj(string cnpj)
        {
            return _representadaRepositorio.ObterPorCnpj(cnpj);
        }

        public Representada ObterPorId(int id)
        {
            return _representadaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Representada> ObterPorNomeFantansia(string nomeFantasia)
        {
            return _representadaRepositorio.ObterPorNomeFantansia(nomeFantasia);
        }

        public IEnumerable<Representada> ObterPorRazaoSocial(string razaoSocial)
        {
            return _representadaRepositorio.ObterPorRazaoSocial(razaoSocial);
        }

        public IEnumerable<Representada> ObterTodos()
        {
            return _representadaRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _representadaRepositorio.Remover(id);
        }
    }
}
