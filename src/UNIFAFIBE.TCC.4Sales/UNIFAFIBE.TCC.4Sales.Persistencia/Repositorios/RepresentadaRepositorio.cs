using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class RepresentadaRepositorio : Repositorio<Representada>, IRepresentadaRepositorio
    {

        public RepresentadaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Representada ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Representada> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Representada> ObterPorCnpj(string cnpj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Representada> ObterPorNomeFantansia(string nomeFantasia)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Representada> ObterPorRazaoSocial(string razaoSocial)
        {
            throw new NotImplementedException();
        }
    }
}
