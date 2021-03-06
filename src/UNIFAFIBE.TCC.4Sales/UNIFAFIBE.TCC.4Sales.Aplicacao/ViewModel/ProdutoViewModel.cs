﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            ProdutoId = Guid.NewGuid();
        }

        [Key]
        public Guid ProdutoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Código")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Preencha o campo IPI")]
        [DataType(DataType.Currency)]
        public decimal IPI { get; set; }
        [Display(Name = "Unidade de Medida")]
        [Required(ErrorMessage = "Preencha o campo Unidade de Medida")]
        [MaxLength(10, ErrorMessage = "Tamanho máximo de 10 caracteres")]
        public string UnidadeMedida { get; set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Preencha o campo Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        [ScaffoldColumn(false)]
        public Guid RepresentadaId { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public virtual RepresentadaViewModel Representada { get; set; }
        public ICollection<ItemPedidoViewModel> ItensPedido { get; set; }

        public bool EhValido()
        {
            return this.ValidationResult.IsValid == true;
        }
    }
}
