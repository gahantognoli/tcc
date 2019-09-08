using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class MetaService : IMetaService
    {
        private IMetaRepositorio _metaRepositorio;

        public MetaService(IMetaRepositorio metaRepositorio)
        {
            _metaRepositorio = metaRepositorio;
        }

        public Meta Adicionar(Meta meta)
        {
            if (!meta.EhValido())
                return meta;

            return _metaRepositorio.Adicionar(meta);
        }

        public Meta Atualizar(Meta meta)
        {
            if (!meta.EhValido())
                return meta;

            return _metaRepositorio.Atualizar(meta);
        }

        public void Dispose()
        {
            _metaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Meta ObterPorId(Guid id)
        {
            return _metaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Meta> ObterTodos()
        {
            return _metaRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _metaRepositorio.Remover(id);
        }
    }
}
