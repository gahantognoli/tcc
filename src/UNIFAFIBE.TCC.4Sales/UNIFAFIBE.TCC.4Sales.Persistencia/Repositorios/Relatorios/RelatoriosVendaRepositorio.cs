using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios.Relatorios
{
    public class RelatoriosVendaRepositorio : IRelatoriosVendaRepositorio
    {
        public IEnumerable<VendaPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim)
        {
            using (var conexao = new ConexaoSqlServer().AbrirConexao())
            {
                IEnumerable<VendaPorPeriodo> retorno;

                retorno = conexao.Query<VendaPorPeriodo>(RelatoriosVendaProcedures.PorPeriodo.GetDescription(),
                    new { @dataEmissaoInicio = dataEmissaoInicio, @dataEmissaoFim = dataEmissaoFim },
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
        }

        public IEnumerable<VendaRankingVendedor> RankingVendedores(int mes, int ano)
        {
            using (var conexao = new ConexaoSqlServer().AbrirConexao())
            {
                IEnumerable<VendaRankingVendedor> retorno;

                retorno = conexao.Query<VendaRankingVendedor>(RelatoriosVendaProcedures.RankingVendedores.GetDescription(),
                    new { @mes = mes, @ano = ano },
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
        }
    }
}
