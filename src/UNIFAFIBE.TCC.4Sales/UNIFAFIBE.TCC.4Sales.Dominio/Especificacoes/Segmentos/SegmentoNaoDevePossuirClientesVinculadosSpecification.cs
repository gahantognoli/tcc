using DomainValidation.Interfaces.Specification;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Segmentos
{
    public class SegmentoNaoDevePossuirClientesVinculadosSpecification : ISpecification<Segmento>
    {
        private readonly IPessoaFisicaRepositorio _pessoaFisicaRepositorio;
        private readonly IPessoaJuridicaRepositorio _pessoaJuridicaRepositorio;
        public SegmentoNaoDevePossuirClientesVinculadosSpecification(IPessoaFisicaRepositorio pessoaFisicaRepositorio,
            IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
            _pessoaJuridicaRepositorio = pessoaJuridicaRepositorio;
        }

        public bool IsSatisfiedBy(Segmento segmento)
        {
            var pessoaFisica = _pessoaFisicaRepositorio.ObterPorSegmento(segmento.SegmentoId);
            var pessoaJuridica = _pessoaJuridicaRepositorio.ObterPorSegmento(segmento.SegmentoId);

            if (pessoaFisica.Count() > 0 || pessoaJuridica.Count() > 0)
                return false;

            return true;
        }
    }
}
