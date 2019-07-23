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
    public class ProdutoAppService : AppService, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService, IUnitOfWork uow)
            : base(uow)
        {
            _produtoService = produtoService;
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produto)
        {
            var produtoRetorno = Mapper.Map<ProdutoViewModel>(_produtoService.Adicionar(Mapper.Map<Produto>(produto)));

            if (produtoRetorno.EhValido())
                Commit();
            
            return produtoRetorno;
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produto)
        {
            var produtoRetorno = Mapper.Map<ProdutoViewModel>(_produtoService.Atualizar(Mapper.Map<Produto>(produto)));

            if (produtoRetorno.EhValido())
                Commit();

            return produtoRetorno;
        }

        public IEnumerable<ProdutoViewModel> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal, Guid representadaId)
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.ObterPorFaixaDePreco(valorInicial, valorFinal, representadaId));
        }

        public ProdutoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ProdutoViewModel>(_produtoService.ObterPorId(id));
        }

        public IEnumerable<ProdutoViewModel> ObterPorNome(string nome, Guid representadaId)
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.ObterPorNome(nome,representadaId));
        }

        public IEnumerable<ProdutoViewModel> ObterTodos(Guid representadaId)
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.ObterTodos(representadaId));
        }

        public void Remover(Guid id)
        {
            _produtoService.Remover(id);
            Commit();
        }
    }
}
