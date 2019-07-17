using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Segmentos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Segmentos
{
    public class SegmentoEstaAptoValidation : Validator<Segmento>
    {
        public SegmentoEstaAptoValidation(ISegmentoRepositorio segmentoRepositorio)
        {
            var descricao = new SegmentoDevePossuirDescricaoUnicaSpecification(segmentoRepositorio);

            this.Add("DescricaoDuplicada", new Rule<Segmento>(descricao, "Esse segmento já está em uso!"));
        }
    }
}
