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

        public IEnumerable<Meta> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _metaRepositorio.ObterPorPeriodo(dataInicio, dataFim);
        }
    }
}
