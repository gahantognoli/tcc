using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class RepresentadaRepositorio : Repositorio<Representada>, IRepresentadaRepositorio
    {

        public RepresentadaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Representada ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Representada retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoRepresentada;
        }

        public override IEnumerable<Representada> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Representada> ObterPorCnpj(string cnpj)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Representada> retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorCnpj.GetDescription(),
                new { cnpj = cnpj },
                commandType: CommandType.StoredProcedure);

            return retornoRepresentada;
        }

        public IEnumerable<Representada> ObterPorNomeFantansia(string nomeFantasia)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Representada> retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorNomeFantasia.GetDescription(),
                new { nomeFantasia = nomeFantasia },
                commandType: CommandType.StoredProcedure);

            return retornoRepresentada;
        }

        public IEnumerable<Representada> ObterPorRazaoSocial(string razaoSocial)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Representada> retornoRepresentada;

            retornoRepresentada = cn.Query<Representada>(RepresentadaProcedures.ObterPorRazaoSocial.GetDescription(),
                new { razaoSocial = razaoSocial },
                commandType: CommandType.StoredProcedure);

            return retornoRepresentada;
        }
    }
}
