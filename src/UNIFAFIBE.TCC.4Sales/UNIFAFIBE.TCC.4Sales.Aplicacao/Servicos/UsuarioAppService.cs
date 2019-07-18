using AutoMapper;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService, IUnitOfWork uow)
            : base(uow)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuario)
        {
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>
                (_usuarioService.Adicionar(Mapper.Map<Usuario>(usuario)));

            if (usuarioRetorno.EhValido())
                Commit();
            
            return usuarioRetorno;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuario)
        {
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>
                 (_usuarioService.Adicionar(Mapper.Map<Usuario>(usuario)));

            if (usuarioRetorno.EhValido())
                Commit();

            return usuarioRetorno;
        }

        public bool AtualizarFotoPerfil(Guid id, string caminhoImagem)
        {
            return _usuarioService.AtualizarFotoPerfil(id, caminhoImagem);
        }

        public bool Desativar(Guid id)
        {
            return _usuarioService.Desativar(id);
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioService.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodos());
        }

        public bool RecuperarSenha(string email)
        {
            return _usuarioService.RecuperarSenha(email);
        }

        public bool RedefinirSenha(Guid usuarioId, string senhaAtual, string novaSenha)
        {
            return _usuarioService.RedefinirSenha(usuarioId, senhaAtual, novaSenha);
        }

        public int SaveChanges()
        {
            return _usuarioService.SaveChanges();
        }
    }
}
