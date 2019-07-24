using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Segmentos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Segmentos
{
    public class SegmentoEstaConsistenteValidation : Validator<Segmento>
    {
        public SegmentoEstaConsistenteValidation()
        {
            var descricao = new SegmentoDevePossuirDescricaoSpecification();
            this.Add("DescricaoVazia", new Rule<Segmento>(descricao, "Descrição não deve ser vazia!"));
        }
    }
}
