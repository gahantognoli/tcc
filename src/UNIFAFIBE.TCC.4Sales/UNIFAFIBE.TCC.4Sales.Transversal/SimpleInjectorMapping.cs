using SimpleInjector;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Servicos;
using UNIFAFIBE.TCC._4Sales.Dominio.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Infra.Serialization.Servicos;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;
using UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork;
using UNIFAFIBE.TCC._4Sales.Transversal.EnvioEmail;

namespace UNIFAFIBE.TCC._4Sales.Transversal
{
    public static class SimpleInjectorMapping
    {
        public static void Register(Container container)
        {
            #region Registro dos Repositórios
            container.Register<ICondicaoPagamentoRepositorio, CondicaoPagamentoRepositorio>(Lifestyle.Scoped);
            container.Register<IContatoClienteRepositorio, ContatoClienteRepositorio>(Lifestyle.Scoped);
            container.Register<IContatoRepresentadaRepositorio, ContatoRepresentadaRepositorio>(Lifestyle.Scoped);
            container.Register<IEnderecoClienteRepositorio, EnderecoClienteRepositorio>(Lifestyle.Scoped);
            container.Register<IFaturamentoRepositorio, FaturamentoRepositorio>(Lifestyle.Scoped);
            container.Register<IItemPedidoRepositorio, ItemPedidoRepositorio>(Lifestyle.Scoped);
            container.Register<IMetaRepositorio, MetaRepositorio>(Lifestyle.Scoped);
            container.Register<IParcelaRepositorio, ParcelaRepositorio>(Lifestyle.Scoped);
            container.Register<IPedidoRepositorio, PedidoRepositorio>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaRepositorio, PessoaFisicaRepositorio>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaRepositorio, PessoaJuridicaRepositorio>(Lifestyle.Scoped);
            container.Register<IProdutoRepositorio, ProdutoRepositorio>(Lifestyle.Scoped);
            container.Register<IRepresentadaRepositorio, RepresentadaRepositorio>(Lifestyle.Scoped);
            container.Register<ISegmentoRepositorio, SegmentoRepositorio>(Lifestyle.Scoped);
            container.Register<IStatusPedidoRepositorio, StatusPedidoRepositorio>(Lifestyle.Scoped);
            container.Register<ITipoPedidoRepositorio, TipoPedidoRepositorio>(Lifestyle.Scoped);
            container.Register<ITransportadoraRepositorio, TransportadoraRepositorio>(Lifestyle.Scoped);
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<IDashboardRepositorio, DashboardRepositorio>(Lifestyle.Scoped);
            //container.Register<IUsuarioRepresentadaRepositorio, UsuarioRepresentadaRepositorio>(Lifestyle.Scoped);
            container.Register<IRelatoriosVendaRepositorio, RelatoriosVendaRepositorio>(Lifestyle.Scoped);
            container.Register<IRelatoriosFaturamentoRepositorio, RelatoriosFaturamentoRepositorio>(Lifestyle.Scoped);
            container.Register<IRelatoriosComissaoRepositorio, RelatoriosComissaoRepositorio>(Lifestyle.Scoped);
            container.Register<IRelatoriosClienteRepositorio, RelatoriosClienteRepositorio>(Lifestyle.Scoped);
            #endregion

            #region Registro dos Serviços
            container.Register<ICondicaoPagamentoService, CondicaoPagamentoService>(Lifestyle.Scoped);
            container.Register<IContatoClienteService, ContatoClienteService>(Lifestyle.Scoped);
            container.Register<IContatoRepresentadaService, ContatoRepresentadaService>(Lifestyle.Scoped);
            container.Register<IEnderecoClienteService, EnderecoClienteService>(Lifestyle.Scoped);
            container.Register<IFaturamentoService, FaturamentoService>(Lifestyle.Scoped);
            container.Register<IItemPedidoService, ItemPedidoService>(Lifestyle.Scoped);
            container.Register<IMetaService, MetaService>(Lifestyle.Scoped);
            container.Register<IParcelaService, ParcelaService>(Lifestyle.Scoped);
            container.Register<IPedidoService, PedidoService>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaService, PessoaFisicaService>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaService, PessoaJuridicaService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IRepresentadaService, RepresentadaService>(Lifestyle.Scoped);
            container.Register<ISegmentoService, SegmentoService>(Lifestyle.Scoped);
            container.Register<IStatusPedidoService, StatusPedidoService>(Lifestyle.Scoped);
            container.Register<ITipoPedidoService, TipoPedidoService>(Lifestyle.Scoped);
            container.Register<ITransportadoraService, TransportadoraService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IDashboardService, DashboardService>(Lifestyle.Scoped);
            //container.Register<IUsuarioRepresentadaService, UsuarioRepresentadaService>(Lifestyle.Scoped);
            container.Register<IRelatoriosVendaService, RelatoriosVendaService>(Lifestyle.Scoped);
            container.Register<IRelatoriosFaturamentoService, RelatoriosFaturamentoService>(Lifestyle.Scoped);
            container.Register<IRelatoriosComissaoService, RelatoriosComissaoService>(Lifestyle.Scoped);
            container.Register<IRelatoriosClienteService, RelatoriosClienteService>(Lifestyle.Scoped);
            #endregion

            #region Registros da Camada de Aplicação
            container.Register<ICondicaoPagamentoAppService, CondicaoPagamentoAppService>(Lifestyle.Scoped);
            container.Register<IContatoClienteAppService, ContatoClienteAppService>(Lifestyle.Scoped);
            container.Register<IContatoRepresentadaAppService, ContatoRepresentadaAppService>(Lifestyle.Scoped);
            container.Register<IEnderecoClienteAppService, EnderecoClienteAppService>(Lifestyle.Scoped);
            container.Register<IFaturamentoAppService, FaturamentoAppService>(Lifestyle.Scoped);
            container.Register<IItemPedidoAppService, ItemPedidoAppService>(Lifestyle.Scoped);
            container.Register<IMetaAppService, MetaAppService>(Lifestyle.Scoped);
            container.Register<IParcelaAppService, ParcelaAppService>(Lifestyle.Scoped);
            container.Register<IPedidoAppService, PedidoAppService>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaAppService, PessoaFisicaAppService>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaAppService, PessoaJuridicaAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);
            container.Register<IRepresentadaAppService, RepresentadaAppService>(Lifestyle.Scoped);
            container.Register<ISegmentoAppService, SegmentoAppService>(Lifestyle.Scoped);
            container.Register<IStatusPedidoAppService, StatusPedidoAppService>(Lifestyle.Scoped);
            container.Register<ITipoPedidoAppService, TipoPedidoAppService>(Lifestyle.Scoped);
            container.Register<ITransportadoraAppService, TransportadoraAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IDashboardAppService, DashboardAppService>(Lifestyle.Scoped);
            container.Register<IRelatoriosVendaAppService, RelatoriosVendaAppService>(Lifestyle.Scoped);
            container.Register<IRelatoriosFaturamentoAppService, RelatoriosFaturamentoAppService>(Lifestyle.Scoped);
            container.Register<IRelatoriosComissaoAppService, RelatoriosComissaoAppService>(Lifestyle.Scoped);
            container.Register<IRelatoriosClienteAppService, RelatoriosClienteAppService>(Lifestyle.Scoped);
            //container.Register<IUsuarioRepresentadaAppService, UsuarioRepresentadaAppService>(Lifestyle.Scoped);
            #endregion

