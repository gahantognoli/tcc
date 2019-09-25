using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos.Relatorios;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos.Relatorios
{
    public class RelatoriosClienteAppService : IRelatoriosClienteAppService
    {
        private readonly IRelatoriosClienteService _relatoriosClienteService;
        public RelatoriosClienteAppService(IRelatoriosClienteService relatoriosClienteService)
        {
            _relatoriosClienteService = relatoriosClienteService;
        }

        public IEnumerable<SituacaoCarteiraClientes> SituacaoCarteiraClientes()
        {
            return _relatoriosClienteService.SituacaoCarteiraClientes();
        }
    }
}
