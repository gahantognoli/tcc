using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepositorio _perfilRepositorio;

        public PerfilService(IPerfilRepositorio perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }

        public Perfil Adicionar(Perfil perfil)
        {
            return _perfilRepositorio.Adicionar(perfil);
        }

        public Perfil Atualizar(Perfil perfil)
        {
            return _perfilRepositorio.Atualizar(perfil);
        }

        public void Dispose()
        {
            _perfilRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Perfil ObterPorId(int id)
        {
            return _perfilRepositorio.ObterPorId(id);
        }

        public IEnumerable<Perfil> ObterTodos()
        {
            return _perfilRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _perfilRepositorio.Remover(id);
        }
    }
}
