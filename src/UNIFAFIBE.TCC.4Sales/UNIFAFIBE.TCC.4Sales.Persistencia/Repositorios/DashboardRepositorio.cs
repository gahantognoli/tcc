using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class DashboardRepositorio : IDashboardRepositorio
    {
        public decimal ObterMeta(int ano, int mes)
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["4Sales"].ConnectionString;
            using (var cn = new SqlConnection(stringConexao))
            {
                decimal meta = cn.Query<decimal>(DashboardProcedures.ObterMeta.GetDescription(),
                    new { @ano = ano, @mes = mes },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return meta;
            }
        }

        public decimal ObterTotalAReceber(int ano, int mes)
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["4Sales"].ConnectionString;
            using (var cn = new SqlConnection(stringConexao))
            {
                decimal totalReceber = cn.Query<decimal>(DashboardProcedures.ObterTotalAReceber.GetDescription(),
                    new { @ano = ano, @mes = mes },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return totalReceber;
            }
        }

        public decimal ObterTotalFaturamento(int ano, int mes)
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["4Sales"].ConnectionString;
            using (var cn = new SqlConnection(stringConexao))
            {
                decimal totalFaturado = cn.Query<decimal>(DashboardProcedures.ObterTotalFaturado.GetDescription(),
                    new { @ano = ano, @mes = mes },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return totalFaturado;
            }
        }
    }
}
