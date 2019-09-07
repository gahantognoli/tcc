namespace UNIFAFIBE.TCC._4Sales.Persistencia.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

    internal sealed class Configuration : DbMigrationsConfiguration<UNIFAFIBE.TCC._4Sales.Persistencia.Contexto.TCC_Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UNIFAFIBE.TCC._4Sales.Persistencia.Contexto.TCC_Contexto context)
        {
            //***To do: Descomentar quando aplicação for subir para Produção.
            List<StatusPedido > statusPedidos = new List<StatusPedido>();
            statusPedidos.Add(new StatusPedido() { Descricao = "Em Orçamento", Padrao = true });
            statusPedidos.Add(new StatusPedido() { Descricao = "Pedido de Venda Gerado", Padrao = true });
            statusPedidos.Add(new StatusPedido() { Descricao = "Parcialmente Faturado", Padrao = true });
            statusPedidos.Add(new StatusPedido() { Descricao = "Faturado", Padrao = true });

            List<TipoPedido> tiposPedido = new List<TipoPedido>();
            tiposPedido.Add(new TipoPedido() { Descricao = "Venda", Padrao = true });

            List<Usuario> admUser = new List<Usuario>();
            admUser.Add(new Usuario()
            {
                Nome = "Administrador",
                Email = "administrador_4sales@hotmail.com.br",
                Senha = "adm",
                PrimeiroAcesso = false
            });

            context.StatusPedidos.AddRange(statusPedidos);
            context.TipoPedidos.AddRange(tiposPedido);
            context.Usuarios.AddRange(admUser);

            context.SaveChanges();
        }
    }
}
