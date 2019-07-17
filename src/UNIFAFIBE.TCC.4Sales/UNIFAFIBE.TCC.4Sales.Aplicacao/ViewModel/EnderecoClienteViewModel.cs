﻿using System;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class EnderecoClienteViewModel
    {
        public Guid EnderecoClienteId { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public Guid ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}