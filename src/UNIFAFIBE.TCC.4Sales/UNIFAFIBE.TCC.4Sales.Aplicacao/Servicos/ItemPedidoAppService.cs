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
    public class ItemPedidoAppService : AppService, IItemPedidoAppService
    {
        private readonly IItemPedidoService _itemPedidoService;

        public ItemPedidoAppService(IItemPedidoService itemPedidoService, IUnitOfWork uow)
            : base(uow)
        {
            _itemPedidoService = itemPedidoService;
        }

        public ItemPedidoViewModel Adicionar(ItemPedidoViewModel itemPedido)
        {
            var itemPedidoRetorno = Mapper.Map<ItemPedidoViewModel>
                (_itemPedidoService.Adicionar(Mapper.Map<ItemPedido>(itemPedido)));

            if (itemPedidoRetorno.EhValido())
                Commit();
            
            return itemPedidoRetorno;
        }

        public ItemPedidoViewModel Atualizar(ItemPedidoViewModel itemPedido)
        {
            var itemPedidoRetorno = Mapper.Map<ItemPedidoViewModel>
                (_itemPedidoService.Atualizar(Mapper.Map<ItemPedido>(itemPedido)));

            if (itemPedidoRetorno.EhValido())
                Commit();

            return itemPedidoRetorno;
        }

        public ItemPedidoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ItemPedidoViewModel>(_itemPedidoService.ObterPorId(id));
        }

        public IEnumerable<ItemPedidoViewModel> ObterTodos(Guid pedidoId)
        {
            return Mapper.Map<IEnumerable<ItemPedidoViewModel>>(_itemPedidoService.ObterTodos(pedidoId));
        }

        public void Remover(Guid id)
        {
            _itemPedidoService.Remover(id);
            Commit();
        }
    }
}
