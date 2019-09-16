using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Metas;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Metas
{
    public class MetaEstaAptaValidation : Validator<Meta>
    {
        public MetaEstaAptaValidation(IMetaRepositorio metaRepositorio)
        {
            var meta = new MetaDevePossuirPeriodoUnicoSpecification(metaRepositorio);

            this.Add("MetaDuplicada", new Rule<Meta>(meta, "Já existe uma meta cadastrada para esse periodo!"));
        }
    }
}
