using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class TransportadoraRepositorio : Repositorio<Transportadora>, ITransportadoraRepositorio
    {
        public TransportadoraRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Transportadora ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Transportadora> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transportadora> ObterPorCidade(string cidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transportadora> ObterPorEstado(string estado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transportadora> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
