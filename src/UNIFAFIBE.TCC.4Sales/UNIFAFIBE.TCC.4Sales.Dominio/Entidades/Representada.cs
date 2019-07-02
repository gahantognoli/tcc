using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Representada
    {
        public Representada()
        {
            RepresentadaId = new Guid();
        }

        public Guid RepresentadaId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public decimal Comissao { get; set; }
        public string Telefone { get; set; }
        public string Foto { get; set; }
        public string InformacoesAdicionais { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<CondicaoPagamento> CondicoesPagamento { get; set; }
        public virtual ICollection<ContatoRepresentada> ContatosRepresentada { get; set; }
    }
}
