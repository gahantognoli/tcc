using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class ContatoRepresentadaService : IContatoRepresentadaService
    {
        private readonly IContatoRepresentadaRepositorio _contatoRepresentadaRepositorio;

        public ContatoRepresentadaService(IContatoRepresentadaRepositorio contatoRepresentadaRepositorio)
        {
            _contatoRepresentadaRepositorio = contatoRepresentadaRepositorio;
        }

        public ContatoRepresentada Adicionar(ContatoRepresentada contatoRepresentada)
        {
            if (!contatoRepresentada.EhValido())
                return contatoRepresentada;

            return _contatoRepresentadaRepositorio.Adicionar(contatoRepresentada);
        }

        public ContatoRepresentada Atualizar(ContatoRepresentada contatoRepresentada)
        {
            if (!contatoRepresentada.EhValido())
                return contatoRepresentada;

            return _contatoRepresentadaRepositorio.Atualizar(contatoRepresentada);
        }

        public void Dispose()
        {
            _contatoRepresentadaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public ContatoRepresentada ObterPorId(Guid id)
        {
            return _contatoRepresentadaRepositorio.ObterPorId(id);
        }

        public IEnumerable<ContatoRepresentada> ObterTodos(Guid representadaId)
        {
            return _contatoRepresentadaRepositorio.ObterTodos(representadaId);
        }

        public void Remover(Guid id)
        {
            _contatoRepresentadaRepositorio.Remover(id);
        }
    }
}
