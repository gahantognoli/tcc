using AutoMapper;
using System;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class UsuarioRepresentadaAppService : IUsuarioRepresentadaAppService
    {
        private readonly IUsuarioRepresentadaService _usuarioRepresentadaService;
        public UsuarioRepresentadaAppService(IUsuarioRepresentadaService usuarioRepresentadaService)
        {
            _usuarioRepresentadaService = usuarioRepresentadaService;
        }

        public UsuarioRepresentadaViewModel Adicionar(UsuarioRepresentadaViewModel UsuarioRepresentadaViewModel)
        {
            return Mapper.Map<UsuarioRepresentadaViewModel>
                (_usuarioRepresentadaService.Adicionar(Mapper.Map<UsuarioRepresentada>(UsuarioRepresentadaViewModel)));
        }

        public UsuarioRepresentadaViewModel Atualizar(UsuarioRepresentadaViewModel UsuarioRepresentadaViewModel)
        {
            return Mapper.Map<UsuarioRepresentadaViewModel>
                (_usuarioRepresentadaService.Atualizar(Mapper.Map<UsuarioRepresentada>(UsuarioRepresentadaViewModel)));
        }

        public UsuarioRepresentadaViewModel ObterPorRepresentada(Guid representadaId)
        {
            return Mapper.Map<UsuarioRepresentadaViewModel>
                (_usuarioRepresentadaService.ObterPorRepresentada(representadaId));
        }

        public UsuarioRepresentadaViewModel ObterPorUsuario(Guid usuarioId)
        {
            return Mapper.Map<UsuarioRepresentadaViewModel>
                (_usuarioRepresentadaService.ObterPorUsuario(usuarioId));
        }

        public void Remover(Guid usuarioRepresentadaId)
        {
            _usuarioRepresentadaService.Remover(usuarioRepresentadaId);
        }
    }
}
