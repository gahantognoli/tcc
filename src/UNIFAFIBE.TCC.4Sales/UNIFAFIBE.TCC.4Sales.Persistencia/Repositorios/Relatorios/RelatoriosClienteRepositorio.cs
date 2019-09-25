using Dapper;
using System.Collections.Generic;
using System.Data;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios.Relatorios
{
    public class RelatoriosClienteRepositorio : IRelatoriosClienteRepositorio
    {
        public IEnumerable<SituacaoCarteiraClientes> SituacaoCarteiraClientes()
        {
            using (var conexao = new ConexaoSqlServer().AbrirConexao())
            {
                IEnumerable<SituacaoCarteiraClientes> retorno;

                retorno = conexao.Query<SituacaoCarteiraClientes>(RelatoriosClienteProcedures.SituacaoCarteiraClientes
                    .GetDescription(), commandType: CommandType.StoredProcedure);

                return retorno;
            }
        }
    }
}
