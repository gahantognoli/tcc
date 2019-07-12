using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IPerfilService : IDisposable
    {
        Perfil Adicionar(Perfil perfil);
        Perfil Atualizar(Perfil perfil);
        void Remover(int id);
        Perfil ObterPorId(int id);
        IEnumerable<Perfil> ObterTodos();
    }
}
