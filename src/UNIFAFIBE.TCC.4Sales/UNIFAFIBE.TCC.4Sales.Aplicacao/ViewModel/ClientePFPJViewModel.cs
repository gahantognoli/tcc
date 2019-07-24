using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ClientePFPJViewModel
    {
        public ClientePFPJViewModel()
        {
            pessoaJuridicaViewModels = new List<PessoaJuridicaViewModel>();
            pessoaFisicaViewModels = new List<PessoaFisicaViewModel>();
        }

        public IEnumerable<PessoaFisicaViewModel> pessoaFisicaViewModels { get; set; }
        public IEnumerable<PessoaJuridicaViewModel> pessoaJuridicaViewModels { get; set; }
    }
}
