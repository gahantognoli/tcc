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
    public class RelatoriosComissaoRepositorio : IRelatoriosComissaoRepositorio
    {
        public IEnumerable<ComissaoPorPeriodo> PorPeriodo(DateTime dataPagamentoInicio, DateTime dataPagamentoFim)
        {
            using (var conexao = new ConexaoSqlServer().AbrirConexao())
            {
                IEnumerable<ComissaoPorPeriodo> retorno;

                retorno = conexao.Query<ComissaoPorPeriodo>(RelatoriosComissaoProcedures.PorPeriodo
                    .GetDescription(), new { @dataPagamentoInicio = dataPagamentoInicio, @dataPagamentoFim = dataPagamentoFim },
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
        }
    }
}
