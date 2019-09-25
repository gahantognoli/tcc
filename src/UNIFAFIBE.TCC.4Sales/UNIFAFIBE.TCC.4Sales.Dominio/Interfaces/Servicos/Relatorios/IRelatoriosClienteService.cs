using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios
{
    public interface IRelatoriosClienteService
    {
        IEnumerable<SituacaoCarteiraClientes> SituacaoCarteiraClientes();
    }
}
