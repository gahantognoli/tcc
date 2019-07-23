using AutoMapper;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class StatusPedidoAppService : AppService, IStatusPedidoAppService
    {
        private readonly IStatusPedidoService _statusPedidoService;

        public StatusPedidoAppService(IStatusPedidoService statusPedidoService, IUnitOfWork uow)
            : base(uow)
        {
            _statusPedidoService = statusPedidoService;
        }

        public StatusPedidoViewModel Adicionar(StatusPedidoViewModel statusPedido)
        {
            var statusPedidoRetorno = Mapper.Map<StatusPedidoViewModel>
                (_statusPedidoService.Adicionar(Mapper.Map<StatusPedido>(statusPedido)));

            if (statusPedidoRetorno.EhValido())
                Commit();
            
            return statusPedidoRetorno;
        }

        public StatusPedidoViewModel Atualizar(StatusPedidoViewModel statusPedido)
        {
            var statusPedidoRetorno = Mapper.Map<StatusPedidoViewModel>
                (_statusPedidoService.Atualizar(Mapper.Map<StatusPedido>(statusPedido)));

            if (statusPedidoRetorno.EhValido())
                Commit();

            return statusPedidoRetorno;
        }

        public IEnumerable<StatusPedidoViewModel> ObterPorDescricao(string descricao)
        {
            return Mapper.Map<IEnumerable<StatusPedidoViewModel>>(_statusPedidoService.ObterPorDescricao(descricao));
        }

        public StatusPedidoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<StatusPedidoViewModel>(_statusPedidoService.ObterPorId(id));
        }

        public IEnumerable<StatusPedidoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<StatusPedidoViewModel>>(_statusPedidoService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _statusPedidoService.Remover(id);
            Commit();
        }
    }
}
