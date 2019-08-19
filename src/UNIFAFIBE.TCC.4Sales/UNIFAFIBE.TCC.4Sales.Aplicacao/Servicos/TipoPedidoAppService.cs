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
    public class TipoPedidoAppService : AppService, ITipoPedidoAppService
    {
        private readonly ITipoPedidoService _tipoPedidoService;

        public TipoPedidoAppService(ITipoPedidoService tipoPedidoService, IUnitOfWork uow)
            : base(uow)
        {
            _tipoPedidoService = tipoPedidoService;
        }

        public TipoPedidoViewModel Adicionar(TipoPedidoViewModel tipoPedido)
        {
            var tipoPedidoRetorno = Mapper.Map<TipoPedidoViewModel>
                (_tipoPedidoService.Adicionar(Mapper.Map<TipoPedido>(tipoPedido)));

            if (tipoPedidoRetorno.EhValido())
                Commit();
            
            return tipoPedidoRetorno;
        }

        public TipoPedidoViewModel Atualizar(TipoPedidoViewModel tipoPedido)
        {
            var tipoPedidoRetorno = Mapper.Map<TipoPedidoViewModel>
                (_tipoPedidoService.Atualizar(Mapper.Map<TipoPedido>(tipoPedido)));

            if (tipoPedidoRetorno.EhValido())
                Commit();

            return tipoPedidoRetorno;
        }

        public void Dispose()
        {
            _tipoPedidoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TipoPedidoViewModel> ObterPorDescricao(string tipoPedido)
        {
            return Mapper.Map<IEnumerable<TipoPedidoViewModel>>(_tipoPedidoService.ObterPorDescricao(tipoPedido));
        }

        public TipoPedidoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<TipoPedidoViewModel>(_tipoPedidoService.ObterPorId(id));
        }

        public IEnumerable<TipoPedidoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoPedidoViewModel>>(_tipoPedidoService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _tipoPedidoService.Remover(id);
            Commit();
        }
    }
}
