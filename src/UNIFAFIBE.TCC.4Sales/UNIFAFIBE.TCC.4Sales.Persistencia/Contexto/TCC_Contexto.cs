using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Persistencia.ConfigEntidades;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Contexto
{
    public class TCC_Contexto : DbContext
    {
        public TCC_Contexto() : base("4Sales")
        {
            
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Representada> Representadas { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<UsuarioRepresentada> UsuarioRepresentadas { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Faturamento> Faturamentos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<CondicaoPagamento> CondicoesPagamento { get; set; }
        public DbSet<ContatoCliente> ContatosClientes { get; set; }
        public DbSet<EnderecoCliente> EnderecosClientes { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }
        public DbSet<TipoPedido> TipoPedidos { get; set; }
        public DbSet<ContatoRepresentada> ContatosRepresentada { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new CondicaoPagamentoConfig());
            modelBuilder.Configurations.Add(new ContatoClienteConfig());
            modelBuilder.Configurations.Add(new ContatoRepresentadaConfig());
            modelBuilder.Configurations.Add(new EnderecoClienteConfig());
            modelBuilder.Configurations.Add(new FaturamentoConfig());
            modelBuilder.Configurations.Add(new ItemPedidoConfig());
            modelBuilder.Configurations.Add(new MetaConfig());
            modelBuilder.Configurations.Add(new ParcelasConfig());
            modelBuilder.Configurations.Add(new PedidoConfig());
            modelBuilder.Configurations.Add(new PessoaFisicaConfig());
            modelBuilder.Configurations.Add(new PessoaJuridicaConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new RepresentadaConfig());
            modelBuilder.Configurations.Add(new SegmentoConfig());
            modelBuilder.Configurations.Add(new StatusPedidoConfig());
            modelBuilder.Configurations.Add(new TipoPedidoConfig());
            modelBuilder.Configurations.Add(new TransportadoraConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            //modelBuilder.Configurations.Add(new UsuarioRepresentadaConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
