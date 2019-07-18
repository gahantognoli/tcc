using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class RepresentadaViewModel
    {
        public Guid RepresentadaId { get; set; }
        public string CNPJ { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Comissão")]
        public decimal Comissao { get; set; }
        public string Telefone { get; set; }
        public string Foto { get; set; }
        [Display(Name = "Informações Adicionais")]
        public string InformacoesAdicionais { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
        public virtual ICollection<UsuarioRepresentadaViewModel> UsuariosRepresentadas { get; set; }
        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
        public virtual ICollection<CondicaoPagamentoViewModel> CondicoesPagamento { get; set; }
        public virtual ICollection<ContatoRepresentadaViewModel> ContatosRepresentada { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.Erros.Count() == 0;
        }
    }
}
