using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        Usuario EditarPerfil(Usuario usuario);
        void Desativar(Guid id);
        void EnviarSenhaPorEmail(Email email);
        Usuario AlterarSenha(Guid usuarioId, string novaSenha);
        Usuario ObterPorId(Guid id);
        IEnumerable<Usuario> ObterTodos();
        int SaveChanges();
    }
}
