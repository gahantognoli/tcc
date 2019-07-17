using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Metas;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Metas
{
    public class MetaEstaConsistenteValidation : Validator<Meta>
    {
        public MetaEstaConsistenteValidation()
        {
            var valor = new MetaDeveSerMaiorQueDoQueZeroSpecification();
            this.Add("ValorMaiorQueZero", new Rule<Meta>(valor, "Meta não pode ser zero!"));
        }
    }
}
