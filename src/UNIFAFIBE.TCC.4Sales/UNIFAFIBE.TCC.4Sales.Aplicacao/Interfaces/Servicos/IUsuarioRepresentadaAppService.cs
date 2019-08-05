using System;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IUsuarioRepresentadaAppService
    {
        UsuarioRepresentadaViewModel Adicionar(UsuarioRepresentadaViewModel UsuarioRepresentadaViewModel);
        UsuarioRepresentadaViewModel Atualizar(UsuarioRepresentadaViewModel UsuarioRepresentadaViewModel);
        void Remover(Guid UsuarioRepresentadaViewModelId);
        UsuarioRepresentadaViewModel ObterPorRepresentada(Guid representadaId);
        UsuarioRepresentadaViewModel ObterPorUsuario(Guid usuarioId);
    }
}
