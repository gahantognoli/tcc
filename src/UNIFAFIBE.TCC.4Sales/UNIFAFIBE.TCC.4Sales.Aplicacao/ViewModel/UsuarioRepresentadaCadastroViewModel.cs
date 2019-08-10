using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class UsuarioRepresentadaCadastroViewModel
    {
        public UsuarioRepresentadaCadastroViewModel()
        {
            UsuarioViewModel = new UsuarioViewModel();
            RepresentadasViewModel = new List<RepresentadaViewModel>();
        }
        public UsuarioViewModel UsuarioViewModel { get; set; }
        public IEnumerable<RepresentadaViewModel> RepresentadasViewModel { get; set; }
    }
}
