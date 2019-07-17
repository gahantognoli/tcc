using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        bool Desativar(Guid id);
        bool RecuperarSenha(string email);
        bool RedefinirSenha(Guid usuarioId, string senhaAtual, string novaSenha);
        bool AtualizarFotoPerfil(Guid id, string caminhoImagem);
        Usuario ObterPorId(Guid id);
        IEnumerable<Usuario> ObterTodos();
        int SaveChanges();
    }
}
