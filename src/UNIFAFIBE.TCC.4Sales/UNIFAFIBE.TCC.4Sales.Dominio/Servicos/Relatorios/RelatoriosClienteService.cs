using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos.Relatorios
{
    public class RelatoriosClienteService : IRelatoriosClienteService
    {
        private readonly IRelatoriosClienteRepositorio _relatoriosClienteRepositorio;

        public RelatoriosClienteService(IRelatoriosClienteRepositorio relatoriosClienteRepositorio)
        {
            _relatoriosClienteRepositorio = relatoriosClienteRepositorio;
        }

        public IEnumerable<SituacaoCarteiraClientes> SituacaoCarteiraClientes()
        {
            return _relatoriosClienteRepositorio.SituacaoCarteiraClientes();
        }
    }
}
