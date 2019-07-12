using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        bool Desativar(int id);
        void RecuperarSenha(string email);
        void RedefinirSenha(int usuarioId, string senhaAtual, string novaSenha);
        bool AtualizarFotoPerfil(int id, string caminhoImagem);
        Usuario ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        int SaveChanges();
    }
}
