using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        IEnumerable<Usuario> ObterPorNome(string nome);
        Usuario ObterPorEmail(string email);
        Usuario EditarPerfil(Usuario usuario);
        Usuario AlterarSenha(Guid usuarioId, string novaSenha);
        void Desativar(Guid Id);
        bool Logar(string email, string senha);
        Usuario AlterarPrimeiroAcesso(Guid usuarioId);
    }
}
