using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class RepresentadaViewModel
    {
        public Guid RepresentadaId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public decimal Comissao { get; set; }
        public string Telefone { get; set; }
        public string Foto { get; set; }
        public string InformacoesAdicionais { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
        public virtual ICollection<UsuarioRepresentadaViewModel> UsuariosRepresentadas { get; set; }
        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
        public virtual ICollection<CondicaoPagamentoViewModel> CondicoesPagamento { get; set; }
        public virtual ICollection<ContatoRepresentadaViewModel> ContatosRepresentada { get; set; }

    }
}
