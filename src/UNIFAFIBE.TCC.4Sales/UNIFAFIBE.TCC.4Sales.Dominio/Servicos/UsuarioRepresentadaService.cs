using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class UsuarioRepresentadaService : IUsuarioRepresentadaService
    {
        private readonly IUsuarioRepresentadaRepositorio _usuarioRepresentadaRepositorio;
        public UsuarioRepresentadaService(IUsuarioRepresentadaRepositorio usuarioRepresentadaRepositorio)
        {
            _usuarioRepresentadaRepositorio = usuarioRepresentadaRepositorio;
        }

        public UsuarioRepresentada Adicionar(UsuarioRepresentada usuarioRepresentada)
        {
            return _usuarioRepresentadaRepositorio.Adicionar(usuarioRepresentada);
        }

        public UsuarioRepresentada Atualizar(UsuarioRepresentada usuarioRepresentada)
        {
            return _usuarioRepresentadaRepositorio.Atualizar(usuarioRepresentada);
        }

        public IEnumerable<UsuarioRepresentada> ObterPorRepresentada(Guid representadaId)
        {
            return _usuarioRepresentadaRepositorio.ObterPorRepresentada(representadaId);
        }

        public IEnumerable<UsuarioRepresentada> ObterPorUsuario(Guid usuarioId)
        {
            return _usuarioRepresentadaRepositorio.ObterPorUsuario(usuarioId);
        }

        public void Remover(Guid usuarioRepresentadaId)
        {
            _usuarioRepresentadaRepositorio.Remover(usuarioRepresentadaId);
        }
    }
}
