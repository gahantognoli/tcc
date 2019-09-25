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
    public class RelatoriosFaturamentoRepositorio : IRelatoriosFaturamentoRepositorio
    {
        public IEnumerable<FaturamentoPorPeriodo> PorPeriodo(DateTime dataEmissaoInicio, DateTime dataEmissaoFim)
        {
            using (var conexao = new ConexaoSqlServer().AbrirConexao())
            {
                IEnumerable<FaturamentoPorPeriodo> retorno;

                retorno = conexao.Query<FaturamentoPorPeriodo>(RelatoriosFaturamentoProcedures.PorPeriodo
                    .GetDescription(), new { @dataEmissaoInicio = dataEmissaoInicio, @dataEmissaoFim = dataEmissaoFim },
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
        }
    }
}
