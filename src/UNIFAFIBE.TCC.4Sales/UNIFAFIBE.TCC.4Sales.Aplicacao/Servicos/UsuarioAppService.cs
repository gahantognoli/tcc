using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRepresentadaService _representadaService;

        public UsuarioAppService(IUsuarioService usuarioService, IRepresentadaService representadaService,
            IUnitOfWork uow)
            : base(uow)
        {
            _usuarioService = usuarioService;
            _representadaService = representadaService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuario)
        {
            usuario.Senha = GerarSenhaTemporaria();
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>
                (_usuarioService.Adicionar(Mapper.Map<Usuario>(usuario)));

            if (usuarioRetorno.EhValido())
            {
                Commit();
                Email email = MontarEmailSenha(usuarioRetorno);
                _usuarioService.EnviarSenhaPorEmail(email);
            }

            return usuarioRetorno;
        }

        private Email MontarEmailSenha(UsuarioViewModel usuarioRetorno)
        {
            Email email = new Email();
            email.Assunto = "4Sales - Sua senha";
            email.Destinatios.Add(usuarioRetorno.Email);
            email.Mensagem = $"Olá {usuarioRetorno.Nome}, sua senha é " + usuarioRetorno.Senha + ".";
            email.Mensagem += "\n\r\n\rSerá solicitado alteração dessa senha no seu primeiro acesso ao sistema";
            return email;
        }

        private string GerarSenhaTemporaria()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuario)
        {
            var usuarioTemp = _usuarioService.ObterPorId(usuario.UsuarioId);
            usuario.Senha = usuarioTemp.Senha;
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>
                 (_usuarioService.Atualizar(Mapper.Map<Usuario>(usuario)));

            if (usuarioRetorno.EhValido())
                Commit();

            return usuarioRetorno;
        }

        public void Desativar(Guid id)
        {
            _usuarioService.Desativar(id);
            Commit();
        }

        public UsuarioRepresentadaCadastroViewModel ObterDadosUsuario(Guid id)
        {
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>(_usuarioService.ObterPorId(id));
            var representadasRetorno = Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterTodos());

            UsuarioRepresentadaCadastroViewModel usuarioRepresentadaCadastroViewModel = new UsuarioRepresentadaCadastroViewModel();
            usuarioRepresentadaCadastroViewModel.UsuarioViewModel = usuarioRetorno;
            usuarioRepresentadaCadastroViewModel.RepresentadasViewModel = representadasRetorno;

            return usuarioRepresentadaCadastroViewModel;
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioService.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodos());
        }

        public int SaveChanges()
        {
            return _usuarioService.SaveChanges();
        }

        public UsuarioViewModel AlterarSenha(Guid usuarioId, string novaSenha)
        {
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>
                 (_usuarioService.AlterarSenha(usuarioId, novaSenha));

            if (usuarioRetorno.EhValido())
                Commit();

            return usuarioRetorno;
        }

        public UsuarioViewModel EditarPerfil(UsuarioViewModel usuario)
        {
            var usuarioTemp  = _usuarioService.ObterPorId(usuario.UsuarioId);
            usuario.Senha = usuarioTemp.Senha;
            usuario.Representadas = Mapper.Map<ICollection<RepresentadaViewModel>>(usuarioTemp.Representadas);
            usuario.UsuarioResponsavel = usuarioTemp.UsuarioResponsavel;
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>
                 (_usuarioService.EditarPerfil(Mapper.Map<Usuario>(usuario)));

            if (usuarioRetorno.EhValido())
                Commit();

            return usuarioRetorno;
        }

        public void Dispose()
        {
            _representadaService.Dispose();
            _usuarioService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
