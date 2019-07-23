using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Segmentos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Entidades
{
    public class Segmento
    {
        public Segmento()
        {
            SegmentoId = Guid.NewGuid();
        }
        public Guid SegmentoId { get; set; }
        public string Descricao { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

        public bool EhValido(ISegmentoRepositorio segmentoRepositorio)
        {
            return this.EstaApto(segmentoRepositorio);
        }

        public bool EstaConsistente()
        {
            return true;
        }

        public bool EstaApto(ISegmentoRepositorio segmentoRepositorio)
        {
            ValidationResult = new SegmentoEstaAptoValidation(segmentoRepositorio).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
