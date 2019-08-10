using Dapper;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public override Usuario Adicionar(Usuario obj)
        {
            foreach (var item in obj.Representadas)
            {
                Db.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
            }
            return base.Adicionar(obj);
        }
        public override Usuario ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            IEnumerable<dynamic> query = cn.Query<dynamic>(UsuarioProcedures.ObterPorId.GetDescription(),
                new { id = id },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Representada), "RepresentadaId");

            Usuario usuario = (AutoMapper.MapDynamic<Usuario>(query, false) as IEnumerable<Usuario>).FirstOrDefault();

            return usuario;
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

        public override Usuario Atualizar(Usuario obj)
        {
            Usuario existingUser = Db.Usuarios.Include("Representadas")
                .Where(e => e.UsuarioId == obj.UsuarioId).FirstOrDefault<Usuario>();

            List<Representada> deletedRepresentadas = existingUser.Representadas.Except(obj.Representadas, p => p.RepresentadaId).ToList<Representada>();

            List<Representada> addedPermissions = obj.Representadas.Except(existingUser.Representadas, p => p.RepresentadaId).ToList<Representada>();

            deletedRepresentadas.ForEach(p => existingUser.Representadas.Remove(p));

            foreach (Representada p in addedPermissions)
            {
                if (Db.Entry(p).State == System.Data.Entity.EntityState.Detached)
                {
                    Db.Representadas.Attach(p);
                }
                existingUser.Representadas.Add(p);
            }

            Db.Set<Usuario>().AddOrUpdate(obj);

            return existingUser;
        }

        public Usuario AlterarSenha(Guid usuarioId, string novaSenha)
        {
            Usuario usuario = Db.Usuarios.Find(usuarioId);
            usuario.Senha = novaSenha;
            return usuario;
        }

        public void Desativar(Guid Id)
        {
            var usuario = Db.Usuarios.Find(Id);
            usuario.Ativo = false;
        }

        public Usuario EditarPerfil(Usuario usuario)
        {
            var entry = Db.Entry(usuario);
            DbSet.Attach(usuario);
            entry.State = EntityState.Modified;

            foreach (var item in usuario.Representadas)
            {
                Db.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
            }

            return usuario;
        }
    }
}
