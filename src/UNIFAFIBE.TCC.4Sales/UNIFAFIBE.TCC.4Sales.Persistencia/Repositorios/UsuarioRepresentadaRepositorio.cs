//using Dapper;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
//using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
//using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
//using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;
//using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures;

//namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
//{
//    public class UsuarioRepresentadaRepositorio : Repositorio<UsuarioRepresentada>, IUsuarioRepresentadaRepositorio
//    {
//        public UsuarioRepresentadaRepositorio(TCC_Contexto contexto) : base(contexto)
//        {
//        }

//        public IEnumerable<UsuarioRepresentada> ObterPorRepresentada(Guid representadaId)
//        {
//            var cn = Db.Database.Connection;
//            IEnumerable<UsuarioRepresentada> retornoUsuarioRepresentada;

//            retornoUsuarioRepresentada = cn.Query<UsuarioRepresentada>(UsuarioRepresentadaProcedures.ObterPorRepresentada.GetDescription(),
//                new { representadaId = representadaId },
//                commandType: CommandType.StoredProcedure);

//            return retornoUsuarioRepresentada;
//        }

//        public IEnumerable<UsuarioRepresentada> ObterPorUsuario(Guid usuarioId)
//        {
//            var cn = Db.Database.Connection;
//            IEnumerable<UsuarioRepresentada> retornoUsuarioRepresentada;

//            retornoUsuarioRepresentada = cn.Query<UsuarioRepresentada>(UsuarioRepresentadaProcedures.ObterPorUsuario.GetDescription(),
//                new { usuarioId = usuarioId },
//                commandType: CommandType.StoredProcedure);

//            return retornoUsuarioRepresentada;
//        }
//    }
//}
