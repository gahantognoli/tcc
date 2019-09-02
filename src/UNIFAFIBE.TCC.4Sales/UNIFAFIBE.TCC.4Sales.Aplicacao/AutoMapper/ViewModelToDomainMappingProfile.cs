using AutoMapper;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<CondicaoPagamentoViewModel, CondicaoPagamento>();
            CreateMap<ContatoClienteViewModel, ContatoCliente>();
            CreateMap<ContatoRepresentadaViewModel, ContatoRepresentada>();
            CreateMap<EmailViewModel, Email>();
            CreateMap<EnderecoClienteViewModel, EnderecoCliente>();
            CreateMap<FaturamentoViewModel, Faturamento>();
            CreateMap<ItemPedidoViewModel, ItemPedido>();
            CreateMap<MetaViewModel, Meta>();
            CreateMap<ParcelaViewModel, Parcela>();
            CreateMap<PedidoViewModel, Pedido>().MaxDepth(3);
            CreateMap<PessoaFisicaViewModel, PessoaFisica>();
            CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<RepresentadaViewModel, Representada>();
            CreateMap<SegmentoViewModel, Segmento>();
            CreateMap<StatusPedidoViewModel, StatusPedido>();
            CreateMap<TipoPedidoViewModel, TipoPedido>();
            CreateMap<TransportadoraViewModel, Transportadora>();
            CreateMap<UsuarioRepresentadaViewModel, UsuarioRepresentada>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
