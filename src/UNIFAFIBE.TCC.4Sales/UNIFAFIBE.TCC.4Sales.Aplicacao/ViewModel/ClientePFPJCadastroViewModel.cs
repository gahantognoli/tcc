using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ClientePFPJCadastroViewModel
    {
        public ClientePFPJCadastroViewModel()
        {
            pessoaFisicaViewModels = new PessoaFisicaViewModel();
            pessoaJuridicaViewModels = new PessoaJuridicaViewModel();
        }

        public PessoaFisicaViewModel pessoaFisicaViewModels { get; set; }
        public PessoaJuridicaViewModel pessoaJuridicaViewModels { get; set; }
    }
}
