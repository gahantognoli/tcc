using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class RepresentadaAppService : AppService, IRepresentadaAppService
    {
        private readonly IRepresentadaService _representadaService;
        private readonly IContatoRepresentadaService _contatoRepresentadaService;
        private readonly ICondicaoPagamentoService _condicaoPagamentoService;
        private readonly IProdutoService _produtoService;
        private readonly IPedidoService _pedidoService;
        //private readonly IUsuarioRepresentadaService _usuarioRepresentadaService;

        public RepresentadaAppService(IRepresentadaService representadaService, IUnitOfWork uow,
            IContatoRepresentadaService contatoRepresentadaService,
            ICondicaoPagamentoService condicaoPagamentoService,
            IProdutoService produtoService,
            IPedidoService pedidoService
            //IUsuarioRepresentadaService usuarioRepresentadaService
            )
            : base(uow)
        {
            _representadaService = representadaService;
            _contatoRepresentadaService = contatoRepresentadaService;
            _condicaoPagamentoService = condicaoPagamentoService;
            _produtoService = produtoService;
            _pedidoService = pedidoService;
            //_usuarioRepresentadaService = usuarioRepresentadaService;
        }

        public RepresentadaViewModel Adicionar(RepresentadaViewModel representada)
        {
            var representadaRetorno = Mapper.Map<RepresentadaViewModel>
                (_representadaService.Adicionar(Mapper.Map<Representada>(representada)));

            if (representadaRetorno.EhValido())
                Commit();
            
            return representadaRetorno;
        }

        public RepresentadaViewModel Atualizar(RepresentadaViewModel representada)
        {
            var representadaRetorno = Mapper.Map<RepresentadaViewModel>
                (_representadaService.Atualizar(Mapper.Map<Representada>(representada)));

            if (representadaRetorno.EhValido())
                Commit();

            return representadaRetorno;
        }

        public void Dispose()
        {
            _condicaoPagamentoService.Dispose();
            _contatoRepresentadaService.Dispose();
            _pedidoService.Dispose();
            _produtoService.Dispose();
            _representadaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<RepresentadaViewModel> ObterPorCnpj(string cnpj)
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterPorCnpj(cnpj));
        }

        public RepresentadaViewModel ObterPorId(Guid id)
        {
            var representada = Mapper.Map<RepresentadaViewModel>(_representadaService.ObterPorId(id));
            foreach (var item in Mapper.Map<IEnumerable<ContatoRepresentadaViewModel>>(_contatoRepresentadaService.ObterTodos(id)))
            {
                representada.ContatosRepresentada.Add(item);
            }

            foreach (var item in Mapper.Map<IEnumerable<CondicaoPagamentoViewModel>>(_condicaoPagamentoService.ObterTodos(id)))
            {
                representada.CondicoesPagamento.Add(item);
            }

            return representada;
        }

        public IEnumerable<RepresentadaViewModel> ObterPorNomeFantansia(string nomeFantasia)
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterPorNomeFantansia(nomeFantasia));
        }

        public IEnumerable<RepresentadaViewModel> ObterPorRazaoSocial(string razaoSocial)
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterPorRazaoSocial(razaoSocial));
        }

        public IEnumerable<RepresentadaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RepresentadaViewModel>>(_representadaService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            var contatosRepresentada = _contatoRepresentadaService.ObterTodos(id);
            if (contatosRepresentada.Count() > 0)
            {
                contatosRepresentada.ToList().ForEach(c => _contatoRepresentadaService.Remover(c.ContatoRepresentadaId));
            }

            var produtosRepresentada = _produtoService.ObterTodos(id);
            if (produtosRepresentada.Count() > 0)
            {
                produtosRepresentada.ToList().ForEach(p => _produtoService.Remover(p.ProdutoId));
            }
            
            var pedidosRepresentada = _pedidoService.ObterPorRepresentada(id);
            if (pedidosRepresentada.Count() > 0)
            {
                pedidosRepresentada.ToList().ForEach(p => _pedidoService.Remover(p.PedidoId));
            }

            var condicoesPagamento = _condicaoPagamentoService.ObterTodos(id);
            if (condicoesPagamento.Count() > 0)
            {
                condicoesPagamento.ToList().ForEach(c => _condicaoPagamentoService.Remover(c.CondicaoPagamentoId));
            }

            _representadaService.Remover(id);
            Commit();
        }
    }
}
