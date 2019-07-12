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
    public class PerfilRepositorio : Repositorio<Perfil>, IPerfilRepositorio
    {
        public PerfilRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Perfil ObterPorId(int id)
        {
            var cn = Db.Database.Connection;
            Perfil retornoPerfil;

            retornoPerfil = cn.Query<Perfil>(PerfilProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoPerfil;
        }

        public override IEnumerable<Perfil> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Perfil> ObterPorDescricao(string descricao)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Perfil> retornoPerfil;

            retornoPerfil = cn.Query<Perfil>(PerfilProcedures.ObterPorId.GetDescription(),
                new { descricao = descricao },
                commandType: CommandType.StoredProcedure);

            return retornoPerfil;
        }
    }
}
