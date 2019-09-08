using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface ITransportadoraAppService : IDisposable
    {
        TransportadoraViewModel Adicionar(TransportadoraViewModel transportadora);
        TransportadoraViewModel Atualizar(TransportadoraViewModel transportadora);
        TransportadoraViewModel Remover(Guid id);
        TransportadoraViewModel ObterPorId(Guid id);
        IEnumerable<TransportadoraViewModel> ObterPorNome(string nome);
        IEnumerable<TransportadoraViewModel> ObterPorCidade(string cidade);
        IEnumerable<TransportadoraViewModel> ObterPorEstado(string estado);
        IEnumerable<TransportadoraViewModel> ObterTodos();
    }
}
