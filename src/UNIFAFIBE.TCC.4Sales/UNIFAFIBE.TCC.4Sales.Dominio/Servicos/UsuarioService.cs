﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Usuario Atualizar(Usuario usuario)
        {
            if (!usuario.EstaConsistente())
                return usuario;

            return _usuarioRepositorio.Atualizar(usuario);
        }

        public bool AtualizarFotoPerfil(Guid id, string caminhoImagem)
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

        public bool Desativar(Guid id)
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

        public Usuario ObterPorId(Guid id)
        {
            return _usuarioRepositorio.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepositorio.ObterTodos();
        }

        public bool RecuperarSenha(string email)
        {
            var usuario = _usuarioRepositorio.ObterPorEmail(email);

            List<string> destinatarios = new List<string>();
            destinatarios.Add(usuario.FirstOrDefault().Email);

            var mensagem = new StringBuilder();
            mensagem.Append("Olá, ");
            mensagem.Append(usuario.FirstOrDefault().Nome);
            mensagem.Append(" sua senha é: ");
            mensagem.Append(usuario.FirstOrDefault().Senha);

            if (usuario != null)
            {
                return _emailService.Enviar(new Email()
                {
                    Destinatios = destinatarios,
                    Assunto = "4Sales - Sua senha",
                    Mensagem = mensagem.ToString(),
                    Rementente = "foursales.contato@gmail.com"
                });
            }
            return false;
        }

        public bool RedefinirSenha(Guid usuarioId, string senhaAtual, string novaSenha)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _usuarioRepositorio.SaveChanges();
        }
    }
}