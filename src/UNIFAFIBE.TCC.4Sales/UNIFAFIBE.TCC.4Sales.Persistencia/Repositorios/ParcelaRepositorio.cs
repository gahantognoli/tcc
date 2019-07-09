using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class ParcelaRepositorio : Repositorio<Parcela>, IParcelaRepositorio
    {
        public ParcelaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Parcela ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Parcela> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parcela> ObterTodos(int faturamentoId)
        {
            throw new NotImplementedException();
        }
    }
}
