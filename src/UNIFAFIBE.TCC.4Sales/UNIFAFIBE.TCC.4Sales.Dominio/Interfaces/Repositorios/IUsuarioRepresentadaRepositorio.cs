using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepresentadaRepositorio : IRepositorio<UsuarioRepresentada>
    {
        IEnumerable<UsuarioRepresentada> ObterPorRepresentada(Guid representadaId);
        IEnumerable<UsuarioRepresentada> ObterPorUsuario(Guid usuarioId);
    }
}
