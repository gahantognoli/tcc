using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        void Desativar(int id);
        void RecuperarSenha(string email);
        void RedefinirSenha(string senhaAtual, string novaSenha);
        void AtualizarFotoPerfil(int id, string caminhoUsuario);
        Usuario ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        int SaveChanges();
    }
}
