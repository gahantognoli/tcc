using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Segmentos;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Segmentos
{
    public class SegmentoEstaAptoParaRemover : Validator<Segmento>
    {
        public SegmentoEstaAptoParaRemover(IPessoaFisicaRepositorio pessoaFisicaRepositorio, 
            IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            var segmento = new SegmentoNaoDevePossuirClientesVinculadosSpecification(pessoaFisicaRepositorio,
                pessoaJuridicaRepositorio);
            this.Add("segmentoPossuiClientesVinculados", new Rule<Segmento>(segmento, 
                "Existem Clientes vinculados a esse segmento, por favor remova-os e tente novamente"));
        }
    }
}
