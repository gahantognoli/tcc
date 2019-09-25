using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios
{
    public interface IRelatoriosClienteAppService
    {
        IEnumerable<SituacaoCarteiraClientes> SituacaoCarteiraClientes();
    }
}
