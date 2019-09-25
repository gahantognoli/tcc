using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios
{
    public interface IRelatoriosClienteRepositorio
    {
        IEnumerable<SituacaoCarteiraClientes> SituacaoCarteiraClientes();
    }
}
