using AutoMapper;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<CondicaoPagamento, CondicaoPagamentoViewModel>();
            CreateMap<ContatoCliente, ContatoClienteViewModel>();
            CreateMap<ContatoRepresentada, ContatoRepresentadaViewModel>();
            CreateMap<Email, EmailViewModel>();
            CreateMap<EnderecoCliente, EnderecoClienteViewModel>();
            CreateMap<Faturamento, FaturamentoViewModel>();
            CreateMap<ItemPedido, ItemPedidoViewModel>();
            CreateMap<Meta, MetaViewModel>();
            CreateMap<Parcela, ParcelaViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
            CreateMap<PessoaFisica, PessoaFisicaViewModel>();
            CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Representada, RepresentadaViewModel>();
            CreateMap<Segmento, SegmentoViewModel>();
            CreateMap<StatusPedido, StatusPedidoViewModel>();
            CreateMap<TipoPedido, TipoPedidoViewModel>();
            CreateMap<Transportadora, TransportadoraViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<UsuarioRepresentada, UsuarioRepresentadaViewModel>();
        }
    }
}
