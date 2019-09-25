using System;
using System.Configuration;
using System.Data.SqlClient;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios.Relatorios
{
    public class ConexaoSqlServer : IDisposable
    {
        private string ObterStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["4Sales"].ConnectionString;
        }

        public SqlConnection AbrirConexao()
        {
            SqlConnection connection = new SqlConnection(ObterStringConexao());
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
