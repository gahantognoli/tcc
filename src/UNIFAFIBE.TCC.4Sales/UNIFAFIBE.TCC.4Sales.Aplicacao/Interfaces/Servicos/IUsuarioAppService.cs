using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuario);
        UsuarioViewModel Atualizar(UsuarioViewModel usuario);
        bool Desativar(Guid id);
        bool RecuperarSenha(string email);
        bool RedefinirSenha(Guid usuarioId, string senhaAtual, string novaSenha);
        bool AtualizarFotoPerfil(Guid id, string caminhoImagem);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        int SaveChanges();
    }
}
