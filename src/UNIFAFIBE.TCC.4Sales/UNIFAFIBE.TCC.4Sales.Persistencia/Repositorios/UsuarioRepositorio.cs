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
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Usuario ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            Usuario retornoUsuario;

            retornoUsuario = cn.Query<Usuario>(UsuarioProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

            return retornoUsuario;
        }

        public override IEnumerable<Usuario> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<Usuario> retornoUsuario;

            retornoUsuario = cn.Query<Usuario>(UsuarioProcedures.ObterTodos.GetDescription(),
                null,
                commandType: CommandType.StoredProcedure);

            return retornoUsuario;
        }

        public IEnumerable<Usuario> ObterPorNome(string nome)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Usuario> retornoUsuario;

            retornoUsuario = cn.Query<Usuario>(UsuarioProcedures.ObterPorNome.GetDescription(),
                new { nome = nome },
                commandType: CommandType.StoredProcedure);

            return retornoUsuario;
        }

        public IEnumerable<Usuario> ObterPorEmail(string email)
        {
            var cn = Db.Database.Connection;
            IEnumerable<Usuario> retornoUsuario;

            retornoUsuario = cn.Query<Usuario>(UsuarioProcedures.ObterPorEmail.GetDescription(),
                new { email = email },
                commandType: CommandType.StoredProcedure);

            return retornoUsuario;
        }
    }
}
