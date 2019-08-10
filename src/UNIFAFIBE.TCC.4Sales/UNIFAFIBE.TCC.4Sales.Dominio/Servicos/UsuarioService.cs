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
        private readonly IEmailService _emailService;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio, IEmailService emailService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _emailService = emailService;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!usuario.EhValido(_usuarioRepositorio))
                return usuario;

            return _usuarioRepositorio.Adicionar(usuario);
        }

        public Usuario AlterarSenha(Guid usuarioId, string novaSenha)
        {
            var usuario = _usuarioRepositorio.ObterPorId(usuarioId);
            usuario.Senha = novaSenha;
            if (!usuario.EstaConsistente())
                return usuario;

             _usuarioRepositorio.AlterarSenha(usuarioId, novaSenha);
            return usuario;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            if (!usuario.EstaConsistente())
                return usuario;

           var retorno = _usuarioRepositorio.Atualizar(usuario);
            retorno.ValidationResult = usuario.ValidationResult;
            return retorno;
        }

        public void Desativar(Guid id)
        {
           _usuarioRepositorio.Desativar(id);
        }

        public void Dispose()
        {
            _usuarioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario EditarPerfil(Usuario usuario)
        {
            if (!usuario.EstaConsistente())
                return usuario;

            return _usuarioRepositorio.EditarPerfil(usuario);
        }

        public void EnviarSenhaPorEmail(Email email)
        {
            _emailService.Enviar(email);
        }

        public Usuario ObterPorId(Guid id)
        {
            return _usuarioRepositorio.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepositorio.ObterTodos();
        }

        public int SaveChanges()
        {
            return _usuarioRepositorio.SaveChanges();
        }
    }
}
