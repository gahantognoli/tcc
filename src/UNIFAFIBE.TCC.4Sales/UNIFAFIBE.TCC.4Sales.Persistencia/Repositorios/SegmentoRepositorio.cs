using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class SegmentoRepositorio : Repositorio<Segmento>, ISegmentoRepositorio
    {
        public SegmentoRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Segmento ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Segmento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Segmento> ObterPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }
    }
}
