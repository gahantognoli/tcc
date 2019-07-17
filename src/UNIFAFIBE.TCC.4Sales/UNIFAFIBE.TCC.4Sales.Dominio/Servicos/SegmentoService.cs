using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class SegmentoService : ISegmentoService
    {
        private readonly ISegmentoRepositorio _segmentoRepositorio;

        public SegmentoService(ISegmentoRepositorio segmentoRepositorio)
        {
            _segmentoRepositorio = segmentoRepositorio;
        }

        public Segmento Adicionar(Segmento segmento)
        {
            if (!segmento.EhValido(_segmentoRepositorio))
                return segmento;

            return _segmentoRepositorio.Adicionar(segmento);
        }

        public Segmento Atualizar(Segmento segmento)
        {
            //if (!segmento.EstaConsistente())
            //    return segmento;

            return _segmentoRepositorio.Atualizar(segmento);
        }

        public void Dispose()
        {
            _segmentoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Segmento> ObterPorDescricao(string descricao)
        {
            return _segmentoRepositorio.ObterPorDescricao(descricao);
        }

        public Segmento ObterPorId(Guid id)
        {
            return _segmentoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Segmento> ObterTodos()
        {
            return _segmentoRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _segmentoRepositorio.Remover(id);
        }
    }
}