            #region Servico de Email
            container.Register<IEmailService, EmailService>(Lifestyle.Scoped);
            #endregion

            #region Registros de Serialização 
            container.Register<IEntitySerializationServices<IEnumerable<StatusPedidoViewModel>>, JSONSerializationServices<IEnumerable<StatusPedidoViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<StatusPedidoViewModel>, JSONSerializationServices<StatusPedidoViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<TipoPedidoViewModel>>, JSONSerializationServices<IEnumerable<TipoPedidoViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<TipoPedidoViewModel>, JSONSerializationServices<TipoPedidoViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<TransportadoraViewModel>>, JSONSerializationServices<IEnumerable<TransportadoraViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<SegmentoViewModel>>, JSONSerializationServices<IEnumerable<SegmentoViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<SegmentoViewModel>, JSONSerializationServices<SegmentoViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<RepresentadaViewModel>, JSONSerializationServices<RepresentadaViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<RepresentadaViewModel>>, JSONSerializationServices<IEnumerable<RepresentadaViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<ProdutoViewModel>>, JSONSerializationServices<IEnumerable<ProdutoViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<UsuarioViewModel>>, JSONSerializationServices<IEnumerable<UsuarioViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<UsuarioViewModel>, JSONSerializationServices<UsuarioViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<PedidoViewModel>, JSONSerializationServices<PedidoViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<FaturamentoViewModel>, JSONSerializationServices<FaturamentoViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<MetaViewModel>>, JSONSerializationServices<IEnumerable<MetaViewModel>>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<Comissao>>, JSONSerializationServices<IEnumerable<Comissao>>>(Lifestyle.Scoped);
            #endregion

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<TCC_Contexto>(Lifestyle.Scoped);
        }
    }
}
