using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!usuario.EhValido())
                return usuario;

            return _usuarioRepositorio.Adicionar(usuario);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            if (!usuario.EhValido())
                return usuario;

            return _usuarioRepositorio.Atualizar(usuario);
        }

        public bool AtualizarFotoPerfil(int id, string caminhoImagem)
        {
            var usuario = _usuarioRepositorio.ObterPorId(id);
            if (usuario != null)
            {
                usuario.FotoPerfil = caminhoImagem;
                _usuarioRepositorio.Atualizar(usuario);
                return true;
            }
            return false;
        }

        public bool Desativar(int id)
        {
            var usuario = _usuarioRepositorio.ObterPorId(id);
            if (usuario != null)
            {
                usuario.Ativo = false;
                _usuarioRepositorio.Atualizar(usuario);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _usuarioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario ObterPorId(int id)
        {
            return _usuarioRepositorio.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepositorio.ObterTodos();
        }

        public void RecuperarSenha(string email)
        {
            throw new NotImplementedException();
        }

        public void RedefinirSenha(int usuarioId, string senhaAtual, string novaSenha)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _usuarioRepositorio.SaveChanges();
        }
    }
}
