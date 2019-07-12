using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Segmento
    {
        public Segmento()
        {
            SegmentoId = new Guid();
        }
        public Guid SegmentoId { get; set; }
        public string Descricao { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

        public bool EhValido()
        {
            //ValidationResult = new UsuarioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
