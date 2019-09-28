using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuario);
        UsuarioViewModel Atualizar(UsuarioViewModel usuario);
        UsuarioViewModel EditarPerfil(UsuarioViewModel usuario);
        void Desativar(Guid id);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        UsuarioViewModel AlterarSenha(Guid usuarioId, string novaSenha);
        int SaveChanges();
        UsuarioRepresentadaCadastroViewModel ObterDadosUsuario(Guid id);
        bool Logar(string email, string senha);
        UsuarioViewModel ObterPorEmail(string email);
        UsuarioViewModel AlterarPrimeiroAcesso(Guid usuarioId);
    }
}
