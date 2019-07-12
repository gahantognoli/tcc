using SimpleInjector;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Transversal
{
    public static class SimpleInjectorMapping
    {
        public static void Register(Container container)
        {
            #region Registro dos Repositórios
            container.Register<IClienteRepositorio, ClienteRepositorio>(Lifestyle.Scoped);
            container.Register<ICondicaoPagamentoRepositorio, CondicaoPagamentoRepositorio>(Lifestyle.Scoped);
            container.Register<IContatoClienteRepositorio, ContatoClienteRepositorio>(Lifestyle.Scoped);
            container.Register<IContatoRepresentadaRepositorio, ContatoRepresentadaRepositorio>(Lifestyle.Scoped);
            container.Register<IEnderecoClienteRepositorio, EnderecoClienteRepositorio>(Lifestyle.Scoped);
            container.Register<IFaturamentoRepositorio, FaturamentoRepositorio>(Lifestyle.Scoped);
            container.Register<IItemPedidoRepositorio, ItemPedidoRepositorio>(Lifestyle.Scoped);
            container.Register<IMetaRepositorio, MetaRepositorio>(Lifestyle.Scoped);
            container.Register<IParcelaRepositorio, ParcelaRepositorio>(Lifestyle.Scoped);
            container.Register<IPedidoRepositorio, PedidoRepositorio>(Lifestyle.Scoped);
            container.Register<IPerfilRepositorio, PerfilRepositorio>(Lifestyle.Scoped);
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
        }
    }
}
