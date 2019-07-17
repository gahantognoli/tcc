using SimpleInjector;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Dominio.Servicos;
using UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios;
using UNIFAFIBE.TCC._4Sales.Transversal.Email;

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
            #endregion

            #region Servico de Email
            container.Register<IEmailService, EmailService>(Lifestyle.Scoped);
            #endregion
        }
    }
}
