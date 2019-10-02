namespace UNIFAFIBE.TCC._4Sales.Persistencia.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Security.Cryptography;
    using System.Text;
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
            //List<StatusPedido> statusPedidos = new List<StatusPedido>();
            //statusPedidos.Add(new StatusPedido() { Descricao = "Em Orçamento", Padrao = true });
            //statusPedidos.Add(new StatusPedido() { Descricao = "Pedido de Venda Gerado", Padrao = true });
            //statusPedidos.Add(new StatusPedido() { Descricao = "Parcialmente Faturado", Padrao = true });
            //statusPedidos.Add(new StatusPedido() { Descricao = "Faturado", Padrao = true });

            //List<TipoPedido> tiposPedido = new List<TipoPedido>();
            //tiposPedido.Add(new TipoPedido() { Descricao = "Venda", Padrao = true });

            //List<Usuario> admUser = new List<Usuario>();
            //admUser.Add(new Usuario()
            //{
            //    Nome = "Administrador",
            //    Email = "administrador_4sales@hotmail.com.br",
            //    Senha = GerarHash("adm"),
            //    PrimeiroAcesso = false
            //});

            //context.StatusPedidos.AddRange(statusPedidos);
            //context.TipoPedidos.AddRange(tiposPedido);
            //context.Usuarios.AddRange(admUser);

            //context.SaveChanges();
        }

        private string GerarHash(string texto)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }

            return result.ToString();
        }
    }
}
